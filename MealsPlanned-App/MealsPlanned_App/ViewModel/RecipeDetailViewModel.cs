using MealsPlanned_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MealsPlanned_App.ViewModel
{
    public class RecipeDetailViewModel: INotifyPropertyChanged
    {
        RecipeService _recipeService;
        bool _isPlanDateVisible;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddToPlanClicked => new Command((e) =>
        {
            var recipeId = (Guid)e;

            var dayService = new DayService();

            dayService.SaveDayPlan(
                new Request.SaveDayPlanRequest
                {
                    Date = PlanDate,
                    RecipeId = recipeId,
                    UserEmail = "ddiioonnii@gmail.com"
                });
        });

        public ICommand ShowPlanDate => new Command(() =>
        {
            IsPlanDateVisible = !IsPlanDateVisible;
        });

        public bool IsPlanDateVisible
        {
            get
            {
                return _isPlanDateVisible;
            }
            set
            {
                _isPlanDateVisible = value;
                NotifyPropertyChanged("IsPlanDateVisible");
            }
        }

        public DateTime PlanDate { get; set; } = DateTime.Now;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RecipeViewModel Recipe { get; set; }

        public RecipeDetailViewModel(Guid id)
        {
            _recipeService = new RecipeService();

            Recipe = _recipeService.GetRecipe(id);
        }
    }
}
