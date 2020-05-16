using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Division
    {
        protected string name;
        protected Persona manager;
        protected List<Persona> personas = new List<Persona>();

        public string Name { get => name; set => name = value; }
        public List<Persona> Personas { get => personas; set => personas = value; }
        public Persona Manager { get => manager; set => manager = value; }
        public Division(string name, Persona manager)
        {
            this.name = name;
            this.manager = manager;
        }
    }
}
