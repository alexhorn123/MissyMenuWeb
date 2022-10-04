using DynamicVML;
using DynamicVML.Extensions;
using Microsoft.AspNetCore.Mvc;
using MissyMenu.Service;
using MissyMenuWeb.Service;
using MissyMenuWeb.ViewModels;

using Newtonsoft.Json;


namespace MissyMenuWeb.Controllers
{
    public class RecipesController : Controller
    {
        // GET: RecipesController
        private readonly RecipesClient api = new("https://localhost:7202/",new HttpClient());
        private readonly DropDownFactory factory = new DropDownFactory();


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

        public async Task<IActionResult> AddIngredientAsync(AddNewDynamicItem parameters)
        {
            GlobalClient gapi = new(new HttpClient());
            IngredientViewModel newIngredientViewModel = new();
            List<Global> globals = (List<Global>)await gapi.GlobalAllAsync();
            newIngredientViewModel.Globals = (List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)factory.CreateSelectListItem(globals, "Market dropdown value");
            return this.PartialView(newIngredientViewModel, parameters);
        }


        public IActionResult AddDirection(AddNewDynamicItem parameters)
        {
            DirectionViewModel newDirectionViewModel = new();
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
