using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace EZCode.Model
{
    public class DeThi
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(EZCode.Model.MonHoc))]
        public int MonHocId { get; set; }
    }
}
