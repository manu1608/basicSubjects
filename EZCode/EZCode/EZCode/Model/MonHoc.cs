using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace EZCode.Model
{
    public class MonHoc
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToMany]
        public List<CongThuc> CongThucList { get; set; }

        [OneToMany]
        public List<BaiTap> BaiTapList { get; set; }

        [OneToMany]
        public List<DeThi> DeThiList { get; set; }
    }
}
