using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Collections.Generic;



namespace App_San_ignacio_Conection.Configurations
{
    public class ConfiguracionClass
    {


        
        public List<DeviceClass> GetUSBDevicses()
        {
            List<DeviceClass> usbDevices = new List<DeviceClass>();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub"))
            {
                foreach (var device in searcher.Get())
                {
                    
                    usbDevices.Add(new DeviceClass(
                        (string)device.GetPropertyValue("DeviceID"),
                        (string)device.GetPropertyValue("PNPDeviceID"),
                        (string)device.GetPropertyValue("Description")
                    ));
                }
            }

            return usbDevices;
        }

    }
}