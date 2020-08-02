using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Model.DataModels
{
    public class GroceryList
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
