using Demo01.Models;

namespace Demo01.Data
{
    public class CrepeFakeDb
    {
        public List<Crepe> Crepes { get; set; } = new List<Crepe>
        {
            new Crepe()
            {
                Id = 1,
                Name = "Surprise du chef",
                IsSalty = true,
                Diameter = 14,
                Topping1 = Topping.Camembert,
                Topping2 = Topping.MappleJuice,
            },
            new Crepe()
            {
                Id = 2,
                Name = "Fuit de la mer",
                IsSalty = true,
                Diameter = 14,
                Topping1 = Topping.Surimi,
                Topping2 = Topping.Nutella,
            }
        };
    }
}
