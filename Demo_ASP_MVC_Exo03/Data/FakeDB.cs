using Demo_ASP_MVC_Exo03.Models;

namespace Demo_ASP_MVC_Exo03.Data
{
    public static class FakeDB
    {
        public static class RecipeData
        {
            private static List<Recipe> _Recipes = new List<Recipe>
            {
                new Recipe()
                {
                    Id = Guid.NewGuid(),
                    Name = "Les frites belges",
                    Origin = "Belgique",
                    Description = "La frite est un bâtonnet de pomme de terre cuit par friture dans une graisse animale ou une huile végétale. Les appellations « pomme frite » et « patate frite » sont utilisées indifféremment pour ce bâtonnet, pour une tranche ou pour une rondelle du même végétal cuit de cette façon.",
                    RecipeType = RecipeType.Meal,
                    Ingredients = new List<string>
                    {
                        "Pomme de terre (Bintje)",
                        "Graisse de boeuf"
                    }
                },
                new Recipe()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pizza Margherita",
                    Origin = "Naples (Italie)",
                    Description = "La pizza Margherita est une spécialité culinaire traditionnelle de la ville de Naples, en Italie.",
                    RecipeType = RecipeType.Meal,
                    Ingredients = new List<string>
                    {
                        "Pate à Pizza",
                        "Tomate",
                        "Mozzarella",
                        "Basilic frais",
                        "Sel",
                        "Huile d'olive"
                    }
                }
            };

            public static IEnumerable<Recipe> GetAll()
            {
                return _Recipes.AsReadOnly();
            }

            public static Recipe? GetOne(Guid id)
            {
                return _Recipes.SingleOrDefault(p => p.Id == id);
            }

            public static void Add(Recipe recipe)
            {
                recipe.Id = Guid.NewGuid();
                _Recipes.Add(recipe);
            }

            public static void Delete(Guid id)
            {
                _Recipes.RemoveAll(p => p.Id == id);
            }
        }
    }
}
