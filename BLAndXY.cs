using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    public class BLAndXY
    {
        public string PointName { get; set; } //点名称

        public double BData { get; set; } //纬度

        public double LData { get; set; } //经度
        public string Bstr { get; set; } //标准格式纬度

        public string Lstr { get; set; } //标准格式经度

        public double XData { get; set; } //平面X坐标

        public double YData { get; set; } //平面Y坐标
    }
}
