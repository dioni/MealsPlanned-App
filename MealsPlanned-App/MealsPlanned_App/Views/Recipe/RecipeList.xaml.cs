using MealsPlanned_App.Model;
using MealsPlanned_App.Services;
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
    public partial class RecipeList : ContentPage
    {
        public RecipeList()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            try
            {
                var viewModel = new RecipeListViewModel();

                BindingContext = viewModel;
                btnSearch.Command = viewModel.SearchCommand;
                ListViewRecipes.ItemSelected += ListView_ItemSelected;
            }
            catch (Exception exc)
            {
                DisplayAlert("Refeições Planejadas", "Ocorreu um problema ao obter as receitas", "Ok");
            }

            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = (RecipeViewModel)e.SelectedItem;

            var nextPage = new RecipeDetail(selectedItem.Id);
            
            this.Navigation.PushAsync(nextPage);
        }
    }
}