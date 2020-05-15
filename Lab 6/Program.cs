using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = false;
            BinaryFormatter formatter = new BinaryFormatter();
            while (!check)
            {

                Console.WriteLine("Desea cargar la informacion de la empresa mediante un archivo (Y/N)\n");
                string choice = Console.ReadLine();
                if (choice=="Y")
                {
                    check=true;
                    try
                    {
                        Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                        Empresa startup = (Empresa)formatter.Deserialize(stream);
                        stream.Close();
                    }
                    catch (FileNotFoundException)
                    {

                        Console.WriteLine("El archivo no existe\nIngrese el rut de la empresa:\n");
                        string rut=Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la empresa:\n");
                        string name = Console.ReadLine();
                        Empresa startup = new Empresa(name, rut);

                    }
  
                }
                else if (choice=="N")
                {
                    Console.WriteLine("Ingrese el rut de la empresa:\n");
                    string rut = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre de la empresa:\n");
                    string name = Console.ReadLine();
                    Empresa startup = new Empresa(name, rut);
                    check = true;
                }
                else
                {
                    Console.WriteLine("Opcion invalida\n");
                }
            }
            
        }
    }
}
