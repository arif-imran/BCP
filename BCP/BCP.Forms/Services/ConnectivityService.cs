using BCP.Common.Services;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
namespace BCP.Forms.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public ConnectivityService()
        {
        }
		public IConnectivity connectivity;
		public IConnectivity Instance
		{
			get
			{
				return connectivity ?? (connectivity = CrossConnectivity.Current);
			}
			set
			{
				connectivity = value;
			}
		}
    }
}
