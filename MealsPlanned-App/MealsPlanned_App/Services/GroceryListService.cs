using MealsPlanned_App.Request;
using MealsPlanned_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Services
{
    public class GroceryListService
    {
        public IList<GroceryListItemEditVM> GenerateList(GroceryListRequest request)
        {
            var client = new HttpClientServiceBase<IList<GroceryListItemEditVM>>();

            return client.Get(string.Format("api/GroceryList/GenerateToApp?UserIdentifier={0}&Start={1}&Finish={2}", 
                request.UserIdentifier, request.Start, request.Finish));
        }
    }
}
