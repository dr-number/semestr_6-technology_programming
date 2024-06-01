using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarionovClassesMessages
{
    internal class MyFind
    {
        //var foundUnit = FindUnit(units, tanks, "Резервуар 2");

        Dictionary<string, Factories> factories = new Dictionary<string, Factories>();
        Dictionary<string, Units> units = new Dictionary<string, Units>();
        Dictionary<string, Tanks> tanks = new Dictionary<string, Tanks>();

        public void FindUnit(Dictionary<string, Units> units, Dictionary<string, Tanks> tanks, string find)
        {

        }
    }
}
