using System;
using System.Text;
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
            List<Factories> factories = new List<Factories>();
            List<Units> units = new List<Units>();
            List<Tanks> tanks = new List<Tanks>();
            MyInput myInput = new MyInput();

            if (!IsQuestion("Хотите использовать данные поумолчанию? [y/n] (по умолчанию y): "))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ввод данных вручную:\n");
                factories = myInput.InputFactories();
                units = myInput.InputUnits(factories);
                tanks = myInput.InputTanks(units);
            }
            else
            {
                factories.Add(new("НПЗ№1", "Первый нефтеперерабатывающий завод"));
                factories.Add(new("НПЗ№1", "Первый нефтеперерабатывающий завод"));
                factories.Add(new("НПЗ№2", "Второй нефтеперерабатывающий завод"));

                units.Add(new("ГФУ-2", "Газофракционирующая установка", factories[0].Id));
                units.Add(new("АВТ-6", "Атмосферно-вакуумная трубчатка", factories[0].Id));
                units.Add(new("АВТ-10", "Атмосферно-вакуумная трубчатка", factories[1].Id));

                tanks.Add(new("Резервуар 1", "Надземный - вертикальный", 1500, 2000, units[0].Id));
                tanks.Add(new("Резервуар 2", "Надземный - горизонтальный", 2500, 3000, units[0].Id));
                tanks.Add(new("Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, units[1].Id));
                tanks.Add(new("Резервуар 35", "Надземный - вертикальный", 3000, 3000, units[1].Id));
                tanks.Add(new("Резервуар 47", "Подземный - двустенный", 4000, 5000, units[1].Id));
                tanks.Add(new("Резервуар 256", "Подводный", 500, 500, units[2].Id));
            }

            Console.WriteLine("Factories:\n");
            foreach (Factories factory in factories)
                Console.WriteLine(factory.getInfo());

            Console.WriteLine("\nUnits:");
            foreach (Units unit in units)
                Console.WriteLine(unit.getInfo());

            Console.WriteLine("\nTanks:\n");
            foreach (Tanks tank in tanks)
                Console.WriteLine(tank.getInfo());
        }
    }
}
