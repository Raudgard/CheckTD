using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTD
{
    class TNVED_Codes
    {
        private static Dictionary<int, string[]> codes;
        private static Dictionary<int, string[]> excludedCodes;


        public static Dictionary<int, string[]> Codes
        {
            get
            {
                if(codes == null)
                {
                    codes = new Dictionary<int, string[]>();
                    codes.Add(311, codes311);
                    codes.Add(312, codes312);
                    codes.Add(313, codes313);
                }
                return codes;
            }
        }


        public static Dictionary<int, string[]> ExcludedCodes
        {
            get
            {
                if (excludedCodes == null)
                {
                    excludedCodes = new Dictionary<int, string[]>();
                    excludedCodes.Add(311, excludedСodes311);
                    excludedCodes.Add(312, excludedСodes312);
                    excludedCodes.Add(313, excludedСodes313);
                }
                return codes;
            }
        }




        private static string[] codes311 =
        {
            "300610",
            "3006400000",
            "3006700000",
            "3815199000"
        };

        private static string[] codes312 =
        {
            "",
            "",
            "",
            ""
        };

        private static string[] codes313 =
        {
            "",
            "",
            "",
            ""
        };

        private static string[] excludedСodes311 =
        {
            
        };

        private static string[] excludedСodes312 =
        {
            "820559"
        };

        private static string[] excludedСodes313 =
        {
            
        };

    }
}
