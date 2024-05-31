using System.Threading;

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
}
