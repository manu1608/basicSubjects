using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    public class BaiTapDatabase
    {
        public static Task<List<EZCode.Model.BaiTap>> GetAllBaiTapAsync()
        {
            return Database.database.Table<EZCode.Model.BaiTap>().ToListAsync();
        }

        public static Task<EZCode.Model.BaiTap> GetBaiTapAsync(int id)
        {
            return Database.database.Table<EZCode.Model.BaiTap>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public static Task<EZCode.Model.BaiTap> GetBaiTapAsync(string name)
        {
            return Database.database.Table<EZCode.Model.BaiTap>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public static Task<int> SaveBaiTapAsync(EZCode.Model.BaiTap baiTap)
        {
            if (baiTap.Id == 0)
            {
                return Database.database.InsertAsync(baiTap);
            }
            else
            {
                return Database.database.UpdateAsync(baiTap);
            }
        }

        public static Task<int> DeleteBaiTapAsync(EZCode.Model.BaiTap baiTap)
        {
            return Database.database.DeleteAsync(baiTap);
        }
    }
}
