using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    public class MonHocDatabase
    {
        public Task<List<EZCode.Model.MonHoc>> GetAllMonHocAsync()
        {
            return Database.database.Table<EZCode.Model.MonHoc>().ToListAsync();
        }

        public Task<EZCode.Model.MonHoc> GetMonHocAsync(int id)
        {
            return Database.database.Table<EZCode.Model.MonHoc>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<EZCode.Model.MonHoc> GetMonHocAsync(string name)
        {
            return Database.database.Table<EZCode.Model.MonHoc>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> SaveMonHocAsync(EZCode.Model.MonHoc monHoc)
        {
            if (monHoc.Id == 0)
            {
                return Database.database.InsertAsync(monHoc);
            }
            else
            {
                return Database.database.UpdateAsync(monHoc);
            }
        }

        public Task<int> DeleteMonHocAsync(EZCode.Model.MonHoc monHoc)
        {
            return Database.database.DeleteAsync(monHoc);
        }
    }
}
