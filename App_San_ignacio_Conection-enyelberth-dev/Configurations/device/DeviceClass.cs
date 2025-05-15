using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

public class DeviceClass
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public DeviceClass()
    {
        Id = "";
        Name = "";
        Description = "";
    }

    public DeviceClass(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public List<DeviceClass> GetUSBDevice()
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

    //public static void SearchDevices(ListBox listBox1)
    //{
    //    var deviceClass = new DeviceClass();
    //    var getUSBDevices = deviceClass.GetUSBDevice();

    //    if (getUSBDevices != null)
    //    {
    //        foreach (var device in getUSBDevices)
    //        {
    //            Console.WriteLine(device.Name + " " + device.Description + " " + device.Id);
    //            listBox1.Items.Add(device.Name + " " + device.Id);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
    //        MessageBox.Show("No se pudieron obtener los dispositivos iniciales.");
    //    }
    //}
}
