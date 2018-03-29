using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    public class Database
    {
        public static SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<EZCode.Model.MonHoc>().Wait();
            database.CreateTableAsync<EZCode.Model.CongThuc>().Wait();
            database.CreateTableAsync<EZCode.Model.BaiTap>().Wait();
            database.CreateTableAsync<EZCode.Model.DeThi>().Wait();
        }
    }
}
