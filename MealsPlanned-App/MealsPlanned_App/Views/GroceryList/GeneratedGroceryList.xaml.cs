using MealsPlanned_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneratedGroceryList : ContentPage
    {
        public GeneratedGroceryList(IList<ViewModel.GroceryListItemEditVM> list, DateTime startDate, DateTime finishDate)
        {
            InitializeComponent();

            GroceryListViewModel viewModel = new GroceryListViewModel();

            viewModel.Title = string.Format("Do dia {0} até o dia {1}", 
                startDate.ToString("dd/MM/yyyy"), finishDate.ToString("dd/MM/yyyy"));

            viewModel.GroupedItems = InitializeListView(list);

            this.BindingContext = viewModel;
        }

        List<GroceryListGroupViewModel> InitializeListView(IList<ViewModel.GroceryListItemEditVM> list)
        {
            List<GroceryListGroupViewModel> groups = new List<GroceryListGroupViewModel>();

            foreach (var item in list.GroupBy(x => x.CategoryName))
            {
                GroceryListGroupViewModel group = new GroceryListGroupViewModel(item.Key, item.Key);

                foreach (var subItem in list.Where(y => y.CategoryName == item.Key))
                {
                    group.Add(subItem);
                }

                groups.Add(group);
            }

            return groups;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}