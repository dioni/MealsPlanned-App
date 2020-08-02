using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using SQLite;
using MealsPlanned_App.Model.DataModels;

namespace MealsPlanned_App.Repository
{
    public class MPDatabase
    {
        public SQLiteAsyncConnection connection;

        public MPDatabase(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<GroceryListItem>().Wait();
        }

    }
}
