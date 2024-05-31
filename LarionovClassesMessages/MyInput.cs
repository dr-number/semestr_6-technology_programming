﻿using System;
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
                else if (x <= 0 || x > maxValue)
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
        public List<Factories> InputFactories()
        {
            Console.WriteLine("Добавление заводов");
            Console.ResetColor();

            string FactoryName = "";
            string FactoryDescription = "";
            List<Factories> factories = new List<Factories>();
            while (true)
            {
                Console.WriteLine("Введите имя завода: [для завершения введите \"0\"]:");
                Console.ResetColor();
                FactoryName = Console.ReadLine()?.ToLower();
                if (FactoryName == "0")
                    break;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите описание завода: [для завершения введите \"0\"]:\n");
                Console.ResetColor();
                FactoryDescription = Console.ReadLine()?.ToLower();
                if (FactoryDescription == "0")
                    break;

                factories.Add(new(FactoryName, FactoryDescription));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Завод успешно добавлена!\n");
                Console.ResetColor();
            }
            return factories;
        }

        public List<Units> InputUnits(List<Factories> factories)
        {
            Console.WriteLine("Добавление установки");
            Console.ResetColor();

            string UnitName = "";
            string UnitDescription = "";
            int FactoryId = 0;
            int FactoriesCount = factories.Count;

            List<Units> units = new List<Units>();
            MyInput myInput = new MyInput();

            while (true)
            {
                Console.WriteLine("Введите имя установки: [для завершения введите \"0\"]:");
                Console.ResetColor();
                UnitName = Console.ReadLine()?.ToLower();
                if (UnitName == "0")
                    break;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите описание установки: [для завершения введите \"0\"]:\n");
                Console.ResetColor();
                UnitDescription = Console.ReadLine()?.ToLower();
                if (UnitDescription == "0")
                    break;

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < FactoriesCount; i++)
                    Console.WriteLine($"[{i}] - {factories[i].getInfo()}");

                FactoryId = myInput.InputCount("Выберите фабрику из предложенных вариантов: ", FactoriesCount);

                units.Add(new(UnitName, UnitDescription, FactoryId));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Фабрика успешно добавлена!\n");
                Console.ResetColor();
            }
            return units;
        }
    }

}
