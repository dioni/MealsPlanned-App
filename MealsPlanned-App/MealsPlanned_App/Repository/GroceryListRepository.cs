using MealsPlanned_App.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Repository
{
    public class GroceryListRepository
    {
        MPDatabase _database;

        public GroceryListRepository(MPDatabase database)
        {
            _database = database;
        }

        public Task<int> Delete(GroceryList groceryList)
        {
            var items = _database.connection.Table<GroceryListItem>()
                .Where(x => x.GroceryListId == groceryList.Id)
                .ToListAsync().Result;

            foreach (var item in items)
                _database.connection.DeleteAsync(item);

            return _database.connection.DeleteAsync(groceryList);
        }

        public Task<List<GroceryList>> GetAll()
        {
            return _database.connection.Table<GroceryList>().ToListAsync();
        }

        public Task<int> Save(GroceryList groceryList)
        {
            return _database.connection.InsertAsync(groceryList);
        }

        public Task<int> SaveList(IEnumerable<GroceryListItem> item)
        {
            return _database.connection.InsertAllAsync(item);
        }
    }
}
