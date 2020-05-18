using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Empresa
    {
        private List<Division> Divisiones = new List<Division>();
        public Empresa()
        {

        }
        public Empresa(string name, int rut)
        {
            this.Name = name;
            this.Rut = rut;
        }
        private string name=null;
        private int rut = 0;

        public string Name { get => name; set => name = value; }
        public int Rut { get => rut; set => rut = value; }
        internal List<Division> Divisiones1 { get => Divisiones; set => Divisiones = value; }
    }
}
