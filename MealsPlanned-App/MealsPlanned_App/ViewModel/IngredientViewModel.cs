using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.ViewModel
{
    public class IngredientViewModel
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Observation { get; set; }

        public Guid UnitOfMeasureId { get; set; }

        public string UnityOfMeasureName { get; set; }

        public double Quantity { get; set; }
    }
}
