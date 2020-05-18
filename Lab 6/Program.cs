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
            try
            {
                Empresa startup = (Empresa)formatter.Deserialize(stream);
                return startup;

            }
            catch (SerializationException)
            {

                return null;
            }

        }
        private static void Serialize(Empresa empresa, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(stream, empresa);
            Console.WriteLine("Empresa serializada");
            stream.Close();
        }
        private static Persona CreatePersona()
        {
            Console.WriteLine("Ingrese el nombre de la persona:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido de la persona:\n");
            string lastName = Console.ReadLine();
            bool succes = false;
            int rut = 0;
            while (!succes)
            { 
                Console.WriteLine("Ingrese el rut de la persona sin puntos ni guion:\n");
                try
                {
                    rut = int.Parse(Console.ReadLine());
                    succes = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato invalido, intente nuevamente\n");
                }
            }
            Console.WriteLine("Ingrese el cargo de la persona:\n");
            string charge = Console.ReadLine();
            Persona persona = new Persona(name, lastName, rut, charge);
            Console.Clear();
            return persona;
        }
        private static void ShowCompany(Empresa empresa)
        {
            Console.WriteLine($"El nombre de la empresa es {empresa.Name} y su rut es {empresa.Rut}\n");
            try
            {
                foreach (Area area in empresa.Divisiones1)
                {
                    Console.WriteLine($"El nombre del area es: {area.Name} y su encargado es: {area.Manager.Name} {area.Manager.LastName}\n");
                    foreach (Departamento departamento in area.Departamentos)
                    {
                        Console.WriteLine($"El nombre del departamento: {departamento.Name} y su encargado es: {departamento.Manager.Name} {departamento.Manager.LastName}\n");
                        foreach (Seccion seccion in departamento.Seccions)
                        {
                            Console.WriteLine($"El nombre de la secciones: {seccion.Name} y su encargado es: {seccion.Manager.Name} {seccion.Manager.LastName}\n");
                            foreach (Bloque bloque in seccion.Bloques)
                            {
                                Console.WriteLine($"El nombre del bloque {seccion.Bloques.IndexOf(bloque)+1} es: {bloque.Name} y su encargado es: {bloque.Manager.Name} {bloque.Manager.LastName}\n");
                                foreach (Persona persona in bloque.Personas)
                                {
                                    Console.WriteLine($"Un trabajador del bloque es: {persona.Name} {persona.LastName}\n");
                                }

                            }
                        }
                    }
                }
            }
            catch (InvalidCastException)
            {
                foreach (Departamento departamento in empresa.Divisiones1)
                {
                    Console.WriteLine($"El nombre del departamento: {departamento.Name} y su encargado es: {departamento.Manager.Name} {departamento.Manager.LastName}\n");
                    foreach (Seccion seccion in departamento.Seccions)
                    {
                        Console.WriteLine($"El nombre de la secciones: {seccion.Name} y su encargado es: {seccion.Manager.Name} {seccion.Manager.LastName}\n");
                        foreach (Bloque bloque in seccion.Bloques)
                        {
                            Console.WriteLine($"El nombre del bloque {seccion.Bloques.IndexOf(bloque) + 1} es: {bloque.Name} y su encargado es: {bloque.Manager.Name} {bloque.Manager.LastName}\n");
                            foreach (Persona persona in bloque.Personas)
                            {
                                Console.WriteLine($"Un trabajador del bloque es: {persona.Name} {persona.LastName}\n");
                            }

                        }
                    }
                }
            }
        }
        private static Departamento CreateDepartment()
        {
            Console.WriteLine("Ingrese el nombre de un departamento de la empresa: \n");
            string departmentName = Console.ReadLine();
            Console.WriteLine("Ingrese los datos del jefe del departamento:\n");
            Departamento departamento = new Departamento(departmentName, CreatePersona());
            return departamento;
        }
        private static Seccion CreateSeccion()
        {
            Console.WriteLine("Ingrese el nombre de una seccion de la empresa: \n");
            string sectionName = Console.ReadLine();
            Seccion seccion = new Seccion(sectionName, CreatePersona());
            return seccion;
        }
        private static Bloque CreateBloque()
        {
            Console.WriteLine("Ingrese el nombre de un bloque de la empresa: \n");
            string blockName = Console.ReadLine();
            Console.WriteLine("Ingrese los datos del jefe del bloque:\n");
            Bloque block = new Bloque(blockName, CreatePersona());
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine("Ingrese los datos de una persona que trabajara en el bloque: \n");
                block.Personas.Add(CreatePersona());
            }
            return block;
        }
        private static void CreateEmpresa()
        {
            bool succes = false;
            int rut = 0;
            while (!succes)
            {
                Console.WriteLine("Ingrese el rut de la empresa sin puntos ni guion:\n");
                try
                {
                    rut = int.Parse(Console.ReadLine());
                    succes = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato invalido, intente nuevamente\n");
                }
            }
            Console.WriteLine("Ingrese el nombre de la empresa:\n");
            string name = Console.ReadLine();
            Empresa empresa = new Empresa(name, rut);
            Departamento departamento = CreateDepartment();
            Seccion seccion = CreateSeccion();
            Bloque bloque = CreateBloque();
            Bloque bloque1 = CreateBloque();

            seccion.Bloques.Add(bloque);
            seccion.Bloques.Add(bloque1);
            departamento.Seccions.Add(seccion);
            empresa.Divisiones1.Add(departamento);          
            Serialize(empresa, "empresa.bin");
        }
        static void Main(string[] args)
        {
            bool check = false;

            while (!check)
            {

                Console.WriteLine("Desea cargar la informacion de la empresa mediante un archivo (Y/N)\n");
                string choice = Console.ReadLine();
                if (choice == "Y")
                {
                    check = true;
                    try
                    {
                        Empresa empresa = Deserialize("empresa.bin");
                        if (empresa == null)
                        {
                            Console.WriteLine("El archivo no contenia informacion serializada, porfavor cree una empresa:\n ");
                            CreateEmpresa();
                        }
                        else
                        {
                            ShowCompany(empresa);
                        }

                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("No se encontro el archivo, porfavor ingrese los datos de una empresa\n");
                        CreateEmpresa();

                    }
                }
                else if (choice == "N")
                {
                    CreateEmpresa();
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
