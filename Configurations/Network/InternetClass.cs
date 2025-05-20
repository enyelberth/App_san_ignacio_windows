using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_San_ignacio_Conection.Configurations.Network
{
    class InternetClass
    {
        public string IpAddress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; }

        public InternetClass(string ipAddress, string name, string description = "")
        {
            this.IpAddress = ipAddress;
            this.Name = name;
            this.Description = description;
            this.Fecha = DateTime.Now;
        }
    }
}
