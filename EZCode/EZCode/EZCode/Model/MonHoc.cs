using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace EZCode.Model
{
    public class MonHoc
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
