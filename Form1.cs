using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_San_ignacio_Conection.Configurations;
using System.Net;
using App_San_ignacio_Conection.Configurations.Network;
using System.Text.RegularExpressions;

namespace App_San_ignacio_Conection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.BackColor = Color.LimeGreen;
            //this.TransparencyKey= Color.LimeGreen;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string patron = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";
            if (Regex.IsMatch(textBox1.Text.Trim(), patron))
            {
                textBox1.BackColor = Color.LightGreen;
                var deviceClass = new DeviceClass();

                //int index = textBox1.Text.IndexOf('.');

                string[] partes = textBox1.Text.Split('.');

                // La parte "101" está en el índice 2 (tercer segmento)
           
                    string valor = partes[2];
              //  MessageBox.Show(partes[0]+"." + partes[1]+"." +valor+".");
                    Console.WriteLine(valor);  // Salida: 101




                var data = NetworkClass.GetHostName(textBox1.Text.ToString());
                MessageBox.Show(data);

                var dataNetwork = NetworkClass.ScanNetwork(partes[0] + "." + partes[1] + "." + valor + ".", 1, 254);
                //NetworkClass.GetHostName("192.168.101.2");
                var getUSBDevices = deviceClass.GetUSBDevice();
                string ruta = "C:\\Users\\Usuario\\Desktop\\config.txt";
                var a = new ConfiguracionClass();
                a.Configuracion(ruta);
                //ConfiguracionClass.GuardarConfiguracion("/c/Users/Usuario/Desktop",true, "192.168.1.1");
                clearList();
                if (getUSBDevices != null)
                {
                    foreach (var device in dataNetwork)
                    {
                        Console.WriteLine(device);
                        listBox1.Items.Add(NetworkClass.GetHostName(device)+ " "+device);
                    }
                }
                else
                {
                    Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
                    MessageBox.Show("No se pudieron obtener los dispositivos iniciales.");
                }


                MessageBox.Show(textBox1.Text+" "+"Ip valida");



            }
            else
            {
                textBox1.BackColor = Color.LightPink;
                MessageBox.Show(textBox1.Text + " "+ "Ip no valida");
            }
            
                

 
        }
        private void clearList()
        {
            listBox1.Items.Clear();
        }
        //DeviceClass.SearchDevices();
            //Scanner();
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MessageBox.Show("El dispositivo " + listBox1.SelectedItem.ToString() + " está conectado");
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string patron = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";
            if (Regex.IsMatch(textBox1.Text.Trim(), patron))
            {
                textBox1.BackColor = Color.LightGreen;
            }
            else
            {
                textBox1.BackColor = Color.LightPink;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();
            string patron = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";
            if (Regex.IsMatch(ip, patron))
            {
                MessageBox.Show("IP válida");
            }
            else
            {
                MessageBox.Show("IP no válida. Ingrese una dirección IPv4 correcta.");
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var getUSBDevices = new DeviceClass();
            
            string ruta = "C:\\Users\\Usuario\\Desktop\\config.txt";
            var a = new ConfiguracionClass();
            a.Configuracion(ruta);
            //ConfiguracionClass.GuardarConfiguracion("/c/Users/Usuario/Desktop",true, "192.168.1.1");
            clearList();
            if (getUSBDevices != null)
            {
                foreach (var device in getUSBDevices.GetUSBDevice())
                {
                    Console.WriteLine(device);
                    listBox1.Items.Add(device.Name);
                }
            }
            else
            {
                Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
                MessageBox.Show("No se pudieron obtener los dispositivos iniciales.");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizando funcionalidad");
        }
    }
}
