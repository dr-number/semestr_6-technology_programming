using System;
using System.Collections.Generic;
using System.Linq;

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
            string FindTankName = "";
            bool IsFind = true;

            Dictionary<string, Factories> factories = new Dictionary<string, Factories>();
            Dictionary<string, Units> units = new Dictionary<string, Units>();
            Dictionary<string, Tanks> tanks = new Dictionary<string, Tanks>();
            MyInput myInput = new MyInput();
            MyPrint myPrint = new MyPrint();
            MyCalc myCalc = new MyCalc();
            MyFind myFind = new MyFind();
            List<Units> FindUnits;
            List<Factories> FindFactories = new List<Factories>();

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

            myPrint.PrintSuccess($"\nОбщий объем резервуаров: {myCalc.GetAllVolumeTanks(tanks)}\n");

            while (IsFind)
            {
                myPrint.PrintWarning($"Введите имя резервуара (чувствительно к регистру) чтобы получить по нему информацию (чтобы прекратить поиск введите \"0\")\n");
                FindTankName = Console.ReadLine();

                if (FindTankName == "0")
                    break;

                FindUnits = myFind.FindUnit(units, tanks, FindTankName);

                if (FindUnits == null)
                {
                    myPrint.PrintError($"Резервуар с именем \"{FindTankName}\" - не найден");
                    continue;
                }

                foreach (var unit in units)
                    FindFactories.AddRange(myFind.FindFactory(factories, unit.Value));

                myPrint.PrintWarning("Найденные результаты:");

                FindFactories = FindFactories.Distinct().ToList();
                myPrint.PrintSuccess($"Заводы ({FindFactories.Count}):");
                foreach (var factory in FindFactories)
                    Console.WriteLine(factory.getInfo());

                FindUnits = FindUnits.Distinct().ToList();
                myPrint.PrintSuccess($"Установки ({FindUnits.Count}):");
                foreach (var unit in FindUnits)
                    Console.WriteLine(unit.getInfo());
            }
        }
    }
}
