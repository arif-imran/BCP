using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BCP.Common;
using BCP.Common.Models;
using BCP.Common.Services;
using BCP.DataAccess.Model;

namespace BCP.DataAccess.Api
{
    public class FakeRespondApi : IRespondApi
    {
        readonly ICacheService cacheService;
        public FakeRespondApi(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }
		public async Task<RespondContent> GetRespondContent(string role,string location)
		{
            await Task.Delay(SharedConfig.FakeDelay);
			return new RespondContent()
			{
                Flowchart = new List<string>()
					{
						"1Being notified by Bronze Commander / BCMT Member of what type of incident happened.",
						"2Initiate latest call tree - Confirm staff safety and brief staff on situation by email / phone / sms, if it happened in Tokyo / Shanghai, redirect to local HR to take action. Record the list at the end.",
                        "3Assess whether any injuries on staff. If yes, provide necessney assistance and contact insurance.",
                    "If there is a need to send notification to staff, centralize the message to XX (CC) to announce internally."
					},
                RespondHeader = "Helo helo",
				AdditionalInformation = "<p>Bla bla bla bla bla</p>",
                UsefulTools = new List<Resource>(){
					new Resource() { Name= "Google",URL = "https://www.google.com.pk/",Category = ResourceType.Link},
					new Resource() { Name = "Twitter",URL = "http://www.twitter.com/",Category = ResourceType.Link},
					new Resource() { Name = "C# Tutorial PDF",URL = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf",Category = ResourceType.Documents},
					new Resource() { Name = "Xamarin Tutorial PDF",URL = "https://www.tutorialspoint.com/xamarin/xamarin_tutorial.pdf",Category = ResourceType.Documents},
					new Resource() { Name = "App 1",URL = "fb://profile",Category = ResourceType.Apps,IOSFallBackURL="https://itunes.apple.com/in/app/facebook/id284882215",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.facebook.katana"},
					new Resource() { Name = "App 2",URL = "twitter://timeline",Category = ResourceType.Apps, IOSFallBackURL="https://itunes.apple.com/us/app/twitter/id333903271?mt=8",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.twitter.android"},
					
				
                }
			};
		}
    }
}



