using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Departamento : Division
    {
        public Departamento(string name, Persona manager):base(name,manager)
            {          
                
            }

    }
}
