using MealsPlanned_App.Model;
using MealsPlanned_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MealsPlanned_App.ViewModel
{
    public class RecipeListViewModel
    {
        RecipeService _recipeService;

        public RecipeSearchQuery Query { get; set; }
        public ObservableCollection<RecipeViewModel> Recipes { get; set; }

        public ICommand SearchCommand => new Command(() => 
        {
            BindRecipes();
        });

        public RecipeListViewModel()
        {
            _recipeService = new RecipeService();
            Query = new RecipeSearchQuery();
            Recipes = new ObservableCollection<RecipeViewModel>();

            BindRecipes();
        }

        private void BindRecipes()
        {
            Recipes.Clear();

            foreach (var item in _recipeService.Recipes(Query))
            {
                Recipes.Add(item);
            }
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            BindRecipes();
        }
    }
}
