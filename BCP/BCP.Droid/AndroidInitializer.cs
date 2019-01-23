//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AndroidInitializer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AndroidInitializer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid
{
    using BCP.Common.Services;
    using BCP.DataAccess.Services;
    using BCP.Droid.Services;
    using BCP.Forms.Services;
    using Grosvenor.Forms.DataAccess.Services;
    using Grosvenor.Forms.MobileIron.Droid.Services;
    using Grosvenor.Forms.MobileIron.Services;
    using Microsoft.Practices.Unity;
    using Prism.Unity;

    /// <summary>
    /// Android initializer.
    /// </summary>
    public class AndroidInitializer : IPlatformInitializer
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The Container.</param>
        public void RegisterTypes(IUnityContainer container)
        {
            UnityContainerExtensions.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>(container, new ContainerControlledLifetimeManager());
            UnityContainerExtensions.RegisterType<IAnalyticsProvider, DroidAppInsightsAnalyticsProvider>(container, new ContainerControlledLifetimeManager());
            UnityContainerExtensions.RegisterType<ISimpleRestService, AndroidRestService>(container, new ContainerControlledLifetimeManager());
#if MOBILE_IRON
            UnityContainerExtensions.RegisterType<IMobileIronService, AndroidMobileIronService>(container, new ContainerControlledLifetimeManager());
#else
            UnityContainerExtensions.RegisterType<IMobileIronService, FakeMobileIronService>(container, new ContainerControlledLifetimeManager());
#endif
            UnityContainerExtensions.RegisterType<IAppLinker, AppLinker>(container, new ContainerControlledLifetimeManager());
        }
    }
}
