//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IosRestService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IosRestService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.DataAccess.Model;
    using BCP.DataAccess.Services;
    using BCP.Facade.Facades;
    using UIKit;

    /// <summary>
    /// Ios rest service.
    /// </summary>
    public class IosRestService : ISimpleRestService
    {
        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.IOS.Services.IosRestService"/> class.
        /// </summary>
        /// <param name="settingsFacade">Settings facade.</param>
        public IosRestService(ISettingsFacade settingsFacade)
        {
            this.settingsFacade = settingsFacade;
        }

        /// <summary>
        /// Gets the object from API.
        /// </summary>
        /// <returns>The object from API.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">Verb Parameter.</param>
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
                    this.ShowAlert("Alert", string.Format("User profile for \"{0}\" does not exist", userName));
                }

                return result.Content;
            }
            else
            {
                // if (!failSilent)
                // {
                //    ShowAlert("Server Error",result.ErrorResponse.StatusDescription);
                // }
                return result.Content;
            }
        }

        /// <summary>
        /// Makes the open request async.
        /// </summary>
        /// <returns>The open request async.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">Verb Parameter.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, bool failSilent = false)
        {
            var urlConnectionService = new IosUrlConnectionService<T>(this.settingsFacade);
            return urlConnectionService.MakeOpenRequestAsync(requestUrl, verb, failSilent);
        }

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="title">Title Parameter.</param>
        /// <param name="msg">Message Parameter.</param>
        public void ShowAlert(string title, string msg)
        {
            UIApplication.SharedApplication.BeginInvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = title,
                    Message = msg
                };
                alert.AddButton("OK");
                alert.Show();
            });
        }
    }
}
