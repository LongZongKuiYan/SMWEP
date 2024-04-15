using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioWorkerEditorPro
{
    class Class_SMWEP_Function
    {
        /// <summary>
        /// 将坐标转为MW可读取的字符串
        /// </summary>
        /// <param name="num">要转化的数字</param>
        /// <returns>结果字符串</returns>
        public static string ConvCoorToString(decimal num)
        {
            string str = String.Empty;

            num = Decimal.Round(num);
            if (num >= 0 && num <= 9)
                str = "000" + num;
            else if ((num >= -9 && num <= -1) || (num >= 10 && num <= 99))
                str = "00" + num;
            else if ((num >= -99 && num <= -10) || (num >= 100 && num <= 999))
                str = "0" + num;
            else if ((num >= -999 && num <= -100) || (num >= 1000 && num <= 9999))
                str = num.ToString();
            else if (num >= 10000)
            {
                string str1 = num.ToString().Substring(0, 2);
                string str2 = num.ToString().Substring(2, 3);

                // 通过ASCII码表将相应的代码转化为字符
                int nStr = int.Parse(str1);
                if (nStr >= 10 && nStr <= 35)
                    nStr += 55;
                else if (nStr >= 36 && nStr <= 61)
                    nStr += 61;
                str1 = ((char)nStr).ToString();
                str = str1 + str2;
            }
            return str;
        }
        /// <summary>
        /// 将探照灯的三个参数转换为MW可读取的代码
        /// </summary>
        /// <param name="num">待转换参数</param>
        /// <returns>返回代码</returns>
        public static string ConvRPhiOmegaToString(decimal num)
        {
            string str = String.Empty;
            num = Decimal.Round(num, 2);
            string temp = Convert.ToString(num);
            if (temp.Contains(".") == false || temp.Contains(".00") == true)
            {
                // num = Convert.ToInt32(num);
                num = Decimal.Round(num);
                if (num >= 0 && num <= 9)
                    str = "00" + num;
                else if ((num >= -9 && num <= -1) || (num >= 10 && num <= 99))
                    str = "0" + num;
                else if ((num >= -99 && num <= -10) || (num >= 100 && num <= 999))
                    str = num.ToString();
            }
            else if (temp.Contains(".") == true)
            {
                if (num <= -1 || num >= 10)
                {
                    num = Decimal.Round(num);
                    if ((num >= -9 && num <= -1) || (num >= 10 && num <= 99))
                        str = "0" + num;
                    else if ((num >= -99 && num <= -10) || (num >= 100 && num <= 999))
                        str = num.ToString();
                }
                else if (num >= 1 && num < 10)
                    str = temp.Substring(0, 3);
                else if (num >= 0 && num < 1)
                {
                    str = temp.Substring(1, 3);
                }
                else if (num >= -1 && num < 0)
                {
                    num = Decimal.Round(num, 1);
                    str = "-" + temp.Substring(2, 2);
                }
            }
            return str;
        }
    }
}
