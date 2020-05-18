using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Bloque : Division
    {
        private List<Persona> personas = new List<Persona>();
        public Bloque(string name, Persona manager) : base(name, manager)
        {
        }

        public List<Persona> Personas { get => personas; set => personas = value; }
    }
}
