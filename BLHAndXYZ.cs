using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
     public class BLHAndXYZ
    {
        public string PointName { get; set; } //点名称

        public double BData { get; set; } //纬度

        public double LData { get; set; } //经度

        public double HData { get; set; }  //高度

        public string Bstr { get; set; } //标准格式纬度

        public string Lstr { get; set; } //标准格式经度

        //public string Hstr { get; set; } //标准格式高度

        public double XData { get; set; } //空间X坐标

        public double YData { get; set; } //空间Y坐标

        public double ZData { get; set; } //空间Z坐标
    }
}
