using DynamicVML;
using DynamicVML.Extensions;
using Microsoft.AspNetCore.Mvc;
using MissyMenu.Service;
using MissyMenuWeb.Service;
using MissyMenuWeb.ViewModels;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;


namespace MissyMenuWeb.Controllers
{
    public class RecipesController : Controller
    {
        // GET: RecipesController
        private readonly RecipesClient _api = new("https://localhost:7202/",new HttpClient());
        private readonly DropDownFactory _factory = new();



        public async Task<ActionResult> Index()
        {
            return View(await _api.RecipesAllAsync());
        }



        // GET: RecipesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var recipe = await _api.RecipesGETAsync(id);
            return View(recipe);
        }

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
            newIngredientViewModel.Globals = (List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)_factory.CreateSelectListItem(globals, "Market dropdown value");
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
        public async Task<ActionResult> Create(RecipeViewModel recipeViewModel)
        {

            Recipe recipe = RecipeViewModelToModel(recipeViewModel);


                await _api.RecipesPOSTAsync(recipe);
            return View();
        }

        // GET: RecipesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var recipe = await _api.RecipesGETAsync(id);
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

        private static Recipe RecipeViewModelToModel(RecipeViewModel recipeViewModel)
        {
            return new Recipe
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Name = recipeViewModel.Name,
                Ingredients = recipeViewModel.Ingredients.ToModel(r => new Ingredient
                {
                    IngredientName = r.IngredientName,
                    Measurement = r.Measurement,
                    Note = r.Note,
                    Market = r.Market
                }).ToList(),
                Directions = recipeViewModel.Directions.ToModel(d => new Direction
                {
                    Step = d.Step
                }).ToList()
            };
        }
    }
}