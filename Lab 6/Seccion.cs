using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    class Seccion : Division
    {
        private string sectionName;
        private string sectionManagerName;

        public Seccion(string sectionName, Persona sectionmanager) :base(sectionName, sectionmanager)
        {

        }
    }
}
