using System;
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

namespace App_San_ignacio_Conection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var deviceClass = new DeviceClass();
            var getUSBDevices = deviceClass.GetUSBDevice();
            clearList();
            if (getUSBDevices != null)
            {
                foreach (var device in getUSBDevices)
                {
                    Console.WriteLine(device.Name + " " + device.Description + " " + device.Id);
                    listBox1.Items.Add(device.Name + " " + device.Id);
                }
            }
            else
            {
                Console.WriteLine("No se pudieron obtener los dispositivos iniciales.");
                MessageBox.Show("No se pudieron obtener los dispositivos iniciales.");
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
    }
}
