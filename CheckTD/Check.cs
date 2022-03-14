using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

enum CheckResult
{
    Contained,
    NOT_Contained,
    Contained_but_excluded,
    Error
}

namespace CheckTD
{
    class Check
    {
        /// <summary>
        /// Проверяет XML-файл на содержание в нем кодов из Постановлений Правительства №№ 311, 312, 313
        /// </summary>
        /// <param name="file">Полный адрес проверяемого файла XML</param>
        /// <param name="textResult">Строка с кодами, которые содержатся в Постановлениях. Если не содержатся, то строка пуста.</param>
        /// <returns>Возвращает true, если хотя бы 1 код есть в Постановлениях, false - если кодов нет.</returns>
        public static CheckResult CheckFile(string file, out string textResult)
        {
            string dataFromFile;
            //textResult = string.Empty;
            StringBuilder txtRes = new StringBuilder();
            List<CheckResult> results = new List<CheckResult>();
            try
            {
                dataFromFile = File.ReadAllText(file);
                //Console.WriteLine(dataFromFile);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textResult = "Error";
                return CheckResult.Error;
            }

            Dictionary<int, string> numberCode = GetCodesTNVED(dataFromFile);

            foreach (var n in numberCode)
            {
                //Console.WriteLine($"number: {n.Key}, code TNVED: {n.Value}");

                if(CheckCodeTNVED(n.Value, out var numberOfLaws, out bool isExcluded, out int numberOfLawWhereIsExcludedCode))
                {
                    string laws = GetStringFromList(numberOfLaws);
                    //Console.WriteLine($"Код {n.Value} товара № {n.Key} присутствует в Постановлении № {laws}.");
                    txtRes.AppendLine($"Товар № {n.Key}, код ТНВЭД {n.Value} присутствует в Постановлении № {laws}.");
                    if (isExcluded)
                    {
                        //Console.WriteLine("Но находится в исключениях.");
                        txtRes.AppendLine($"Но находится в исключениях Постановления № {numberOfLawWhereIsExcludedCode}.");
                        results.Add(CheckResult.Contained_but_excluded);
                    }
                    else
                        results.Add(CheckResult.Contained);
                }
                else
                {
                    results.Add(CheckResult.NOT_Contained);
                    txtRes.AppendLine($"Товар № {n.Key}, код ТНВЭД {n.Value} в Постановлениях отсутствует.");
                }
            }

            textResult = txtRes.ToString();
            if (results.Contains(CheckResult.Contained)) return CheckResult.Contained;
            else if (results.Contains(CheckResult.Contained_but_excluded)) return CheckResult.Contained_but_excluded;
            else return CheckResult.NOT_Contained;
        }



        private static Dictionary<int, string> GetCodesTNVED(string dataFromFile)
        {
            string[] partsForGoods = dataFromFile.Split(new string[] { "<catESAD_cu:GoodsNumeric>" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, string> result = new Dictionary<int, string>();

            for(int i = 1; i < partsForGoods.Length; i++)
            {
                if (int.TryParse(partsForGoods[i].Split('<')[0], out int numberOfGood)){ 
                //Console.WriteLine("number of good: " + numberOfGood);
                }
                else
                {
                    MessageBox.Show("Ошибка при получении номера товара.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Dictionary<int, string>();
                }

                string[] partsForTNVED = partsForGoods[i].Split(new string[] { "<catESAD_cu:GoodsTNVEDCode>" }, StringSplitOptions.RemoveEmptyEntries);

                //for (int j = 0; j < partsForTNVED.Length; j++)
                //{
                //    Console.WriteLine($"part {j}: {partsForTNVED[j]}");
                //}
                string codeTNVED = partsForTNVED[1].Split('<')[0];
                result.Add(numberOfGood, codeTNVED);

            }

            return result;
        }




        /// <summary>
        /// Проверяет присутствие кода ТНВЭД в Постановлениях.
        /// </summary>
        /// <param name="code">Проверяемый код ТНВЭД</param>
        /// <param name="numberOfLaws">Список Постановлений, в которых код присутствует</param>
        /// <returns>Возвращает true, если код есть хотя бы в одном Постановлении, false - если нет.</returns>
        private static bool CheckCodeTNVED(string code, out List<int> numberOfLaws, out bool isExcluded, out int numberOfLawWhereIsExludedCode)
        {
            numberOfLaws = new List<int>();
            isExcluded = false;
            numberOfLawWhereIsExludedCode = -1;
            foreach(var bannedCodes in TNVED_Codes.Codes)
            {
                if (bannedCodes.Value.Any(c => IsCodeEquals(code, c)))
                {
                    int _numberOfLaw = bannedCodes.Key;
                    numberOfLaws.Add(_numberOfLaw);
                    if(TNVED_Codes.ExcludedCodes.TryGetValue(_numberOfLaw, out string[] excludedCodes) && excludedCodes.Any(c => IsCodeEquals(code, c)))
                    {
                        isExcluded = true;
                        numberOfLawWhereIsExludedCode = _numberOfLaw;
                    }
                }
            }
            return numberOfLaws.Count > 0;
        }

        /// <summary>
        /// Сравнивает проверяемый код ТНВЭД и код ТНВЭД из Постановления.
        /// </summary>
        /// <param name="codeForCheck">Проверяемый код</param>
        /// <param name="codeInLaw">Код из Постановления</param>
        /// <returns>Возвращает true, если проверяемый код полностью совпадает или является частью кода из Постановления, иначе false.</returns>
        private static bool IsCodeEquals(string codeForCheck, string codeInLaw)
        {
            //Console.WriteLine($"codeForCheck: {codeForCheck}, codeInLaw: {codeInLaw}");
            bool res = true;
            for(int i = 0; i < codeForCheck.Length; i++)
            {
                if (i > codeInLaw.Length - 1) break;
                if(codeForCheck[i] != codeInLaw[i])
                {
                    res = false;
                    break;
                }
            }

            //Console.WriteLine($"IsCodeEquals: {res}");
            return res;
        }


        private static string GetStringFromList(List<int> data)
        {
            string res = string.Empty;
            foreach (var d in data)
                res += d.ToString() + ", ";
            res = res.Remove(res.Length - 2, 2);
            return res;
        }

    }
}
