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
    public partial class RecipeDetail : ContentPage
    {
        Guid _recipeId;

        public RecipeDetail(Guid recipeId)
        {
            InitializeComponent();

            var viewModel = new RecipeDetailViewModel(recipeId);

            _recipeId = viewModel.Recipe.Id;

            BtnShowPlanDate.Command = viewModel.ShowPlanDate;

            BindingContext = viewModel;
        }

        private void BtnAddToPlan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var dayService = new DayService();

                dayService.SaveDayPlan(
                    new Request.SaveDayPlanRequest
                    {
                        Date = PlanDate.Date,
                        RecipeId = _recipeId,
                        UserEmail = "ddiioonnii@gmail.com"
                    });

                DisplayAlert("Sucesso", "Receita adicionada com sucesso", "Ok");
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Não foi possível adicionar a receita", "Ok");
            }
        }

        private void BtnShowPlanDate_Clicked(object sender, EventArgs e)
        {
            BtnShowPlanDate.IsVisible = false;
        }
    }
}