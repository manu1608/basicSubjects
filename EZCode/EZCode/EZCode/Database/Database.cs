using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EZCode.Database
{
    public class Database
    {
        public static SQLiteAsyncConnection database;

        public Database(string dbName)
        {
            string dbPath = DependencyService.Get<IDatabaseHelper>().GetLocalFilePath(dbName);
            DependencyService.Get<IDatabaseHelper>().CopyDatabaseToLocal(dbPath);
            database = new SQLiteAsyncConnection(dbPath);
        }
    }
}
