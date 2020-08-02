using MealsPlanned_App.Services;
using MealsPlanned_App.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPlan : TabbedPage
    {
        RecipeService _recipeService;

        public TabPlan()
        {
            InitializeComponent();

            _recipeService = new RecipeService();
            
            //https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/navigation/tabbed-page/
            //https://xamarin.azureedge.net/developer/xamarin-forms-book/XamarinFormsBook-Ch25-Apr2016.pdf
        }

        protected override void OnAppearing()
        {
            var viewModel = new PlanViewModel(this.Navigation,
                  new Model.PlanWeekQuery { DateFilter = DateTime.Now, UserEmail = "ddiioonnii@gmail.com" });

            var items = viewModel.LoadItems(null);

            ItemsSource = items;

            base.OnAppearing();
        }

        private void BtnGoToRecipes_Clicked(object sender, EventArgs e)
        {
            var nextPage = new RecipeList();
            
            this.Navigation.PushAsync(nextPage);
        }
    }
}