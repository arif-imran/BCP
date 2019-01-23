//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MainMasterDetailPage.xaml.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MainMasterDetailPage.xaml.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// Main master detail page.
    /// </summary>
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Views.MainMasterDetailPage"/> class.
        /// </summary>
        public MainMasterDetailPage()
        {
            this.InitializeComponent();

            if (this.Master is NavigationPage)
            {
                var master = this.Master as NavigationPage;
                if (master.CurrentPage != null)
                {
                    NavigationPage.SetHasNavigationBar(master.CurrentPage, false);
                }
            }
        }
    }
}