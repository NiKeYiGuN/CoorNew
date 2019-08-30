using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    public static class Ellipsoid
    {
        //椭球名称
        public static string EllipsoidName { get; set; }

        //椭球长半轴
        public static double a { get; set; }

        //椭球短半轴
        public static double b { get; set; }

        //椭球扁率
        public static double f { get; set; }

        //椭球第一偏心率 
        public static double e { get; set; }

        //椭球第二偏心率
        public static double se { get; set; }

        //系数a×（1-e²）
        public static double M0 { get; set; }

        public static double[] c = new double[6];

        public static void Instance(string str)
        {
            switch (str)
            {
                case "北京54坐标":
                    EllipsoidName = str;
                    a = 6378245;
                    f = 0.003352329863;
                    ParamsCal();
                    break;
                case "西安80坐标":
                    EllipsoidName = str;
                    a = 6378140;
                    f = 0.003352813178;
                    ParamsCal();
                    break;
                case "WGS84坐标":
                    EllipsoidName = str;
                    a = 6378137;
                    f = 0.000003352813;
                    ParamsCal();
                    break;
            }

            GetM0();
            GetCoef();
        }

        /// <summary>
        /// 获得短半轴、第一扁心率的平方、第二扁心率的平方
        /// </summary>
        public static void ParamsCal()
        {
            b = a - a * f;
            e = (a * a - b * b) / (a * a);
            se = (a * a - b * b) / (b * b);
        }

        /// <summary>
        /// 获得系数a×（1-e²）
        /// </summary>
        public static void GetM0()
        {
            M0 = a * (1 - e);
        }

        /// <summary>
        /// 获得子午线长度计算相关参数数组(因该参数只和椭球参数有关)。
        /// </summary>
        /// <param name="c"></param>
        public static void GetCoef()
        {
            double Ac, Bc, Cc, Dc, Ec, Fc;
            Ac = 1 + 3 / 4 * e + 45 / 64 * Math.Pow(e, 2) + 175 / 256 * Math.Pow(e, 3) + 11025 / 16384 * Math.Pow(e, 4) + 43659 / 65536 * Math.Pow(e, 5);
            Bc = 3 / 4 * e + 15 / 16 * Math.Pow(e, 2) + 525 / 512 * Math.Pow(e, 3) + 2205 / 2048 * Math.Pow(e, 4) + 72765 / 65536 * Math.Pow(e, 5);
            Cc = 15 / 64 * Math.Pow(e, 2) + 105 / 256 * Math.Pow(e, 3) + 2205 / 4096 * Math.Pow(e, 4) + 10395 / 16384 * Math.Pow(e, 5);

            Dc = 35 / 512 * Math.Pow(e, 3) + 315 / 2048 * Math.Pow(e, 4) + 31185 / 131072 * Math.Pow(e, 5);
            Ec = 315 / 16384 * Math.Pow(e, 4) + 3465 / 65536 * Math.Pow(e, 5);
            Fc = 693 / 131072 * Math.Pow(e, 5);
           
            c[0] = Ac * M0;
            c[1] = -Bc * M0 / 2.0;
            c[2] = Cc * M0 / 4.0;
            c[3] = -Dc * M0 / 6.0;
            c[4] = Ec * M0 / 8.0;
            c[5] = -Fc * M0 / 10.0;
            //return c;
        }
    }
}
