using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    public static class FourParam
    {
        public static bool isSet = false;
        //平移参数X
        public static double X { get; set; }

        //平移参数Y
        public static double Y { get; set; }

        //旋转参数A
        public static double A { get; set; }

        //尺度参数M
        public static double M { get; set; }
    }
}
