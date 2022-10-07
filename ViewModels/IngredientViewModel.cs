using Microsoft.AspNetCore.Mvc.Rendering;
using MissyMenu.Service;

namespace MissyMenuWeb.ViewModels
{
    //public class IngredientViewModel
    //{
    //   public Ingredient? Ingredient { get; set; }
    //   public List<SelectListItem>? Globals { get; set; }
    //}


    public class IngredientViewModel
    {
        [Newtonsoft.Json.JsonProperty("IngredientName", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? IngredientName { get; set; }

        [Newtonsoft.Json.JsonProperty("Measurement", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Measurement { get; set; }

        [Newtonsoft.Json.JsonProperty("Note", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Note { get; set; }

        [Newtonsoft.Json.JsonProperty("Link", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Link { get; set; }

        [Newtonsoft.Json.JsonProperty("Market", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Market { get; set; }
        public List<SelectListItem>? Globals { get; set; }
    }
}
