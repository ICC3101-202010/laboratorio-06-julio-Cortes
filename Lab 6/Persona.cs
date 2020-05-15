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
        string name;
        string lastName;
        string rut;
        string charge;
    }
}
