using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Common;
using BCP.Common.Models;
using BCP.DataAccess.Api;
using BCP.DataAccess.Model;

namespace BCP.DataAccess.Api
{
	public class FakeResourceApi : IResourceApi
	{
		public FakeResourceApi()
		{
		}

		public async Task<IEnumerable<Resource>> GetResourcesList()
		{
            await Task.Delay(SharedConfig.FakeDelay);
            return new List<Resource>()
                {
                    new Resource() { Name= "Google",URL = "https://www.google.com.pk/",Category = ResourceType.Link},
                    new Resource() { Name = "Twitter",URL = "http://www.twitter.com/",Category = ResourceType.Link},
                    new Resource() { Name = "C# Tutorial PDF",URL = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf",Category = ResourceType.Documents},
                    new Resource() { Name = "Xamarin Tutorial PDF",URL = "https://www.tutorialspoint.com/xamarin/xamarin_tutorial.pdf",Category = ResourceType.Documents},
                    new Resource() { Name = "App 1",URL = "fb://profile",Category = ResourceType.Apps,IOSFallBackURL="https://itunes.apple.com/in/app/facebook/id284882215",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.facebook.katana"},
                    new Resource() { Name = "App 2",URL = "twitter://timeline",Category = ResourceType.Apps, IOSFallBackURL="https://itunes.apple.com/us/app/twitter/id333903271?mt=8",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.twitter.android"},
            };
		}
	}
}
