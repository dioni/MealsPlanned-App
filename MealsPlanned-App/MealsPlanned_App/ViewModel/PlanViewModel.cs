using MealsPlanned_App.Model;
using MealsPlanned_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MealsPlanned_App.ViewModel
{
    public class PlanViewModel
    {
        INavigation _navigation;
        DayService _dayService;
        RecipeService _recipeService;
        PlanWeekQuery _query;

        public PlanViewModel(INavigation navigation, PlanWeekQuery query)
        {
            _navigation = navigation;
            _dayService = new DayService();
            _recipeService = new RecipeService();
            _query = query;
        }

        public IList<DayOfWeekItemViewModel> LoadItems(PlanWeekQuery query)
        {
            if (query != null)            
                _query = query;
            
            var days = _dayService.GetPlanWeek(_query);

            return days;
        }
    }

    public class DayOfWeekItemViewModel : INotifyPropertyChanged
    {
        bool _showRecipe;
        bool _hideRecipe;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShowRecipe
        {
            get
            {
                return _showRecipe;
            }
            set
            {
                _showRecipe = value;
                NotifyPropertyChanged("ShowRecipe");
            }
        }

        public bool HideRecipe
        {
            get
            {
                return _hideRecipe;
            }
            set
            {
                _hideRecipe = value;
                NotifyPropertyChanged("HideRecipe");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Index { get; set; }
        public string DayOfWeek { get; set; }
        public string RecipeImage { get; set; }
        public string RecipeTitle { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeViewModel Recipe { get; set; }
    }
}
