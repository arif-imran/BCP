// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ExtendedLoadingPageViewModel.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   ExtendedLoadingPageViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;

    /// <summary>
    /// Extended loading page view model.
    /// </summary>
    public class ExtendedLoadingPageViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
