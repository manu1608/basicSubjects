using System;
using System.Collections.Generic;
using System.Text;

namespace EZCode
{
    static class ConstantString
    {
        public const String HOME_TEXT = "Home";
        public const String DAI_SO_TEXT = "Đại số";
        public const String GIAI_TICH_I_TEXT = "Giải tích 1";
        public const String GIAI_TICH_II_TEXT = "Giải tích 2";
        public const String VAT_LY_I_TEXT = "Vật lý 1";
        public const String VAT_LY_II_TEXT = "Vật lý 2";
        public const String ABOUT_TEXT = "About";
        public const String FEEDBACK_TEXT = "Góp ý";
        public const String CONTACT_TEXT = "Liên hệ";

        public const String HOME_IMAGE = "bill.png";
        public const String DAI_SO_IMAGE = "bill.png";
        public const String GIAI_TICH_I_IMAGE = "bill.png";
        public const String GIAI_TICH_II_IMAGE = "bill.png";
        public const String VAT_LY_I_IMAGE = "bill.png";
        public const String VAT_LY_II_IMAGE = "bill.png";
        public const String ABOUT_IMAGE = "bill.png";
        public const String FEEDBACK_IMAGE = "bill.png";
        public const String CONTACT_IMAGE = "bill.png";

        public const String EXPRESSIONS_TEXT    = "Công thức";
        public const String EXERCISES_TEXT      = "Bài tập";
        public const String EXAMS_TEXT          = "Đề thi";
        public const String NOTES_TEXT          = "Ghi chú";

        public enum PAGE_ITEM
        {
            PAGE_ITEM_EXPRESSION = 0,
            PAGE_ITEM_EXERCISE,
            PAGE_ITEM_EXAM,
            PAGE_ITEM_NOTE,
        };

        public enum MON_HOC
        {
            DAI_SO =           1,
            GIAI_TICH_1        ,
            GIAI_TICH_2        ,
            VAT_LY_1           ,
            VAT_LY_2           ,
        };
    }
}
