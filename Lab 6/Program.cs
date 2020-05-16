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
        private static Empresa Deserialize(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Empresa startup = (Empresa)formatter.Deserialize(stream);
            return startup;
        }
        private static void Serialize(Empresa empresa, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(stream, empresa);
        }
        private static Persona createPersona()
        {
            Console.WriteLine("Ingrese el nombre de la persona:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido de la persona:\n");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ingrese el rut de la persona:\n");
            string rut = Console.ReadLine();
            Console.WriteLine("Ingrese el cargo de la persona:\n");
            string charge = Console.ReadLine();
            Persona persona = new Persona(name, lastName, rut, charge);
            Console.Clear();
            return persona;
        }
        static void Main(string[] args)
        {
            bool check = false;

            while (!check)
            {

                Console.WriteLine("Desea cargar la informacion de la empresa mediante un archivo (Y/N)\n");
                string choice = Console.ReadLine();
                if (choice=="Y")
                {
                    check=true;
                    try
                    {
                        Empresa startup = Deserialize("Empresa.bin");
                        Console.WriteLine($"El nombre de la empresa es {startup.Name} y su rut es {startup.Rut}\n");
                        foreach (Division division in startup.Divisiones1)
                        {
                            Console.WriteLine($"El nombre de la divison: {division.Name} y su encargado es: {division.Manager.Name}\n" );
                            if (division.Personas.Count()!=0)
                            {
                                Console.WriteLine($"el personal del bloque {division.Name} es: ");
                                foreach (Persona persona in division.Personas)
                                {
                                    Console.WriteLine($"{persona.Name} {persona.LastName}");
                                }
                                Console.WriteLine("\n");
                            }

                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("No se encontro el archivo, porfavor ingrese los datos de una empresa\n");
                        Console.WriteLine("Ingrese el rut de la empresa:\n");
                        string rut = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la empresa:\n");
                        string name = Console.ReadLine();
                        Empresa startup = new Empresa(name, rut);
                        check = true;
                        Console.WriteLine("Ingrese el nombre de un departamento de la empresa: \n");
                        string departmentName = Console.ReadLine();
                        Console.WriteLine("Ingrese los datos del jefe del departamento:\n");
                        Departamento departamento = new Departamento(departmentName, createPersona());
                        startup.Divisiones1.Add(departamento);
                        Console.WriteLine("Ingrese el nombre de una seccion de la empresa: \n");
                        string sectionName = Console.ReadLine();
                        Seccion seccion = new Seccion(sectionName, createPersona());
                        Console.WriteLine("Ingrese los datos del jefe de la seccion:\n");
                        startup.Divisiones1.Add(seccion);
                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine("Ingrese el nombre de un bloque de la empresa: \n");
                            string blockName = Console.ReadLine();
                            Console.WriteLine("Ingrese los datos del jefe del bloque:\n");
                            Bloque block = new Bloque(blockName, createPersona());
                            for (int j = 0; j < 2; j++)
                            {
                                Console.WriteLine("Ingrese los datos de una persona que trabajara en el bloque: \n");
                                block.Personas.Add(createPersona());
                            }
                            startup.Divisiones1.Add(block);
                        }
                        Serialize(startup, "empresa.bin");
                        Console.WriteLine("Empresa serializada");
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
                    Console.WriteLine("Ingrese el nombre de un departamento de la empresa: \n");
                    string departmentName = Console.ReadLine();
                    Console.WriteLine("Ingrese los datos del jefe del departamento:\n");
                    Departamento departamento = new Departamento(departmentName, createPersona());
                    startup.Divisiones1.Add(departamento);
                    Console.WriteLine("Ingrese el nombre de una seccion de la empresa: \n");
                    string sectionName = Console.ReadLine();
                    Console.WriteLine("Ingrese los datos del jefe de la seccion:\n");
                    Seccion seccion = new Seccion(sectionName, createPersona());
                    startup.Divisiones1.Add(seccion);
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("Ingrese el nombre de un bloque de la empresa: \n");
                        string blockName = Console.ReadLine();
                        Console.WriteLine("Ingrese los datos del jefe del bloque\n");
                        Bloque block = new Bloque(blockName, createPersona());
                        for (int j = 0; j < 2; j++)
                        {
                            Console.WriteLine("Ingrese los datos de una persona que trabajara en el bloque: \n");
                            block.Personas.Add(createPersona());
                        }
                        startup.Divisiones1.Add(block);
                    }
                    Serialize(startup, "empresa.bin");
                    Console.WriteLine("Empresa serializada");

                }
                else
                {
                    Console.WriteLine("Opcion invalida\n");
                }
            }
            
        }
    }
}
