using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    class MonHocBaiTapDatabase
    {
        public static Task<List<EZCode.Model.BaiTap>> GetAllBaiTapAsync(int idMonHoc)
        {
            return Database.database.Table<EZCode.Model.BaiTap>().Where(i => i.Id == idMonHoc).ToListAsync();
        }
    }
}
