﻿using System;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Grosvenor.Forms.Core.Utils;
using BCP.UnitTest.Mocks;
using Prism.Modularity;
using BCP.Common.Services;
using Moq;
using BCP.Facade.Facades;
using BCP.DataAccess.Api;
using Grosvenor.Forms.DataAccess.Services;
using BCP.Forms.Services;
using Prism.Common;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Prism.Events;
using Plugin.Connectivity.Abstractions;

namespace BCP.UnitTest.Helper
{
    public class ContainerHelper: IModule, IDisposable
    {
		protected readonly IUnityContainer container;


		public ContainerHelper()
		{
			this.container = new UnityContainer();

			Initialize();
		}


		public void Initialize()
		{
			SharedContainer.Initialise(this.container);

			Xamarin.Forms.Mocks.MockForms.Init();

			Application.Current = new AppMock();

			RegisterMockInstances();
		}


		void RegisterMockInstances()
		{

			this.container.RegisterInstance(new Mock<IApplicationProvider>().Object);
			this.container.RegisterInstance(new Mock<ICommonUtility>().Object);

			this.container.RegisterType<ILoggerFacade, EmptyLogger>();
			this.container.RegisterType<INavigationService, NavigationServiceMock>();

			this.container.RegisterInstance(new Mock<IPageDialogService>().Object);
			this.container.RegisterInstance(new Mock<IEventAggregator>().Object);

			//this.container.RegisterInstance(new Mock<IDataAccessService>().Object);
			//this.container.RegisterInstance(new Mock<IAnalyticsService>().Object);
			//this.container.RegisterInstance(new Mock<IRequestFactory>().Object);
			//this.container.RegisterInstance(new Mock<ILifecycleService>().Object);
			//this.container.RegisterInstance(new Mock<ICacheService>().Object);
			//this.container.RegisterInstance(new Mock<IAlertService>().Object);
			//this.container.RegisterInstance(new Mock<IConnectivityService>().Object);

			//this.container.RegisterInstance(new Mock<IResourceFacade>().Object);
			//this.container.RegisterInstance(new Mock<IResourceApi>().Object);
			//this.container.RegisterInstance(new Mock<ISettingsFacade>().Object);
			//this.container.RegisterInstance(new Mock<IAuthenticationFacade>().Object);
			//this.container.RegisterInstance(new Mock<IApartmentFacade>().Object);
			//this.container.RegisterInstance(new Mock<IManualFacade>().Object);
			//this.container.RegisterInstance(new Mock<IManualApi>().Object);
			//this.container.RegisterInstance(new Mock<IContactFacade>().Object);
			//this.container.RegisterInstance(new Mock<IContactApi>().Object);
			//this.container.RegisterInstance(new Mock<INewsAndEventsFacade>().Object);
			//this.container.RegisterInstance(new Mock<INewsAndEventsApi>().Object);
			//this.container.RegisterInstance(new Mock<IApartmentApi>().Object);
    
            this.container.RegisterInstance(new Mock<Grosvenor.Forms.Core.Services.IAnalyticsService>().Object);
			this.container.RegisterInstance(new Mock<IDataAccessService>().Object);
			this.container.RegisterInstance(new Mock<ILifecycleService>().Object);
			this.container.RegisterInstance(new Mock<ISettingsFacade>().Object);
			this.container.RegisterInstance(new Mock<IIncidentFacade>().Object);
			this.container.RegisterInstance(new Mock<IUserFacade>().Object);
			this.container.RegisterInstance(new Mock<ICallTreeFacade>().Object);
			this.container.RegisterInstance(new Mock<IContactsFacade>().Object);
			this.container.RegisterInstance(new Mock<IIncidentApi>().Object);
			this.container.RegisterInstance(new Mock<IUserApi>().Object);
			this.container.RegisterInstance(new Mock<IDocumentApi>().Object);
			this.container.RegisterInstance(new Mock<IDocumentFacade>().Object);
			this.container.RegisterInstance(new Mock<ICallTreeApi>().Object);
			this.container.RegisterInstance(new Mock<IContactsApi>().Object);
			this.container.RegisterInstance(new Mock<IAuthenticationFacade>().Object);
			this.container.RegisterInstance(new Mock<IRespondFacade>().Object);
			this.container.RegisterInstance(new Mock<IRespondApi>().Object);
			this.container.RegisterInstance(new Mock<IResourcesFacade>().Object);
			this.container.RegisterInstance(new Mock<IResourceApi>().Object);
			this.container.RegisterInstance(new Mock<ICacheService>().Object);
			this.container.RegisterInstance(new Mock<IDataFetcherService>().Object);
            this.container.RegisterInstance(new Mock<IAppLinker>().Object);
			this.container.RegisterInstance(new Mock<IConnectivityService>().Object);
            this.container.RegisterInstance(new Mock<Common.Services.IDeviceService>().Object);
		}


		public void Dispose()
		{
			Application.Current = null;
		}
    }
}
