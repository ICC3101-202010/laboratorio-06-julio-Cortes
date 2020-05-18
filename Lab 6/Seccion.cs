using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Seccion : Division
    {
        private List<Bloque> bloques = new List<Bloque>();
        public Seccion(string sectionName, Persona sectionmanager) :base(sectionName, sectionmanager)
        {

        }

        public  List<Bloque> Bloques { get => bloques; set => bloques = value; }
    }
}
