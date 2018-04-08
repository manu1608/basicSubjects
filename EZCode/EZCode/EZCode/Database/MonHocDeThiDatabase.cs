using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    class MonHocDeThiDatabase
    {
        public static Task<List<EZCode.Model.DeThi>> GetAllDeThiAsync(int idMonHoc)
        {
            return Database.database.Table<EZCode.Model.DeThi>().Where(i => i.Id == idMonHoc).ToListAsync();
        }
    }
}
