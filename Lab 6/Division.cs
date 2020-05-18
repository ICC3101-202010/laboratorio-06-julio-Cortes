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

        public string Name { get => name; set => name = value; }
        public Persona Manager { get => manager; set => manager = value; }
        public Division(string name, Persona manager)
        {
            this.name = name;
            this.manager = manager;
        }
    }
}
