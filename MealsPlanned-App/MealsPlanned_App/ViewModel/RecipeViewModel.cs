using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.ViewModel
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            Ingredients = new List<IngredientViewModel>();
            Steps = new List<MethodOfPreparationViewModel>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CuisineTypeName { get; set; }

        public string RecipeTypeName { get; set; }
        public string RecipeImage { get; set; }

        public IList<MethodOfPreparationViewModel> Steps { get; set; }

        public IList<IngredientViewModel> Ingredients { get; set; }
    }
}
