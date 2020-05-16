using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Persona
    {
        public Persona(string name, string lastName, string rut, string charge)
        {
            this.name = name;
            this.lastName = lastName;
            this.rut = rut;
            this.charge = charge;

        }
        private string name;
        private string lastName;
        private string rut;
        private string charge;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Charge { get => charge; set => charge = value; }
    }
}
