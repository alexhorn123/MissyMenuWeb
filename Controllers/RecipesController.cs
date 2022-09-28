using Microsoft.AspNetCore.Mvc;
using MissyMenu.Service;

using Newtonsoft.Json;


namespace MissyMenuWeb.Controllers
{
    public class RecipesController : Controller
    {
        // GET: RecipesController
        private readonly RecipesClient api = new("https://localhost:7202/",new HttpClient());
        public async Task<ActionResult> Index()
        {
            var recipeList = (List<Recipe>)await api.RecipesAllAsync();
            return View(recipeList);
        }



        // GET: RecipesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var recipe = await api.RecipesGETAsync(id);
            return View(recipe);
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View();
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
