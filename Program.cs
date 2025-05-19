using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        static Internet internetForm = null;
        static NoInternet noInternetForm = null;
        static usbConec usbConecForm = null;
        static usbDesconec usbDesconecForm = null;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear un formulario principal vacío o con interfaz si lo tienes
            Form1 Form1 = new Form1();

            // Ejecutar el monitoreo en segundo plano para no bloquear la UI
            Task.Run(() => Monitorizar(Form1));

            Application.Run(Form1);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new Form1());
            

        }
        static void Monitorizar(Form mainForm)
        {
            List<string> listaDevice = new List<string>();
            DeviceClass configuracion = new DeviceClass();

            var dis = configuracion.GetUSBDevice();
            if (dis != null)
            {
                foreach (var device in dis)
                {
                    Console.WriteLine(device.Name + device.Description + device.Id);
                    listaDevice.Add(device.Name + " " + device.Id);
                }
            }
            else
            {
                Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
            }

            Console.WriteLine("Inicio de monitoreo de dispositivos...");

            bool? internetDisponibleAnterior = null;

            while (true)
            {
                Thread.Sleep(3000);

                bool internetDisponible = IsInternetAvailable();

                if (internetDisponibleAnterior == null || internetDisponibleAnterior != internetDisponible)
                {
                    internetDisponibleAnterior = internetDisponible;

                    if (internetDisponible)
                    {
                        mainForm.Invoke((MethodInvoker)(() =>
                        {
                            // Cerrar formulario NoInternet si está abierto
                            if (noInternetForm != null && !noInternetForm.IsDisposed)
                            {
                                noInternetForm.Close();
                                noInternetForm = null;
                            }

                            // Mostrar formulario Internet si no está abierto
                            if (internetForm == null || internetForm.IsDisposed)
                            {
                                internetForm = new Internet();
                                internetForm.Show();
                            }
                        }));
                    }
                    else
                    {
                        mainForm.Invoke((MethodInvoker)(() =>
                        {
                            // Cerrar formulario Internet si está abierto
                            if (internetForm != null && !internetForm.IsDisposed)
                            {
                                internetForm.Close();
                                internetForm = null;
                            }

                            // Mostrar formulario NoInternet si no está abierto
                            if (noInternetForm == null || noInternetForm.IsDisposed)
                            {
                                noInternetForm = new NoInternet();
                                noInternetForm.Show();
                            }
                        }));
                    }
                }

                // Monitorear dispositivos USB
                var dispositivosActuales = configuracion.GetUSBDevice()?.Select(d => d.Name + " " + d.Id).ToList();

                if (dispositivosActuales == null)
                {
                    Console.WriteLine("Error al obtener dispositivos.");
                    continue;
                }

                var dispositivosNuevos = dispositivosActuales.Except(listaDevice).ToList();
                var dispositivosQuitados = listaDevice.Except(dispositivosActuales).ToList();

                if (dispositivosNuevos.Any() || dispositivosQuitados.Any())
                {
                    if (dispositivosNuevos.Any())
                    {
                        mainForm.Invoke((MethodInvoker)(() =>
                        {
                            if (usbDesconecForm != null && !usbDesconecForm.IsDisposed)
                            {
                                usbDesconecForm.Close();
                                usbDesconecForm = null;
                            }

                            if (usbConecForm == null || usbConecForm.IsDisposed)
                            {
                                usbConecForm = new usbConec();
                                usbConecForm.Show();
                            }
                        }));
                    }
                    else
                    {
                        mainForm.Invoke((MethodInvoker)(() =>
                        {
                            if (usbConecForm != null && !usbConecForm.IsDisposed)
                            {
                                usbConecForm.Close();
                                usbConecForm = null;
                            }

                            if (usbDesconecForm == null || usbDesconecForm.IsDisposed)
                            {
                                usbDesconecForm = new usbDesconec();
                                usbDesconecForm.Show();
                            }
                        }));
                    }
                    /*if ()
                    {
                        Console.WriteLine("Nuevo dispositivo conectado: ");
                        usbConec usb = new usbConec();
                        mainForm.Invoke((MethodInvoker)(() =>
                            usb.Show()));
                    }

                    if (dispositivosQuitados.Any())
                    {
                        Console.WriteLine("Dispositivo desconectado: " );
                        usbDesconec noUsb = new usbDesconec();
                        mainForm.Invoke((MethodInvoker)(() =>
                            noUsb.Show()));
                    }*/

                    listaDevice = dispositivosActuales;
                }
            }
        }

        private static bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 2000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
