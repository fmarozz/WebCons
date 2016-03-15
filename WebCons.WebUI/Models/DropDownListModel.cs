using System.Web.Mvc;

namespace WebCons.WebUI.Models
{
    public class DropDownListModel
    {
        public DropDownListModel(string name, string itemId)
        {
            ItemId = itemId;
            Name = name;
        }

        public string ItemId { get; set; }
        public SelectList Items { get; set; }
        public string OptionLabel { get; set; }
        public string Name { get; set; }
    }
}