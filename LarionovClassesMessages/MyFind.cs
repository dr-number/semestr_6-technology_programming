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

        MyPrint myPrint = new MyPrint();

        public List<Units> FindUnit(Dictionary<string, Units> units, Dictionary<string, Tanks> tanks, string find)
        {
            List<Units> result = new List<Units>();

            if (!tanks.ContainsKey(find))
            {
                myPrint.PrintError($"Резервуар с именем \"{find}\" - не найден");
                return null;
            }
            int UnitId = tanks[find].UnitId;
            foreach (var unit in units)
            {
                if (unit.Value.Id == UnitId)
                {
                    result.Add(unit.Value);
                }
            }
            return result;
        }
    }
}
