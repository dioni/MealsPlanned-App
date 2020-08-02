using MealsPlanned_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Plan : ContentPage
    {
        public Plan()
        {
            InitializeComponent();

            var viewModel = new PlanViewModel(this.Navigation, null);

            BindingContext = viewModel;
            //recipeImage.Source = viewModel.RecipeImage;
            //btnDom.Command = viewModel.DayCommand;            
        }
    }
}