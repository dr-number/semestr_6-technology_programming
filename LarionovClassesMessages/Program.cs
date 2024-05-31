using System;
using System.Threading;
using System.Text;
using System.Collections.Generic;

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

            if (!IsQuestion("Хотите использовать данные поумолчанию? [y/n] (по умолчанию y): "))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ввод данных вручную:\n");
                Console.WriteLine("Добавление фабрик");
                Console.ResetColor();

                string FactoryName = "";
                string FactoryDescription = "";
                while (true)
                {
                    Console.WriteLine("Введите имя фабрики: [для завершения введите \"0\"]:");
                    Console.ResetColor();
                    FactoryName = Console.ReadLine()?.ToLower();
                    if (FactoryName == "0")
                        break;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Введите описание фабрики: [для завершения введите \"0\"]:\n");
                    Console.ResetColor();
                    FactoryDescription = Console.ReadLine()?.ToLower();
                    if(FactoryDescription == "0")
                        break ;

                    factories.Add(new(FactoryName, FactoryDescription));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Фабрика успешно добавлена!\n");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введенные фабрики:\n");
                foreach (Factories factory in factories)
                    Console.WriteLine(factory.getInfo());
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
