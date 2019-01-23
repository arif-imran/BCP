//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="PdfViewerPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   PdfViewerPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Threading.Tasks;
    using BCP.DataAccess.Api;
    using BCP.Facade.Facades;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Pdf viewer page view model.
    /// </summary>
    public class PdfViewerPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The document facade.
        /// </summary>
        private readonly IDocumentFacade documentFacade;

        /// <summary>
        /// The URL.
        /// </summary>
        private string url;

        /// <summary>
        /// The document bytes.
        /// </summary>
        private byte[] documentBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.PdfViewerPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="documentFacade">Document facade.</param>
        public PdfViewerPageViewModel(
            IPageDialogService dialogService,
            IAuthenticationFacade authenticationFacade,
            IDocumentFacade documentFacade)
            : base(dialogService, authenticationFacade)
        {
            this.documentFacade = documentFacade;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url
        {
            get { return this.url; }
            set { this.SetProperty(ref this.url, value); }
        }

        /// <summary>
        /// Gets or sets the document bytes.
        /// </summary>
        /// <value>The document bytes.</value>
        public byte[] DocumentBytes
        {
            get { return this.documentBytes; }
            set { this.SetProperty(ref this.documentBytes, value); }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            this.IsBusy = true;
            base.OnNavigatedTo(parameters);

            this.ExecuteAsyncTask(async () =>
            {
                this.Title = (string)parameters?["Title"];
                this.Url = (string)parameters?["Url"];
                if (string.IsNullOrEmpty(this.Url))
                {
                    this.Url = ApiRequestHelper.GetFullBCPDocument();
                }

                await this.LoadDocument();
            });
        }

        /// <summary>
        /// Loads the document.
        /// </summary>
        /// <returns>The document.</returns>
        private async Task LoadDocument()
        {
            var bytes = await this.documentFacade.GetBCPDocument(this.Url);
            this.DocumentBytes = bytes;
        }
    }
}
