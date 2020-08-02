using MealsPlanned_App.Helpers;
using MealsPlanned_App.Services;
using MealsPlanned_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealsPlanned_App.Views
{
    public class TabPlanCS : TabbedPage
    {
        RecipeService _recipeService;

        public TabPlanCS()
        {
            var booleanConverter = new NonNullToBooleanConverter();

            var fontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

            _recipeService = new RecipeService();


            var viewModel = new PlanViewModel(this.Navigation,
                new Model.PlanWeekQuery { DateFilter = DateTime.Now, UserEmail = "ddiioonnii@gmail.com" });

            var items = viewModel.LoadItems(null);

            ItemsSource = items;

            var labelsColor = Color.FromHex("#777");

            var dataTemplate = new DataTemplate(() =>
            {
                var contentPage = new ContentPage();
                var stackContent = new StackLayout();
                var scrollView = new ScrollView();
                var stackEmptyRecipe = new StackLayout();
                var stackRecipe = new StackLayout();

                var labelRecipeTitle = new Label() { TextColor = labelsColor, FontSize = fontSize };
                var recipeImage = new Image();
                var labelIngredients = new Label() { TextColor = labelsColor, FontSize = fontSize, Text= "Ingredientes" };
                var listViewIngredients = new ListView();
                var labelMethodOfPreparation = new Label() { TextColor = labelsColor, FontSize = fontSize, Text= "Modo de preparo" };
                var listViewSteps = new ListView();
                var labelEmptyRecipe = new Label() { TextColor = Color.FromHex("#69af0d"), FontSize = fontSize };
                var btnGoToRecipes = new Button() { Text = "Procurar Receitas" };

                labelRecipeTitle.HorizontalOptions = LayoutOptions.Center;
                recipeImage.WidthRequest = 200;
                recipeImage.HeightRequest = 200;
                labelIngredients.HorizontalOptions = LayoutOptions.Center;
                listViewIngredients.HorizontalOptions = LayoutOptions.Center;
                labelMethodOfPreparation.HorizontalOptions = LayoutOptions.Center;
                listViewSteps.HorizontalOptions = LayoutOptions.Center;
                listViewSteps.RowHeight = 100;

                stackEmptyRecipe.SetBinding(IsVisibleProperty, "HideRecipe");
                stackRecipe.SetBinding(IsVisibleProperty, "ShowRecipe");
                labelRecipeTitle.SetBinding(Label.TextProperty, "Recipe.Title");
                recipeImage.SetBinding(Image.SourceProperty, "Recipe.RecipeImage");                
                listViewIngredients.SetBinding(ListView.ItemsSourceProperty, "Recipe.Ingredients");
                listViewSteps.SetBinding(ListView.ItemsSourceProperty, "Recipe.Steps");

                listViewIngredients.ItemTemplate = new DataTemplate(() =>
                {
                    var ingredientsStackOne = new StackLayout();
                    var ingredientsStackTwo = new StackLayout();

                    var labelQuantity = new Label() { TextColor = labelsColor, FontSize = fontSize };
                    var unityOfMeasureName = new Label() { TextColor = Color.FromHex("#69af0d"), FontSize = fontSize };
                    var name = new Label() { TextColor = Color.FromHex("#69af0d"), FontSize = fontSize };
                    var observation = new Label() { TextColor = Color.FromHex("#69af0d"), FontSize = fontSize };

                    ingredientsStackOne.Orientation = StackOrientation.Vertical;
                    ingredientsStackTwo.Orientation = StackOrientation.Horizontal;

                    labelQuantity.SetBinding(Label.TextProperty, "Quantity");
                    unityOfMeasureName.SetBinding(Label.TextProperty, "UnityOfMeasureName");
                    name.SetBinding(Label.TextProperty, "Name");
                    observation.SetBinding(Label.TextProperty, "Observation");

                    ingredientsStackTwo.Children.Add(labelQuantity);
                    ingredientsStackTwo.Children.Add(unityOfMeasureName);
                    ingredientsStackTwo.Children.Add(name);
                    ingredientsStackTwo.Children.Add(observation);
                    ingredientsStackOne.Children.Add(ingredientsStackTwo);

                    return ingredientsStackOne;
                });

                var customCell = new DataTemplate(typeof(StepCustomCell));

                customCell.SetBinding(StepCustomCell.StepProperty, "Step");
                customCell.SetBinding(StepCustomCell.DescriptionProperty, "Description");

                listViewSteps.ItemTemplate = customCell;

                //listViewSteps.ItemTemplate = new DataTemplate(() =>
                //{
                    //var stepStackOne = new StackLayout();
                    //var stepStackTwo = new StackLayout();

                    //stepStackOne.Orientation = StackOrientation.Vertical;
                    //stepStackTwo.Orientation = StackOrientation.Horizontal;

                    //var labelStep = new Label() { TextColor = Color.FromHex("#777"), FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), Text="teste"  };
                    //var labelDescription = new Label() { TextColor = Color.FromHex("#69af0d"), FontSize = fontSize };

                    //labelStep.SetBinding(Label.TextProperty, "Step");
                    //labelDescription.SetBinding(Label.TextProperty, "Description");

                    //stepStackTwo.Children.Add(labelStep);
                    //stepStackTwo.Children.Add(labelDescription);

                    //stepStackOne.Children.Add(stepStackTwo);

                    //return stepStackOne;
                //});

                btnGoToRecipes.Clicked += BtnGoToRecipes_Clicked;
                stackEmptyRecipe.Children.Add(labelEmptyRecipe);
                stackEmptyRecipe.Children.Add(btnGoToRecipes);

                stackRecipe.Children.Add(labelRecipeTitle);
                stackRecipe.Children.Add(recipeImage);
                stackRecipe.Children.Add(labelIngredients);
                //stackRecipe.Children.Add(listViewIngredients);
                stackRecipe.Children.Add(labelMethodOfPreparation);
                stackRecipe.Children.Add(listViewSteps);

                stackContent.Children.Add(stackEmptyRecipe);
                stackContent.Children.Add(stackRecipe);

                scrollView.Content = stackContent;

                contentPage.Content = scrollView;

                contentPage.SetBinding(TitleProperty, "DayOfWeek");

                return contentPage;
            });

            ItemTemplate = dataTemplate;
        }

        private void BtnGoToRecipes_Clicked(object sender, EventArgs e)
        {
            var nextPage = new RecipeList();

            this.Navigation.PushAsync(nextPage);
        }
    }
}
