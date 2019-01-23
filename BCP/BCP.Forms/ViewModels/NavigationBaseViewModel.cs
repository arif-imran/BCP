﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationBaseViewModel.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   NavigationBaseViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Services;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Navigation base view model.
    /// </summary>
    public class NavigationBaseViewModel : BaseViewModel, INavigatedAware
    {
        /// <summary>
        /// The analytics service.
        /// </summary>
        //private IAnalyticsService analyticsService = SharedContainer.ResolveType<IAnalyticsService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.NavigationBaseViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        public NavigationBaseViewModel(IPageDialogService dialogService, IAuthenticationFacade authenticationFacade) : base(dialogService, authenticationFacade)
        {
        }

        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            var modelName = this.GetType().Name;

            // exclude master details page view model. 
            if (modelName != typeof(MainMasterDetailPageViewModel).Name)
            {
                this.AnalyticsService.TrackPageViewEvent(modelName).Forget();
            }
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}