using DynamicVML;
using MissyMenu.Service;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MissyMenuWeb.ViewModels
{
    public class RecipeViewModel
    {
        
        public string _Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [Display(Name = "Recipe Name")]
        public string? Name { get; set; }

        [Display(Name = "Ingredients")]
        public virtual DynamicList<IngredientViewModel> Ingredients { get; set; } = new DynamicList<IngredientViewModel>();

        [Display(Name = "Directions")]
        public virtual DynamicList<DirectionViewModel> Directions { get; set; } = new DynamicList<DirectionViewModel>();
    }
}
