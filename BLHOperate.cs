using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    public static class BLHOperate
    {        
       /// <summary>
       /// 得到空间坐标X
       /// </summary>
       /// <param name="b"></param>
       /// <param name="l"></param>
       /// <param name="h"></param>
       /// <returns></returns>
        public static double GetXData(double b,double l,double h)
        {
            double W = 0;
            double N = 0;

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(b), 2)),0.5);
            N = Ellipsoid.a / W;

            return Math.Round((N + h) * Math.Cos(b) * Math.Cos(l),4);
        }

        /// <summary>
        /// 得到空间坐标Y
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static double GetYData(double b, double l, double h)
        {
            double W = 0;
            double N = 0;

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(b), 2)), 0.5);
            N = Ellipsoid.a / W;

            return Math.Round((N + h) * Math.Cos(b) * Math.Sin(l),4);            
        }

        /// <summary>
        /// 得到空间坐标Z
        /// </summary>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static double GetZData(double b,double h)
        {
            double W = 0;
            double N = 0;

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(b), 2)), 0.5);
            N = Ellipsoid.a / W;

            return Math.Round((N * (1 - Ellipsoid.e) + h)*Math.Sin(b),4);
        }

        /// <summary>
        /// 转化为标准字符串格式
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string NumToAngle(double num)
        {
            string resultStr = "";
            string[] arryStr = num.ToString("f6").Split('.');

            resultStr = arryStr[0]+ "°"+arryStr[1].Substring(0,2)+"'"+ arryStr[1].Substring(2,2)+"."+arryStr[1].Substring(4,2)+"00"+"\"";

            return resultStr;
        }

        public static string GetLData(double x,double y)
        {
            double rad = Math.Atan(y / x);
            return NumToAngle(Angle.ArcToDMS(rad));
        }

        public static string GetBData(double x,double y,double z)
        {
            double tmpRad = Math.Atan(z * Ellipsoid.a / ((Math.Pow((x * x + y * y), 0.5)) * Ellipsoid.b));

            double rabB = Math.Atan(((z + Ellipsoid.se * Math.Pow(Math.Sin(tmpRad), 3))) / (Math.Pow((x * x + y * y), 0.5) -  Ellipsoid.e * Ellipsoid.a * Math.Pow(Math.Cos(tmpRad), 3)));
            return NumToAngle(Angle.ArcToDMS(rabB));            
        }

        public static double getHData(double x,double y,double z)
        {
            double W = 0;
            double N = 0;
            double tmpRad = Math.Atan(z * Ellipsoid.a / ((Math.Pow((x * x + y * y), 0.5)) * Ellipsoid.b));
            double b = Math.Atan((z +  Ellipsoid.se * Math.Pow(Math.Sin(tmpRad), 3)) / (Math.Pow((x * x + y * y), 0.5) -  Ellipsoid.e * Ellipsoid.a * Math.Pow(Math.Cos(tmpRad), 3)));

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(b), 2)), 0.5);
            N = Ellipsoid.a / W;

            //return Math.Pow((x * x + y * y),0.5) / Math.Cos(b) - N;
            return (z / Math.Sin(b)) - N * (1 - Ellipsoid.e);
        }

        /// <summary>
        /// 计算平面XY坐标
        /// </summary>
        /// <returns></returns>
        public static double[] GetFlatXYData(double b, double l,string bandStr)
        {
            double[] XY = new double[2];
            //子午弧长
            double X = Ellipsoid.c[0] * b + Ellipsoid.c[1] * Math.Sin(2 * b) + Ellipsoid.c[2] * Math.Sin(4 * b)
                       + Ellipsoid.c[3] * Math.Sin(6 * b) + Ellipsoid.c[4] * Math.Sin(8 * b) + Ellipsoid.c[5] * Math.Sin(10 * b);

            double CentralMeridianLongitude = GetCentralMeridianLongitude(l, bandStr);
            double tl = l - CentralMeridianLongitude;

            double W = 0;
            double N = 0;

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(b), 2)), 0.5);
            N = Ellipsoid.a / W;

            double sn = Ellipsoid.se * Math.Cos(b) * Math.Cos(b);
            double t = Math.Tan(b);

            //文档上的公式
            //double a0 = X;
            //double a1 = N * Math.Cos(b);
            //double a2 = N * Math.Cos(b) * Math.Cos(b) * t / 2.0;
            //double a3 = N * Math.Pow(Math.Cos(b), 3) * (1 - t * t + sn) / 6.0;
            //double a4 = N * Math.Pow(Math.Cos(b), 4) * (5 - t * t + 9 * sn + 4 * sn * sn) * t / 24.0;
            //double a5 = N * Math.Pow(Math.Cos(b), 5) * (5 - 18 * t * t + Math.Pow(t, 4) + 14 * sn * sn - 58 * t * t * sn) / 120.0;
            //double a6 = N * Math.Pow(Math.Cos(b), 6) * (61 - 58 * t * t + Math.Pow(t, 4) + 270 * sn - 330 * sn * t * t) * t / 720.0;

            ///网上的文档公式
            double p = (180 / Math.PI )* 3600;
            double a0 = X;
            double a1 = N * Math.Cos(b)/p;
            double a2 = N * Math.Sin(b) * Math.Cos(b) * t / (2.0*p*p);
            double a3 = N * Math.Pow(Math.Cos(b), 3) * (1 - t * t + sn) / (6.0*Math.Pow(p,3));
            double a4 = N * Math.Sin(b)*Math.Pow(Math.Cos(b), 3) * (5 - t * t + 9 * sn + 4 * sn * sn) / (24.0*Math.Pow(p,4));
            double a5 = N * Math.Pow(Math.Cos(b), 5) * (5 - 18 * t * t + Math.Pow(t, 4) + 14 * sn * sn - 58 * t * t * sn) / (120.0*Math.Pow(p,5));
            double a6 = N *Math.Sin(b)* Math.Pow(Math.Cos(b), 5) * (61 - 58 * t * t + Math.Pow(t, 4)) / (720.0*Math.Pow(p,6));

            XY[0] = a0 + a2 * tl * tl + a4 * Math.Pow(tl, 4) + a6 * Math.Pow(tl, 6);
            XY[1] = a1 * tl + a4 * Math.Pow(tl, 3) + a5 * Math.Pow(tl, 5)+500000;

            return XY;
        }

        public static double GetCentralMeridianLongitude(double l,string bandStr)
        {
            double ZoneNumber = 0;

            if (bandStr == "3°")//3°带
            {
                if ((l - 1.5) % 3 != 0)
                {
                    ZoneNumber = Math.Floor((l - 1.5) / 3) + 1;
                    return  3 * ZoneNumber;
                }
                else
                {
                    ZoneNumber = Math.Floor(( - 1.5) / 3);
                    return 3 * ZoneNumber;
                }
            }

            else if(bandStr == "6°")//6°带
            {
                if (l % 6 != 0)
                {
                    ZoneNumber = Math.Floor(l / 6) + 1;
                    return  6 * ZoneNumber - 3;
                }
                else
                {
                    ZoneNumber = Math.Floor(l / 6);
                    return  6 * ZoneNumber - 3;
                }
            }
            else
            {
                return 0;
            }
        }

        public static string[] GetBLData(double x,double y)
        {
            string[] BLStr = new string[2];
            double CentralMeridianLongitude = 110;  //中央子午线取固定值 
            double Bf = GetLatitudeByMeridianLength(x, Ellipsoid.c);
            
            double W = 0;
            double Nf = 0;

            W = Math.Pow((1 - Ellipsoid.e * Math.Pow(Math.Sin(Bf), 2)), 0.5);
            Nf = Ellipsoid.a / W;
            double snf = Ellipsoid.se * Math.Cos(Bf) * Math.Cos(Bf);
            double tf = Math.Tan(Bf);
            double Mf = Ellipsoid.a * (1 - Ellipsoid.e) / Math.Pow(W, 3);

            //文档上的公式
            //double B0 = Bf;
            //double B1 = 1 / (Nf * Math.Cos(Bf));
            //double B2 = -tf / (2 * Mf * Nf);
            //double B3 = -(1 + 2 * tf * tf + snf) * B1 / (6 * Nf * Nf);
            //double B4 = -(5 + 3 * tf * tf + snf - 9 * snf * tf * tf) * B2 / (12 * Nf * Nf);
            //double B5 = -(5 + 28 * tf * tf + 24 * Math.Pow(tf, 4) + 6 * snf + 8 * snf * tf * tf) * B1 / (120 * Math.Pow(Nf, 4));
            //double B6 = (61 + 90 * tf * tf + 45 * Math.Pow(tf, 4)) * B2 / (360 * Math.Pow(Nf, 4));

            //网上的公式
            double B0 = Bf;
            double B1 = 1 / (Nf * Math.Cos(Bf));
            double B2 = -tf / (2 * Mf * Nf);
            double B3 = -(1 + 2 * tf * tf + snf) / (6 * Nf * Nf*Nf*Math.Cos(Bf));
            double B4 = (5 + 3 * tf * tf + snf - 9 * snf * tf * tf) / (24 *Mf* Nf * Nf*Nf);
            double B5 = (5 + 28 * tf * tf + 24 * Math.Pow(tf, 4) + 6 * snf + 8 * snf * tf * tf)  / (120 * Math.Pow(Nf, 5)*Nf);
            double B6 = -(61 + 90 * tf * tf + 45 * Math.Pow(tf, 4)) / (720 * Mf * Math.Pow(Nf, 5));



            BLStr[0] = NumToAngle(Angle.ArcToDMS(B0 + B2 * y * y + B4 * Math.Pow(y, 4) + B6 * Math.Pow(y, 6)));
            //BLStr[1] = NumToAngle(Angle.ArcToDMS(B1 * y + B3 * Math.Pow(y, 3) + B5 * Math.Pow(y, 5) + CentralMeridianLongitude));

            //BLStr[0] = NumToAngle((B0 + B2 * y * y + B4 * Math.Pow(y, 4) + B6 * Math.Pow(y, 6)));

            BLStr[1] = NumToAngle((B1 * y + B3 * Math.Pow(y, 3) + B5 * Math.Pow(y, 5) + CentralMeridianLongitude));

            return BLStr;
        }

        /// <summary>
        /// 根据子午线弧长和子午线弧长计算的系数数组计算底点纬度。(迭代法)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double GetLatitudeByMeridianLength(double X, double[] c)
        {
            double Bf = 0.0;//底点纬度。
            List<double> Blist = new List<double>();
            double B0 = X / c[0];
            Blist.Add(B0);
            double delta = 0.0;
            delta = c[1] * Math.Sin(2 * B0) + c[2] * Math.Sin(4 * B0) + c[3] * Math.Sin(6 * B0) + c[4] * Math.Sin(8 * B0) + c[5] * Math.Sin(10 * B0);
            Bf = (X - delta) / c[0];
            Blist.Add(Bf);
            int jsq = 0;
            do
            {
                delta = c[1] * Math.Sin(2 * Bf) + c[2] * Math.Sin(4 * Bf) + c[3] * Math.Sin(6 * Bf) + c[4] * Math.Sin(8 * Bf) + c[5] * Math.Sin(10 * Bf);
                Bf = (X - delta) / c[0];
                Blist.Add(Bf);
                jsq++;
            } while (Math.Abs((Blist[jsq] - Blist[jsq - 1])) >= 0.00000001);

            return Bf;
        }
    }
}
