using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App_San_ignacio_Conection.Configurations.Network
{
    class NetworkClass
    {
        public static List<string> ScanNetwork(string baseIP, int start, int end)
        {
            List<string> dispositivosActivos = new List<string>();
            Ping pingSender = new Ping();

            for (int i = start; i <= end; i++)
            {
                string ip = baseIP + i.ToString();
                try
                {
                    PingReply reply = pingSender.Send(ip, 10);
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine(ip);
                        dispositivosActivos.Add(ip);
                    }
                }
                catch
                {
                    // Ignorar errores
                }
            }
            return dispositivosActivos;
        }

        public static string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                Console.WriteLine(hostEntry);
                return hostEntry.HostName;
            }
            catch
            {
                return null; // No se pudo obtener el nombre
            }
        }
    }
}
