//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="HomeTabbedPage.xaml.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   HomeTabbedPage.xaml.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Views
{
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Home tabbed page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Views.HomeTabbedPage"/> class.
        /// </summary>
        public HomeTabbedPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Ons the current page changed.
        /// </summary>
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title;
        }
        }
}
