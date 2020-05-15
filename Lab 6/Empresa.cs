using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Empresa
    {
        public Empresa()
        {

        }
        public Empresa(string name, string rut)
        {
            this.name = name;
            this.rut = rut;
        }
        string name=null;
        string rut = null;
    }
}
