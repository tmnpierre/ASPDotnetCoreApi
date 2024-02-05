namespace Demo01.Models
{
    public class Crepe
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Diameter { get; set; }

        public double Area => Math.PI * Math.Pow(Diameter/2,2);

        public double Perimeter => Math.PI * Diameter;

        public Topping Topping1 { get; set; }

        public Topping Topping2 { get; set; }
    }

    public enum Topping
    {
        Nutella, Sugar, Mayonnaise, Surimi, Camembert, BlueBerryJam, Oreo, Egg, MappleJuice
    }
}
