using System;
using BCP.Common.Services;
using Xamarin.Forms;

namespace BCP.Forms.Services
{
    public class DeviceService : IDeviceService
    {
        public string RuntimePlatform {
            get{
                return Device.RuntimePlatform;
            }
        }

        public void OpenURI(Uri uri)
        {
            Device.OpenUri(uri);
        }
    }
}
