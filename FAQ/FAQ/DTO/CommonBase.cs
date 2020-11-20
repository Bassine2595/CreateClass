using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class CommonBase
    {
        // Les valeurs nulles standards de configuration
        public static DateTime DateTime_NullValue = DateTime.Parse("01/01/1800");
        public static Guid Guid_NullValue = Guid.Empty;
        public static int Int_NullValue = int.MinValue;
        public static int Int32_NullValue = int.MinValue;
        public static float Float_NullValue = float.MinValue;
        public static decimal Decimal_NullValue = decimal.MinValue;
        public static string String_NullValue = string.Empty;
        public static int Int_defaultZero = 0;
        public static DateTime? DateTime_nullAbleValue = null;

        public static TimeSpan TimeSpan_NullValue = TimeSpan.MinValue;
    }
}
