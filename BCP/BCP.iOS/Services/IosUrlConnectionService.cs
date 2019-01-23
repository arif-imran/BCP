//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IosUrlConnectionService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IosUrlConnectionService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS.Services
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common;
    using BCP.DataAccess.Model;
    using BCP.Facade.Facades;
    using Foundation;
    using Newtonsoft.Json;

    /// <summary>
    /// Ios URL connection service.
    /// </summary>
    /// <typeparam name="T">The first generic type parameter.</typeparam>
    public class IosUrlConnectionService<T> : NSUrlConnectionDataDelegate
    {
        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The is downloading.
        /// </summary>
        private bool isDownloading;

        /// <summary>
        /// The download data.
        /// </summary>
        private NSMutableData downloadData;

        /// <summary>
        /// The http response.
        /// </summary>
        private NSHttpUrlResponse httpResponse;

        /// <summary>
        /// The response data.
        /// </summary>
        private ApiResponse<T> responseData;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.IOS.Services.IosUrlConnectionService`1"/> class.
        /// </summary>
        /// <param name="settingsFacade">Settings facade.</param>
        public IosUrlConnectionService(ISettingsFacade settingsFacade)
        {
            this.settingsFacade = settingsFacade;
        }

        /// <summary>
        /// Makes the open request async.
        /// </summary>
        /// <returns>The open request async.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">Verb Parameter.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        public async Task<ApiResponse<T>> MakeOpenRequestAsync(string requestUrl, HttpMethod verb, bool failSilent = false)
        {
            this.responseData = new ApiResponse<T>();
            var url = NSUrl.FromString(requestUrl.Replace(" ", "%20"));
            var request = new NSMutableUrlRequest(url);
            try
            {
                this.downloadData = null;
                this.httpResponse = null;
                this.isDownloading = true;
                var headers = new NSDictionary(new NSString("Content-Type"), new NSString("application/json"), new NSString("Accept"), new NSString("application/json"));
                request.Headers = headers;
                var conn = new NSUrlConnection(request, this, false);
                conn.SetDelegateQueue(new NSOperationQueue());
                conn.Start();
                var startedTime = DateTime.Now;
                while (this.isDownloading)
                {
                    if ((DateTime.Now - startedTime).TotalSeconds > 30)
                    {
                        this.responseData.ErrorResponse = new ErrorResult() { StatusDescription = "Connection timed out." };
                        break;
                    }
                }

                if (this.httpResponse != null)
                {
                    var resultString = NSString.FromData(this.downloadData, NSStringEncoding.UTF8);
                    if (this.httpResponse.StatusCode == 200)
                    {
                        this.responseData.ContentStatus = ResponseContentStatus.OK;
                        if (typeof(T) == typeof(byte[]))
                        {
                            byte[] bytes = this.downloadData.ToArray();
                            T val = (T)Convert.ChangeType(bytes, typeof(T));
                            this.responseData.Content = val;
                        }
                        else
                        {
                            this.responseData.Content = JsonConvert.DeserializeObject<T>(resultString);
                        }
                    }
                    else
                    {
                        if (!failSilent)
                        {
                            this.responseData.ContentStatus = ResponseContentStatus.Fail;
                            string errorMsg = "Something went wrong, Please contact admin";
                            if (this.httpResponse.StatusCode >= 100 && this.httpResponse.StatusCode < 200)
                            {
                                errorMsg = "Try to reconnect or refresh the page";
                            }
                            else if (this.httpResponse.StatusCode >= 300 && this.httpResponse.StatusCode < 400)
                            {
                                errorMsg = "Try to reconnect or refresh the page";
                            }
                            else if (this.httpResponse.StatusCode >= 500)
                            {
                                errorMsg = "Service unreachable";
                            }

                            this.responseData.ErrorResponse = new ErrorResult() { StatusCode = (int)this.httpResponse.StatusCode, StatusDescription = errorMsg };
                        }
                    }
                }
                else
                {
                    this.responseData.ContentStatus = ResponseContentStatus.Fail;
                }

                return this.responseData;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(
                        "{1} IosRestService MakeOpenBaseRequestAsync Exception: {0}",
                        ex.Message,
                        requestUrl);
#endif
                if (this.httpResponse != null)
                {
                    var resultString = NSString.FromData(this.downloadData, NSStringEncoding.UTF8);
                    this.responseData.ErrorResponse = new ErrorResult() { StatusCode = (int)this.httpResponse.StatusCode, StatusDescription = JsonConvert.DeserializeObject<string>(resultString) };
                }

                this.responseData.ContentStatus = ResponseContentStatus.Fail;
                return this.responseData;
            }
        }

        /// <summary>
        /// Receiveds the data.
        /// </summary>
        /// <param name="connection">Connection Parameter.</param>
        /// <param name="data">Data Parameter.</param>
        public override void ReceivedData(NSUrlConnection connection, NSData data)
        {
            if (this.downloadData == null)
            {
                this.downloadData = new NSMutableData();
            }

            this.downloadData.AppendData(data);
        }

        /// <summary>
        /// Receiveds the response.
        /// </summary>
        /// <param name="connection">Connection Parameter.</param>
        /// <param name="response">Response Parameter.</param>
        public override void ReceivedResponse(NSUrlConnection connection, NSUrlResponse response)
        {
            this.httpResponse = response as NSHttpUrlResponse;
            if (this.httpResponse != null && this.httpResponse.StatusCode == 200)
            {
                this.downloadData = new NSMutableData();
            }
        }

        /// <summary>
        /// Finisheds the loading.
        /// </summary>
        /// <param name="connection">Connection Parameter.</param>
        public override void FinishedLoading(NSUrlConnection connection)
        {
            this.isDownloading = false;
        }

        /// <summary>
        /// Wills the send request for authentication challenge.
        /// </summary>
        /// <param name="connection">Connection Parameter.</param>
        /// <param name="challenge">Challenge Parameter.</param>
        public override void WillSendRequestForAuthenticationChallenge(NSUrlConnection connection, NSUrlAuthenticationChallenge challenge)
        {
            if (challenge.PreviousFailureCount > 0)
            {
                // auth failed
                challenge.Sender.CancelAuthenticationChallenge(challenge);
                this.responseData = new ApiResponse<T>()
                {
                    ContentStatus = ResponseContentStatus.Fail,
                    ErrorResponse = new ErrorResult()
                    {
                        StatusCode = 401,
                        StatusDescription
                        = "Unauthorized - invalid user credentials."
                    }
                };
                this.isDownloading = false;

#if DEBUG
                Debug.WriteLine("IosRestService MakeOpenBaseRequestAsync failed: Unauthorized - invalid user credentials");
#endif
                return;
            }

            string username = SharedConfig.ServiceAccountUsername;
            string password = SharedConfig.ServiceAccountPassword;
            challenge.Sender.UseCredential(new NSUrlCredential(username, password, NSUrlCredentialPersistence.None), challenge);
        }
    }
}
