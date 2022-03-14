using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckTD.Properties;

namespace CheckTD
{
    class TNVED_Codes
    {
        public static Dictionary<int, string[]> Codes { get; private set; }
        public static Dictionary<int, string[]> ExcludedCodes { get; private set; }


        public static void Initialize()
        {
            Codes = new Dictionary<int, string[]>();
            Codes.Add(311, Resources.cods311.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            Codes.Add(312, Resources.cods312.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            Codes.Add(313, Resources.cods313.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            //foreach(var c in Codes)
            //    foreach (var code in c.Value)
            //        Console.WriteLine($"law: {c.Key}, code: {code}");

            //Console.WriteLine();

            ExcludedCodes = new Dictionary<int, string[]>();
            ExcludedCodes.Add(312, Resources.codsExcluded312.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            //foreach (var exc in ExcludedCodes)
            //    foreach (var code in exc.Value)
            //        Console.WriteLine($"law: {exc.Key}, Ex code: {code}");

            //Console.WriteLine($"law: 311, codes count: {Codes[311].Length}");
            //Console.WriteLine($"law: 312, codes count: {Codes[312].Length}");
            //Console.WriteLine($"law: 313, codes count: {Codes[313].Length}");
            //Console.WriteLine($"law: 312, ex codes count: {ExcludedCodes[312].Length}");
        }



    }
}
