using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarionovClassesMessages
{
    internal class MyInput
    {
        public int InputCount(string text, int maxValue)
        {
            string xStr = "";
            bool isNumber = false;
            int x = 0;
            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);
                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);
                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x < 0 || x > maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от 0 до {maxValue} включительно!\n");
                }
                else
                    break;
            }
            return x;
        }
        public int InputData(string text)
        {
            string xStr = "";
            bool isNumber = false;
            int x = 0;
            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);
                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);
                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else
                    break;
            }
            return x;
        }

        public Dictionary<string, Factories> InputFactories()
        {
            MyPrint myPrint = new MyPrint();
            myPrint.PrintSuccess("Добавление заводов");

            string FactoryName = "";
            string FactoryDescription = "";
            Dictionary<string, Factories> factories = new Dictionary<string, Factories>();
            while (true)
            {
                myPrint.PrintSuccess("Введите имя завода: [для завершения введите \"0\"]:");
                FactoryName = Console.ReadLine()?.ToLower();
                if (FactoryName == "0")
                    break;

                if (factories.ContainsKey(FactoryName))
                {
                    myPrint.PrintError("Завод с таким именем уже существует!\n");
                    continue;
                }

                myPrint.PrintSuccess("Введите описание завода: [для завершения введите \"0\"]:\n");
                FactoryDescription = Console.ReadLine()?.ToLower();
                if (FactoryDescription == "0")
                    break;

                factories.Add(FactoryName, new(FactoryName, FactoryDescription));
                myPrint.PrintSuccess("Завод успешно добавлена!\n");
            }
            return factories;
        }

        public Dictionary<string, Units> InputUnits(Dictionary<string, Factories> factories)
        {
            MyPrint myPrint = new MyPrint();
            myPrint.PrintSuccess("Добавление установки");

            string UnitName = "";
            string UnitDescription = "";
            int FactoryIndex = 0;
            int FactoriesCount = factories.Count;

            Dictionary<string, Units> units = new Dictionary<string, Units>();
            MyInput myInput = new MyInput();

            while (true)
            {
                myPrint.PrintSuccess("Введите имя установки: [для завершения введите \"0\"]:");
                UnitName = Console.ReadLine()?.ToLower();
                if (UnitName == "0")
                    break;

                if (units.ContainsKey(UnitName))
                {
                    myPrint.PrintError("Установка с таким именем уже существует!\n");
                    continue;
                }

                myPrint.PrintSuccess("Введите описание установки: [для завершения введите \"0\"]:\n");
                UnitDescription = Console.ReadLine()?.ToLower();
                if (UnitDescription == "0")
                    break;

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < FactoriesCount; i++)
                    Console.WriteLine($"[{i}] - {factories.ElementAt(i).Value.getInfo()}");

                FactoryIndex = myInput.InputCount("Выберите фабрику из предложенных вариантов: ", FactoriesCount-1);

                units.Add(UnitName, new(UnitName, UnitDescription, factories.ElementAt(FactoryIndex).Value.Id));
                myPrint.PrintSuccess("Установка успешно добавлена!\n");
            }
            return units;
        }

        public Dictionary<string, Tanks> InputTanks(Dictionary<string, Units> units)
        {
            MyPrint myPrint = new MyPrint();
            myPrint.PrintSuccess("Добавление установки");

            string TankName = "";
            string TankDescription = "";
            int MaxVolume = 0;
            int Volume = 0;
            int UnitIndex = 0;
            int UnitsCount = units.Count;

            Dictionary<string, Tanks> tanks = new Dictionary<string, Tanks>();
            MyInput myInput = new MyInput();

            while (true)
            {
                myPrint.PrintSuccess("Введите имя резервуара: [для завершения введите \"0\"]:");
                TankName = Console.ReadLine()?.ToLower();
                if (TankName == "0")
                    break;

                if (tanks.ContainsKey(TankName))
                {
                    myPrint.PrintError("Резервуар с таким именем уже существует!\n");
                    continue;
                }

                myPrint.PrintSuccess("Введите описание резервуара: [для завершения введите \"0\"]:\n");
                TankDescription = Console.ReadLine()?.ToLower();
                if (TankDescription == "0")
                    break;

                MaxVolume = myInput.InputData($"Введите MaxVolume для резервуара \"{TankName}\": ");
                Volume = myInput.InputCount($"Введите Volume для резервуара \"{TankName}\": ", MaxVolume);

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < UnitsCount; i++)
                    Console.WriteLine($"[{i}] - {units.ElementAt(i).Value.getInfo()}");

                UnitIndex = myInput.InputCount("Выберите установку из предложенных вариантов: ", UnitsCount-1);

                tanks.Add(TankName, new(TankName, TankDescription, Volume, MaxVolume, units.ElementAt(UnitIndex).Value.Id));
                myPrint.PrintSuccess("Резервуар успешно добавлен!\n");
            }
            return tanks;
        }
    }

}
