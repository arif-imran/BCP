using System;
using System.Threading.Tasks;
using Prism.Common;
using Prism.Logging;
using Prism.Navigation;
using Xamarin.Forms;
namespace BCP.UnitTest.Mocks
{
	public class NavigationServiceMock : PageNavigationService
	{

		public NavigationServiceMock(IApplicationProvider applicationProvider, ILoggerFacade logger) : base(applicationProvider, null)
		{
		}

		public string LastNavigationUrl { get; private set; }

		protected override Page CreatePage(string segmentName)
		{
			return new Page();
		}

		public override Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
		{
			return base.NavigateAsync(uri, parameters, useModalNavigation, animated);

		}

		public override Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
		{
			this.LastNavigationUrl = name;

			return base.NavigateAsync(name, parameters, useModalNavigation, animated);
		}
	}
}
