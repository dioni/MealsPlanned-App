using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Model.DataModels
{
    public class GroceryListItem
    {
        [PrimaryKey]
        public Guid IngredientId { get; set; }

        public Guid GroceryListId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string UnitOfMeasureName { get; set; }

        public string Quantity { get; set; }
    }
}
