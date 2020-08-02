using MealsPlanned_App.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroceriesList : ContentPage
    {
        public GroceriesList()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var groceryListService = new GroceryListService();

                var list = groceryListService.GenerateList(
                    new Request.GroceryListRequest
                    {
                        UserIdentifier = "ddiioonnii@gmail.com",
                        Finish = FinishDate.Date.ToString(Helpers.Constants.FormatoDataRequest),
                        Start = StartDate.Date.ToString(Helpers.Constants.FormatoDataRequest)
                    });

                var nextPage = new GeneratedGroceryList(list, StartDate.Date, FinishDate.Date);

                this.Navigation.PushAsync(nextPage);
            }
            catch (Exception)
            {
                DisplayAlert("Refeições Planejadas", "Ocorreu um problema ao gerar a lista de compras", "Ok");
            }
        }
    }
}