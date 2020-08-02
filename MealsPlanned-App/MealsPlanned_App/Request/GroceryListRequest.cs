namespace MealsPlanned_App.Request
{
    public class GroceryListRequest
    {
        public string UserIdentifier { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
    }
}
