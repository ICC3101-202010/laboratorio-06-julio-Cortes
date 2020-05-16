using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    class Empresa
    {
        private List<Division> Divisiones = new List<Division>();
        public Empresa()
        {

        }
        public Empresa(string name, string rut)
        {
            this.Name = name;
            this.Rut = rut;
        }
        private string name=null;
        private string rut = null;

        public string Name { get => name; set => name = value; }
        public string Rut { get => rut; set => rut = value; }
        internal List<Division> Divisiones1 { get => Divisiones; set => Divisiones = value; }
    }
}
