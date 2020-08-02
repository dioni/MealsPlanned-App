using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Model
{
    public class PlanWeekQuery
    {
        public DateTime DateFilter { get; set; }
        public string UserEmail { get; set; }
    }
}
