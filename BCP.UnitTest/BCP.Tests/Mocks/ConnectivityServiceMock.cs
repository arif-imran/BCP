using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;
namespace BCP.UnitTest.Mocks
{
	public class ConnectivityServiceMock : IConnectivity
	{
		public bool IsConnected
		{
			get
			{
                return true;
			}
		}

		public IEnumerable<ConnectionType> ConnectionTypes
		{
			get
			{
				return new[] { ConnectionType.WiFi };
			}
		}

		public IEnumerable<ulong> Bandwidths
		{
			get
			{
				return new[] { (ulong)4000 };
			}
		}

		public event ConnectivityChangedEventHandler ConnectivityChanged;
		public event ConnectivityTypeChangedEventHandler ConnectivityTypeChanged;

		public void Dispose()
		{

		}

		public Task<bool> IsReachable(string host, int msTimeout = 5000)
		{
			return Task.FromResult(true);
		}

		public Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000)
		{
			return Task.FromResult(true);
		}

	}
}
