using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    /// <summary>
    /// 角度类
    /// </summary>
    public class Angle
    {
        public double Degree;//度
        public double Min;//分
        public double Sec;//秒
        public double Arc;//弧度单位

        /// <summary>
        /// 通过字符串构造一个角度，并得到该角度的所有属性。
        /// </summary>
        /// <param name="str"></param>
        public double GetArc(string str)
        {
            Degree = Math.Floor(Convert.ToDouble(str));
            Min = Math.Floor((Convert.ToDouble(str) - Degree) * 100);
            Sec = ((Convert.ToDouble(str) - Degree) * 100 - Min) * 100;
            Arc = (Degree + Min / 60 + Sec / 3600) * (Math.PI / 180);
            return Arc;
        }
        /// <summary>
        /// 将弧度转换为DD.MMSSS的度分秒形式，其中DD表示度，MM表示分，SSS表示SS.S秒
        /// </summary>
        /// <param name="arc"></param>
        /// <returns></returns>
        public static double ArcToDMS(double arc)
        {
            double resultange = 0;
            string angle = "";
            double degree1 = arc * 180 / Math.PI;    //  带小数点的度
            double degree = Math.Floor(degree1);//度
            double min = Math.Floor((degree1 - degree) * 60);//分
            double sec = Math.Round((degree1 * 3600 - degree * 3600 - min * 60), 5);//秒,保留5位小数，即SS.S
            string minstr = min.ToString();
            if (minstr.Length == 1)
            {
                minstr = "0" + minstr;
            }
            string secStr = sec.ToString();
            if (sec < 10)
            {
                secStr = "0" + secStr;

            }

            if (secStr.IndexOf(".") != -1)
            {
                secStr = secStr.Remove(secStr.IndexOf("."), 1);
            }

            //DD.MMSSS,比如：35.01022
            angle = degree.ToString() + "." + minstr + secStr;
            resultange = Convert.ToDouble(angle);

            while (resultange < 0)
            {
                resultange = resultange + 180;
            }
          
            return resultange;
        }
    }
}
