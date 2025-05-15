using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_San_ignacio_Conection.Configurations;

namespace App_San_ignacio_Conection
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TEst
            //List<string> listaDevice = new List<string>();
            //ConfiguracionClass configuracion = new ConfiguracionClass();

            //var dis = configuracion.GetUSBDevices();
            //if (dis != null)
            //{
            //    foreach (var device in dis)
            //    {
            //        Console.WriteLine(device.Name + device.Description + device.Id);
            //        MessageBox.Show("El dispositivo " + device.Name + " " + device.Id + " está conectado");
            //        listaDevice.Add(device.Name + " " + device.Id);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
            //}

            //MessageBox.Show("Verificar dispositivos conectados y descripción");
            //Console.WriteLine("Inicio de monitoreo de dispositivos...");

            //while (true)
            //{
            //    Thread.Sleep(3000); // Esperar 3 segundos antes de verificar nuevamente

            //    var dispositivosActuales = configuracion.GetUSBDevices()?.Select(d => d.Name + " " + d.Id).ToList();

            //    if (dispositivosActuales == null)
            //    {
            //        Console.WriteLine("Error al obtener dispositivos.");
            //        continue; // Saltar esta iteración
            //    }

            //    var dispositivosNuevos = dispositivosActuales.Except(listaDevice).ToList();
            //    var dispositivosQuitados = listaDevice.Except(dispositivosActuales).ToList();

            //    if (dispositivosNuevos.Any() || dispositivosQuitados.Any())
            //    {
            //        foreach (var nuevo in dispositivosNuevos)
            //        {
            //            // En lugar de MessageBox.Show, puedes usar Console.WriteLine para evitar bloqueos
            //            Console.WriteLine("Nuevo dispositivo conectado: " + nuevo);
            //            MessageBox.Show("Nuevo dispositivo conectado: " + nuevo);
            //        }

            //        foreach (var quitado in dispositivosQuitados)
            //        {
            //            Console.WriteLine("Dispositivo desconectado: " + quitado);
            //            MessageBox.Show("Dispositivo desconectado: " + quitado);
            //        }

            //        listaDevice = dispositivosActuales;
            //    }
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Form1());
            

        }
       
    }
}
