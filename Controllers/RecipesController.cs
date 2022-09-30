using DynamicVML;
using DynamicVML.Extensions;
using Microsoft.AspNetCore.Mvc;
using MissyMenu.Service;
using MissyMenuWeb.ViewModels;

using Newtonsoft.Json;


namespace MissyMenuWeb.Controllers
{
    public class RecipesController : Controller
    {
        // GET: RecipesController
        private readonly RecipesClient api = new("https://localhost:7202/",new HttpClient());
        private object ingredient;

        public async Task<ActionResult> Index()
        {
            //var recipeList = (List<Recipe>)await api.RecipesAllAsync();
            //return View(recipeList);
            return View(await api.RecipesAllAsync());
        }



        // GET: RecipesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var recipe = await api.RecipesGETAsync(id);
            return View(recipe);
        }

        // GET: RecipesController/Create
        //public ActionResult Create(AddNewDynamicItem parameters)
        //{

        //    ICollection<Ingredient> ingredients = new List<Ingredient>();
        //    Ingredient ingredient = new Ingredient();
        //    ingredient.IngredientName = "Add Ingredient Name";
        //    ingredient.Link = "Add Web Link";
        //    ingredient.Measurement = "Add Measurement";
        //    ingredient.Note = "Add Ingredient Note";
        //    ingredients.Add(ingredient);
        //    ICollection<Direction> directions = new List<Direction>();
        //    Direction direction = new Direction();
        //    direction.Step = "Prepartion Step";
        //    directions.Add(direction);
        //    //recipe.Ingredients = ingredients;
        //    var recipeViewModel = new Recipe()
        //    {
        //        Name = "New Recipe",
        //        Ingredients = ingredients,
        //        Directions = directions
        //    };

        //    return this.PartialView(recipeViewModel, parameters);
        //}

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View(new RecipeViewModel());
        }

        public IActionResult AddIngredient(AddNewDynamicItem parameters)
        {
            IngredientViewModel newIngredientViewModel = new();
            return this.PartialView(newIngredientViewModel, parameters);
        }


        public IActionResult AddDirection(AddNewDynamicItem parameters)
        {
            // This is the GET action that will be called whenever the user clicks 
            // the "Add new item" link in a DynamicList view. It accepts a an object
            // of the class ListItemParameters that contains information about where
            // the item needs to be inserted (i.e. the id of the div to where contents 
            // as well as the path to your viewmodels in the main form). All of those
            // are computed automatically from the view by the library.

            // Now here you can create another view model for your model
            var newDirectionViewModel = new Direction
            {
                Step = "Preparation Step"
            };

            // Now you have to call the extension PartialView method passing the view model.
            // This is an extension method that creates a partial view with the needed HTML 
            // prefix for the fields in your form so the form will post correctly when it 
            // gets submitted.
            return this.PartialView(newDirectionViewModel, parameters);
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {

            var stuff = JsonConvert.SerializeObject(collection);
            Recipe recipe = JsonConvert.DeserializeObject<Recipe>(stuff);


                await api.RecipesPOSTAsync(recipe);
            return View();
        }

        // GET: RecipesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var recipe = await api.RecipesGETAsync(id);
            return View(recipe);
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
