using DynamicVML;
using MissyMenu.Service;
using System.ComponentModel.DataAnnotations;

namespace MissyMenuWeb.ViewModels
{
    public class RecipeViewModel
    {
        public Id _Id { get; set; } = null!;

        [Display(Name = "Recipe Name")]
        public string? Name { get; set; }

        [Display(Name = "Ingredients")]
        public virtual DynamicList<IngredientViewModel> Ingredients { get; set; } = new DynamicList<IngredientViewModel>();

        [Display(Name = "Directions")]
        public virtual DynamicList<DirectionViewModel> Directions { get; set; } = new DynamicList<DirectionViewModel>();
    }
}
