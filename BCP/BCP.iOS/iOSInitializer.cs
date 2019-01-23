//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="iOSInitializer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   iOSInitializer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS
{
    using BCP.Common.Services;
    using BCP.DataAccess.Services;
    using BCP.Forms.Services;
    using BCP.IOS.Services;
    using Grosvenor.Forms.DataAccess.Services;
    using Grosvenor.Forms.MobileIron.iOS.Services;
    using Grosvenor.Forms.MobileIron.Services;
    using Microsoft.Practices.Unity;
    using Prism.Unity;

    /// <summary>The i os initializer.</summary>
    public class IOSInitializer : IPlatformInitializer
    {
        /// <summary>The register types.</summary>
        /// <param name="container">The container.</param>
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IAnalyticsProvider, IosAppInsightsAnalyticsProvider>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IAppLinker, AppLinker>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IMobileIronService, IosMobileIronService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISimpleRestService, IosRestService>(new ContainerControlledLifetimeManager());
        }
    }
}