using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace App_San_ignacio_Conection.Configurations.Archive
{
    class ArchiveClass
    {
        private static string dbPath = "DataBase.db";
        private static string connectionString = $"Data Source={dbPath}";

        // Método para crear la base de datos y la tabla
        public static void CreateDatabase()
        {
            Console.WriteLine("Creando base de datos y tabla...");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS Devices (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    IP TEXT NOT NULL,
                    Nombre TEXT NOT NULL,
                    Descripcion TEXT NOT NULL,
                    Fecha TEXT NOT NULL

                );
            ";
                createTableCmd.ExecuteNonQuery();

                Console.WriteLine("Base de datos y tabla creadas (si no existían).");
            }
        }

        // Método para insertar una device
        public static void InsertarDevice(string ip, string nombre,string description,string fecha )
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Devices (IP,Nombre,Descripcion,Fecha) VALUES (@ip,@nombre,@description,@fecha)";
                insertCmd.Parameters.AddWithValue("@nombre", nombre);
                insertCmd.Parameters.AddWithValue("@ip", ip);
                insertCmd.Parameters.AddWithValue("@description", description);

                insertCmd.Parameters.AddWithValue("@fecha", fecha);

                int filasInsertadas = insertCmd.ExecuteNonQuery();

                Console.WriteLine($"Insertadas {filasInsertadas} fila(s) con el ip'{ip}'.");
            }
        }

        // Método para leer y mostrar todas las personas
        public static void GetDevice()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Devices";

                using (var reader = selectCmd.ExecuteReader())
                {
                    Console.WriteLine("Listado de Devices:");
                    while (reader.Read())
                    {
                        MessageBox.Show(reader.GetString(3));
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string ip = reader.GetString(2);
                        string description = reader.GetString(3);
                        string fecha= reader.GetString(4);
                        Console.WriteLine($"Id: {id}, Nombre: {nombre},description:{description},fecha:{fecha}");
                    }
                }
            }
        }
    }
}
