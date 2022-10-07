using DynamicVML;
using DynamicVML.Extensions;
using Microsoft.AspNetCore.Mvc;
using MissyMenu.Service;
using MissyMenuWeb.ViewModels;

using Newtonsoft.Json;


namespace MissyMenuWeb.Controllers
{
    public class GlobalController : Controller
    {
        // GET: RecipesController
        private readonly GlobalClient _api = new(new HttpClient());


        public async Task<ActionResult> Index()
        {
            return View(await _api.GlobalAllAsync());
        }
    }
}