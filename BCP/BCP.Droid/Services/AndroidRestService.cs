//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AndroidRestService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AndroidRestService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid.Services
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using BCP.Common;
    using BCP.DataAccess.Model;
    using BCP.DataAccess.Services;
    using ModernHttpClient;
    using Newtonsoft.Json;

    /// <summary>
    /// Android rest service.
    /// </summary>
    public class AndroidRestService : MainActivity, ISimpleRestService
    {
        /// <summary>
        ///     The download semaphore slim
        /// </summary>
        private readonly SemaphoreSlim downloadSemaphoreSlim = new SemaphoreSlim(1);

        /// <summary>
        ///     The perform request semaphore slim
        /// </summary>
        private readonly SemaphoreSlim performRequestSemaphoreSlim = new SemaphoreSlim(1);

        /// <summary>
        /// The get error result.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ErrorResult> GetErrorResult(HttpResponseMessage result)
        {
            try
            {
                var responseString = await result.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<string>(responseString);

                var errorResponse = new ErrorResult()
                {
                    StatusCode = (int)result.StatusCode,
                    StatusDescription = errorMessage
                };

                return errorResponse;
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.WriteLine("SimpleRestService PostAsync Exception: {0}", e.Message);
#endif
                return new ErrorResult() { StatusCode = 500, StatusDescription = "Internal error occurred" };
            }
        }

        /// <summary>
        /// The get status code.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetStatusCode(string response)
        {
            try
            {
                var errorResult = JsonConvert.DeserializeObject<ErrorResult>(response);
                return errorResult.StatusCode;
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.WriteLine("SimpleRestService PostAsync Exception: {0}", e.Message);
#endif
                return 500;
            }
        }

        /// <summary>
        /// Gets the object from API.
        /// </summary>
        /// <returns>The object from API.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">get or post Httep Verb.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetObjectFromAPI<T>(string requestUrl, HttpMethod verb, bool failSilent = false)
        {
            var result = await this.MakeOpenRequestAsync<T>(requestUrl, verb, failSilent);
            if (result.ContentStatus != ResponseContentStatus.Fail)
            {
                if (requestUrl.Contains("GetUserProfile") && result.Content == null)
                {
                    var userName = requestUrl.Substring(requestUrl.IndexOf('=') + 1);
                    await this.ShowAlert("Alert", string.Format("User profile for \"{0}\" does not exist", userName));
                }

                return result.Content;
            }
            else
            {
                ////if (!failSilent)
                ////{
                //    await this.ShowAlert("Server Error", result.ErrorResponse.StatusDescription);
                ////}
                return default(T);
            }
        }

        /// <summary>
        /// Makes the open base request asynchronous.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the response.
        /// </typeparam>
        /// <param name="requestUrl">
        /// The request URL.
        /// </param>
        /// <param name="verb">
        /// The verb.
        /// </param>
        /// <returns>
        /// The result of Base Response
        /// </returns>
        /// <param name="failSilent">
        /// Will Fail Silently 
        /// </param>
        /// <exception cref="InternetConnectivityException">
        /// Connectivity exception
        /// </exception>
        public async Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, bool failSilent = false)
        {
            var responseData = new ApiResponse<T>();
            HttpResponseMessage result = null;

#if DEBUG
            Debug.WriteLine($"Perform open HTTP {verb.Method} request async: {requestUrl}");
#endif

            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var request = new HttpRequestMessage { Method = verb };

                request.RequestUri = new Uri(requestUrl);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Basic " + this.GenerateBasicAuthenticationHeader());
                try
                {
                    result = await client.SendAsync(request).ConfigureAwait(false);

#if DEBUG
                    Debug.WriteLine($"Finished open HTTP {verb.Method} request async: {requestUrl}");
#endif
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        responseData.ContentStatus = ResponseContentStatus.OK;
                        if (typeof(T) == typeof(byte[]))
                        {
                            var responseString = await result.Content.ReadAsByteArrayAsync();
                            T val = (T)Convert.ChangeType(responseString, typeof(T));
                            responseData.Content = val;
                        }
                        else
                        {
                            var responseString = await result.Content.ReadAsStringAsync();
                            responseData.Content = JsonConvert.DeserializeObject<T>(
                            responseString);
                        }
                    }
                    else
                    {
                        if (!failSilent)
                        {
                            responseData.ContentStatus = ResponseContentStatus.Fail;
                            string errorMsg = "Something went wrong, Please contact admin";
                            if (result.StatusCode == HttpStatusCode.SwitchingProtocols || result.StatusCode == HttpStatusCode.Continue)
                            {
                                errorMsg = "Try to reconnect or refresh the page";
                            }
                            else if (result.StatusCode == HttpStatusCode.Moved || result.StatusCode == HttpStatusCode.NotModified)
                            {
                                errorMsg = "Try to reconnect or refresh the page";
                            }
                            else if (result.StatusCode == HttpStatusCode.InternalServerError || (int)result.StatusCode >= 500)
                            {
                                errorMsg = "Service unreachable";
                            }

                            responseData.ErrorResponse = new ErrorResult() { StatusCode = (int)HttpStatusCode.NotFound, StatusDescription = errorMsg };
                        }
                    }

                    return responseData;
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine(
                        "{1} SimpleRestService MakeOpenBaseRequestAsync Exception: {0}",
                        ex.Message,
                        requestUrl);
#endif
                    if (result != null)
                    {
                        responseData.ErrorResponse = await this.GetErrorResult(result);
                    }
                    else
                    {
                        responseData.ErrorResponse = new ErrorResult() { StatusCode = 500, StatusDescription = "Something went wrong, Please contact admin" };
                    }

                    responseData.ContentStatus = ResponseContentStatus.Fail;

                    return responseData;
                }
            }
        }

        /// <summary>
        /// Generates the basic authentication header.
        /// </summary>
        /// <returns>The basic authentication header.</returns>
        private string GenerateBasicAuthenticationHeader()
        {
            var authUserData = string.Format("{0}:{1}", SharedConfig.ServiceAccountUsername, SharedConfig.ServiceAccountPassword);
            var authHeaderVal = Convert.ToBase64String(Encoding.UTF8.GetBytes(authUserData));
            Debug.WriteLine("Auth Header " + authHeaderVal);
            return authHeaderVal;
        }
    }
}