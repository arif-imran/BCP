using System;
using System.Collections.Generic;
using Prism.Navigation;

namespace BCP.UnitTest.Mocks
{
    public class MockDispatcher : IConfirmNavigation, INavigatedAware
    {
		public readonly List<NavigationParameters> ConfirmNavigation = new List<NavigationParameters>();
		public readonly List<NavigationParameters> NavigatedTo = new List<NavigationParameters>();


		public bool CanNavigate(NavigationParameters parameters)
		{

			ConfirmNavigation.Add(parameters);
			return true;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			NavigatedTo.Add(parameters);
		}

		public bool RequestMainThreadAction(Action action)
		{
			action();
			return true;
		}

	}
}
