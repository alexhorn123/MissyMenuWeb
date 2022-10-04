using Microsoft.AspNetCore.Mvc.Rendering;
using MissyMenu.Service;

namespace MissyMenuWeb.Service
{
    public class DropDownFactory
    {
        public IList<SelectListItem> CreateSelectListItem(ICollection<Global> globals, string ddType)
        {
            var list = new List<SelectListItem>();
            var marketList = globals.Where(x=>x.Config_Description == ddType).ToList();
            marketList.ForEach(x =>
            {
                list.Add(new SelectListItem { Text = x.Config_Value, Value = x.Config_Value });
            });
        return list;
        }
    }


}
