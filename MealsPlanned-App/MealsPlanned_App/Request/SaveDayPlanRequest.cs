using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Request
{
    public class SaveDayPlanRequest
    {
        public Guid RecipeId { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
    }
}
