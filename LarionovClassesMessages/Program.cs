using System;
using System.Threading;
using System.Text;

namespace LarionovClassesMessages
{

    class Factories
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Factories(string name, string description)
        {
            Id = Interlocked.Increment(ref nextId);
            Name = name;
            Description = description;
        }

        public string getInfo()
        {
            return $"ID: {Id}, Name: {Name}, Description: {Description}";
        }
    }

    class Units
    {
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        private int FactoryId { get; }

        public Units(string name, string description, int factoryId)
        {
            Id = Interlocked.Increment(ref nextId);
            Name = name;
            Description = description;
            FactoryId = factoryId;
        }

        public string getInfo()
        {
            return $"ID: {Id}, Name: {Name}, Description: {Description}, FactoryId: {FactoryId}";
        }
    }

    class Tanks
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        private int Volume { get; set; }
        private int MaxVolume;
        private int UnitId { get; }

        public Tanks(string name, string description, int volume, int maxVolume, int unitId)
        {
            Id = Interlocked.Increment(ref nextId);
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            UnitId = unitId;
        }
        public int GetMaxVolume()
        {
            return MaxVolume;
        }
        public string getInfo()
        {
            return $"ID: {Id}, Name: {Name}, Description: {Description}, Volume: {Volume}, MaxVolume: {MaxVolume}, UnitId: {UnitId}";
        }
    }

    class MyInput
    {
        public int InputCount(string text, int maxValue, int defaultValue)
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
                if (xStr == "")
                    return defaultValue;
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Factories factory1 = new("НПЗ№1", "Первый нефтеперерабатывающий завод");
            Factories factory2 = new("НПЗ№2", "Второй нефтеперерабатывающий завод");

            Console.WriteLine(factory1.getInfo());
            Console.WriteLine(factory2.getInfo());

            Units unit1 = new("ГФУ-2", "Газофракционирующая установка", factory1.Id);
            Units unit2 = new("АВТ-6", "Атмосферно-вакуумная трубчатка", factory1.Id);
            Units unit3 = new("АВТ-10", "Атмосферно-вакуумная трубчатка", factory2.Id);

            Console.WriteLine(unit1.getInfo());
            Console.WriteLine(unit2.getInfo());

            Tanks tank1 = new("Резервуар 1", "Надземный - вертикальный", 1500, 2000, unit1.Id);
            Tanks tank2 = new("Резервуар 2", "Надземный - горизонтальный", 2500, 3000, unit1.Id);
            Tanks tank3 = new("Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, unit2.Id);
            Tanks tank4 = new("Резервуар 35", "Надземный - вертикальный", 3000, 3000, unit2.Id);
            Tanks tank5 = new("Резервуар 47", "Подземный - двустенный", 4000, 5000, unit2.Id);
            Tanks tank6 = new("Резервуар 256", "Подводный", 500, 500, unit3.Id);

            Console.WriteLine(tank1.getInfo());
            Console.WriteLine(tank2.getInfo());
            Console.WriteLine(tank3.getInfo());
            Console.WriteLine(tank4.getInfo());
            Console.WriteLine(tank5.getInfo());
            Console.WriteLine(tank6.getInfo());
        }
    }
}
