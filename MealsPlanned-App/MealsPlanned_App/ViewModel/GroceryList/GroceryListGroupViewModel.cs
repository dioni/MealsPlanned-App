using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.ViewModel
{
    public class GroceryListGroupViewModel : List<GroceryListItemEditVM>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists        
        public GroceryListGroupViewModel(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;
        }
    }
}
