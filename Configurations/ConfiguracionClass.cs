using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;



namespace App_San_ignacio_Conection.Configurations
{
    public class ConfiguracionClass
    {
        public string RutaArchivo { get; private set; }
        public bool ValorBooleano { get; set; }
        public string IP { get; set; }

        public void Configuracion(string rutaArchivo)
        {
            RutaArchivo = rutaArchivo;
            Console.WriteLine("asassaaaaaaaaaaaaaaaaaaaaaaaa");
            // Si el archivo no existe, lo crea con valores por defecto
            if (!File.Exists(RutaArchivo))
            {
                ValorBooleano = false; // valor por defecto
                IP = "0.0.0.0";        // valor por defecto
                Guardar();
            }
            else
            {
                Leer();
            }
        }
        public void Guardar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(RutaArchivo, false))
                {
                    sw.WriteLine("Configuracion=" + ValorBooleano.ToString().ToLower());
                    sw.WriteLine("IP=" + IP);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar configuración: " + ex.Message);
            }
        }

        
        public void Leer()
        {
            try
            {
                string[] lineas = File.ReadAllLines(RutaArchivo);
                foreach (string linea in lineas)
                {
                    if (linea.StartsWith("Configuracion="))
                    {
                        string valor = linea.Substring("Configuracion=".Length);
                        if (bool.TryParse(valor, out bool resultado))
                        {
                            ValorBooleano = resultado;
                        }
                    }
                    else if (linea.StartsWith("IP="))
                    {
                        IP = linea.Substring("IP=".Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer configuración: " + ex.Message);
            }
        }


        public List<DeviceClass> GetUSBDevicses()
        {
            List<DeviceClass> usbDevices = new List<DeviceClass>();


            bool configuracion = true;
            string ip = "192.168.1.1";

            string rutaArchivo = "/c/Users/Usuario/Desktop/config.txt";

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