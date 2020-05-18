using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Area : Division
    {
        private List<Departamento> departamentos = new List<Departamento>();
        public Area(string name, Persona manager) : base(name, manager)
        {
        }

        public List<Departamento> Departamentos { get => departamentos; set => departamentos = value; }
    }
}
