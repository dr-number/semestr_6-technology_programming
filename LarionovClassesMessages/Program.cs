using System;
using System.Collections.Generic;

namespace LarionovClassesMessages
{
    class Program
    {
        static public bool IsQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }
        static void Main(string[] args)
        {
            Dictionary<string, Factories> factories = new Dictionary<string, Factories>();
            Dictionary<string, Units> units = new Dictionary<string, Units>();
            Dictionary<string, Tanks> tanks = new Dictionary<string, Tanks>();
            MyInput myInput = new MyInput();
            MyPrint myPrint = new MyPrint();

            if (!IsQuestion("Хотите использовать данные поумолчанию? [y/n] (по умолчанию y): "))
            {
                myPrint.PrintSuccess("Ввод данных вручную:\n");
                factories = myInput.InputFactories();
                units = myInput.InputUnits(factories);
                tanks = myInput.InputTanks(units);
            }
            else
            {
                factories.Add("НПЗ№1", new("НПЗ№1", "Первый нефтеперерабатывающий завод"));
                factories.Add("НПЗ№2", new("НПЗ№2", "Второй нефтеперерабатывающий завод"));

                units.Add("ГФУ-2", new("ГФУ-2", "Газофракционирующая установка", factories["НПЗ№1"].Id));
                units.Add("АВТ-6", new("АВТ-6", "Атмосферно-вакуумная трубчатка", factories["НПЗ№1"].Id));
                units.Add("АВТ-10", new("АВТ-10", "Атмосферно-вакуумная трубчатка", factories["НПЗ№2"].Id));

                tanks.Add("Резервуар 1", new("Резервуар 1", "Надземный - вертикальный", 1500, 2000, units["ГФУ-2"].Id));
                tanks.Add("Резервуар 2", new("Резервуар 2", "Надземный - горизонтальный", 2500, 3000, units["ГФУ-2"].Id));
                tanks.Add("Дополнительный резервуар 24", new("Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, units["АВТ-6"].Id));
                tanks.Add("Резервуар 35", new("Резервуар 35", "Надземный - вертикальный", 3000, 3000, units["АВТ-6"].Id));
                tanks.Add("Резервуар 47", new("Резервуар 47", "Подземный - двустенный", 4000, 5000, units["АВТ-6"].Id));
                tanks.Add("Резервуар 256", new("Резервуар 256", "Подводный", 500, 500, units["АВТ-10"].Id));
            }

            myPrint.PrintSuccess($"Заводы ({factories.Count}):");
            foreach (var factory in factories)
                Console.WriteLine(factory.Value.getInfo());

            myPrint.PrintSuccess($"\nУстановки ({units.Count}):");
            foreach (var unit in units)
                Console.WriteLine(unit.Value.getInfo());

            myPrint.PrintSuccess($"\nРезервуары ({tanks.Count}):");
            foreach (var tank in tanks)
                Console.WriteLine(tank.Value.getInfo());
        }
    }
}
