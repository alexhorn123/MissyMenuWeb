using MissyMenu.Service;

namespace MissyMenuWeb.ViewModels
{
    public class DirectionViewModel
    {
        [Newtonsoft.Json.JsonProperty("Step", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Step { get; set; }
    }
}
