using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZCode.Database
{
    public class DeThiDatabase
    {
        public Task<List<EZCode.Model.DeThi>> GetAllDeThiAsync()
        {
            return Database.database.Table<EZCode.Model.DeThi>().ToListAsync();
        }

        public Task<EZCode.Model.DeThi> GetDeThiAsync(int id)
        {
            return Database.database.Table<EZCode.Model.DeThi>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<EZCode.Model.DeThi> GetDeThiAsync(string name)
        {
            return Database.database.Table<EZCode.Model.DeThi>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> SaveDeThiAsync(EZCode.Model.DeThi deThi)
        {
            if (deThi.Id == 0)
            {
                return Database.database.InsertAsync(deThi);
            }
            else
            {
                return Database.database.UpdateAsync(deThi);
            }
        }

        public Task<int> DeleteDeThiAsync(EZCode.Model.DeThi deThi)
        {
            return Database.database.DeleteAsync(deThi);
        }
    }
}
