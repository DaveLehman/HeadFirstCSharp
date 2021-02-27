using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JSONSerialization
{

    class Guy
    {
        public string Name { get; set; }
        public HairStyle Hair {get;set;}
        public Outfit Clothes { get; set; }
        public override string ToString() => $"{Name} with {Hair} wearing {Clothes}";

    }
    class Outfit
    {
        public string Top { get; set; }
        public string Bottom { get; set; }
        public override string ToString() => $"{Top} and {Bottom}";

    }

    enum HairColor
    {
        Auburn, Black, Blonde, Blue, Brown, Gray, Platinum, Purple, Red, White
    }
    
    class HairStyle
    {
        public HairColor Color { get; set; }
        public float Length { get; set; }
        public override string ToString() => $"{Length:0.0} inch {Color} hair";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph of objects to serialize
            var guys = new List<Guy>()
            {
                new Guy() {Name="Bob", Clothes= new Outfit() {Top="t-shirt", Bottom="jeans"}, Hair = new HairStyle() {Color=HairColor.Red, Length = 3.5f}},
                new Guy() {Name="Joe", Clothes= new Outfit() {Top="polo", Bottom="slacks"}, Hair = new HairStyle() {Color=HairColor.Gray, Length = 2.7f}},
            };

            var options = new JsonSerializerOptions() { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(guys, options);
            Console.WriteLine(jsonString);

            var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
            foreach (var guy in copyOfGuys)
                Console.WriteLine("I deserialized this Guy: {0}", guy);
        }
    }
}
