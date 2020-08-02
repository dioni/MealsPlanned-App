using System.Collections.Generic;

namespace MealsPlanned_App.ViewModel
{
    public class GroceryListViewModel
    {
        public string Title { get; set; }
        public List<GroceryListGroupViewModel> GroupedItems { get; set; }
    }
}
