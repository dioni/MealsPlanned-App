using MealsPlanned_App.Model;
using MealsPlanned_App.Request;
using MealsPlanned_App.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Services
{
    public class DayService
    {
        public IList<DayOfWeekItemViewModel> GetPlanWeek(PlanWeekQuery filter)
        {
            var filteredDays = new List<DayOfWeekItemViewModel>();

            for (int i = 1; i <= 5; i++)
            {
                var item = GetDay(filter);

                filteredDays.Add(item);

                filter.DateFilter = filter.DateFilter.AddDays(1);
            }

            return filteredDays;
        }

        public void SaveDayPlan(SaveDayPlanRequest request)
        {
            var httpClient = new HttpClientServiceBase<SaveDayPlanRequest>();

            httpClient.Post("api/mealsplan/save", request);
        }

        public DayOfWeekItemViewModel GetDay(PlanWeekQuery filter)
        {
            try
            {
                var client = new HttpClientServiceBase<DayOfWeekItemViewModel>();

                return client.Get(string.Format("api/planweek/GetByDate?datefilter={0}&userEmail={1}", filter.DateFilter, filter.UserEmail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
