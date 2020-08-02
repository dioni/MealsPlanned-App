using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Views
{

    public class HomeMenuItem
    {
        public HomeMenuItem(Type type)
        {
            TargetType = type;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string PageIcon { get; set; }

        public Type TargetType { get; set; }
    }
}