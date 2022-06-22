using Demo_ASP_MVC_Exo03.Data;
using Demo_ASP_MVC_Exo03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_Exo03.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Recipe> recipes = FakeDB.RecipeData.GetAll();
            return View(recipes);
        }

        public IActionResult Details([FromRoute] Guid id)
        {
            Recipe? recipe = FakeDB.RecipeData.GetOne(id);

            if(recipe is null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        public IActionResult Add()
        {
            return View(new RecipeForm());
        }

        [HttpPost]
        public IActionResult Add(RecipeForm recipeForm)
        {
            if(!ModelState.IsValid)
            {
                return View(recipeForm);
            }

            Recipe recipe = new Recipe
            {
                Name = recipeForm.Name,
                Origin = recipeForm.Origin,
                RecipeType = (RecipeType)recipeForm.RecipeType,
                Description = recipeForm.Description,
                Ingredients = recipeForm.Ingredients
            };
            FakeDB.RecipeData.Add(recipe);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete([FromRoute] Guid id)
        {
            FakeDB.RecipeData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
