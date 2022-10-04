using Microsoft.AspNetCore.Mvc.Rendering;
using MissyMenu.Service;

namespace MissyMenuWeb.ViewModels
{
    public class IngredientViewModel
    {
       public Ingredient? Ingredient { get; set; }
       public List<SelectListItem> Globals { get; set; }
    }
}
