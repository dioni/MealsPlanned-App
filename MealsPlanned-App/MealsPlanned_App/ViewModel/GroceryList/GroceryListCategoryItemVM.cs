using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.ViewModel
{
    public class GroceryListItemEditVM
    {
        public Guid IngredientId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string UnitOfMeasureName { get; set; }

        public string Quantity { get; set; }
    }
}
