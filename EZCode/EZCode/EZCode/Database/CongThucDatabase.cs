using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    public class CongThucDatabase
    {
        public static Task<List<EZCode.Model.CongThuc>> GetAllCongThucAsync()
        {
            return Database.database.Table<EZCode.Model.CongThuc>().ToListAsync();
        }

        public static Task<EZCode.Model.CongThuc> GetCongThucAsync(int id)
        {
            return Database.database.Table<EZCode.Model.CongThuc>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public static Task<EZCode.Model.CongThuc> GetCongThucAsync(string name)
        {
            return Database.database.Table<EZCode.Model.CongThuc>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public static Task<int> SaveCongThucAsync(EZCode.Model.CongThuc congThuc)
        {
            if (congThuc.Id == 0)
            {
                return Database.database.InsertAsync(congThuc);
            }
            else
            {
                return Database.database.UpdateAsync(congThuc);
            }
        }

        public static Task<int> DeleteCongThucAsync(EZCode.Model.CongThuc congThuc)
        {
            return Database.database.DeleteAsync(congThuc);
        }
    }
}
