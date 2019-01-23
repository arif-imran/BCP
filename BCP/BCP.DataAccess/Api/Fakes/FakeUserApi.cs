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
	public class FakeUserApi : IUserApi
	{
		readonly ICacheService cacheService;
		public FakeUserApi(ICacheService cacheService)
		{
			this.cacheService = cacheService;
		}
		public async Task<UserSettings> GetUserProfile(string username)
		{
			try
			{
				string requestUrl = ApiRequestHelper.GetUserProfile(username);
				var result = await this.cacheService.GetOrFetchSettings(requestUrl, () => Task.Factory.StartNew(() => getUserProfile(username)));
				return result;
			}
			catch (Exception ex)
			{
#if DEBUG
				Debug.WriteLine("{0} GetUserProfile Exception: {1}", GetType().Name, ex.Message);
#endif
				throw ex;
			}
		}
		private UserSettings getUserProfile(string username)
		{
            return new UserSettings() {FirstName="Kaho", LastName="Narita", Location = "Tokyo", Role = "Asset Manager" };
		}
		public async Task<byte[]> GetUserProfilePic(string username)
		{
            return null;
		}

		public async Task<IEnumerable<string>> GetAllUserLocations()
		{
            await Task.Delay(SharedConfig.FakeDelay);
			try
			{
				string requestUrl = ApiRequestHelper.GetAllUserLocations();
				var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, () => Task.Factory.StartNew(() => getAllUserLocations()));
				return result;
			}
			catch (Exception ex)
			{
#if DEBUG
				Debug.WriteLine("{0} GetAllUserLocations Exception: {1}", GetType().Name, ex.Message);
#endif
				throw ex;
			}
		}
		private IEnumerable<string> getAllUserLocations()
		{
			return new List<string>() { "Tokyo", "Hong Kong", "Shanghai" };
		}

		public async Task<IEnumerable<string>> GetAllUserRoles()
		{
            await Task.Delay(SharedConfig.FakeDelay);
			try
			{
				string requestUrl = ApiRequestHelper.GetAllUserRoles();
				var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, () => Task.Factory.StartNew(() => getAllUserRoles()));
				return result;
			}
			catch (Exception ex)
			{
#if DEBUG
				Debug.WriteLine("{0} GetAllUserRoles Exception: {1}", GetType().Name, ex.Message);
#endif
				throw ex;
			}
		}
		private IEnumerable<string> getAllUserRoles()
		{
            return new List<string>() { "Bronze / Silver Commander", "IT Coordinator", "People Coordinator (HR)", "Communications Communicator (CC)", "Asset Manager" };
		}
	}
}
