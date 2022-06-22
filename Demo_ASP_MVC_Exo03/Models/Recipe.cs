using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_Exo03.Models
{
    public enum RecipeType
    {
        [Display(Name = "Entrée")] Entree,
        [Display(Name= "Plat")] Meal,
        [Display(Name = "Dessert")] Dessert,
        [Display(Name = "Apéro")] Aperitif
    }

    public class Recipe
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Origine")]
        public string? Origin { get; set; }

        [DisplayName("Type")]
        public RecipeType RecipeType { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Ingrédients")]
        public IEnumerable<string> Ingredients { get; set; }
    }

    public class RecipeForm
    {
        [Required]
        [DisplayName("Nom de la recette")]
        public string Name { get; set; }

        [DisplayName("Origine")]
        public string? Origin { get; set; }

        [Required]
        [DisplayName("Type")]
        public RecipeType? RecipeType { get; set; }

        [Required]
        [StringLength(1_000, MinimumLength = 20)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Liste d'ingrédients")]
        public IEnumerable<string> Ingredients { get; set; }
    }
}
