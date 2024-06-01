using System.Collections.Generic;

namespace LarionovClassesMessages
{
    internal class MyFind
    {
        public List<Units> FindUnit(Dictionary<string, Units> units, Dictionary<string, Tanks> tanks, string FindTankName)
        {
            List<Units> result = new List<Units>();

            if (!tanks.ContainsKey(FindTankName))
                return null;

            int UnitId = tanks[FindTankName].UnitId;
            foreach (var unit in units)
            {
                if (unit.Value.Id == UnitId)
                {
                    result.Add(unit.Value);
                }
            }
            return result;
        }

        public List<Factories> FindFactory(Dictionary<string, Factories> factories, Units unit)
        {
            List<Factories> result = new List<Factories>();

            foreach (var factory in factories)
            {
                if (factory.Value.Id == unit.FactoryId)
                {
                    result.Add(factory.Value);
                }
            }
            return result;
        }
    }
}
