using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    class MonHocCongThucDatabase
    {
        public static Task<List<EZCode.Model.CongThuc>> GetAllCongThucAsync(int idMonHoc)
        {
            return Database.database.Table<EZCode.Model.CongThuc>().Where(i => i.Id == idMonHoc).ToListAsync();
        }
    }
}
