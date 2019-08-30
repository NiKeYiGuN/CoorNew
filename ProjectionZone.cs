using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoorTransform
{
    enum ZoneType
    {
        ThreeZone,
        SixZone
    }
    /// <summary>
    /// 投影带类
    /// </summary>
    class ProjectionZone
    {
        public double ZoneNumber { get; set; }//投影带带号；
        public double CentralMeridianLongitude { get; set; }//中央子午线经度；
                                                            /// <summary>
                                                            /// 无参构造函数。
                                                            /// </summary>
        public ProjectionZone()
        {

        }
        /// <summary>
        /// 有参构造函数（根据经度计算投影带的带号及中央子午线经度）。
        /// </summary>
        /// <param name="longitude"></param>
        public ProjectionZone(double longitude, ZoneType zoneType)
        {
            if (zoneType == ZoneType.ThreeZone)//3°带
            {
                if ((longitude - 1.5) % 3 != 0)
                {
                    ZoneNumber = Math.Floor((longitude - 1.5) / 3) + 1;
                    CentralMeridianLongitude = 3 * ZoneNumber;
                }
                else
                {
                    ZoneNumber = Math.Floor((longitude - 1.5) / 3);
                    CentralMeridianLongitude = 3 * ZoneNumber;
                }
            }

            if (zoneType == ZoneType.SixZone)//6°带
            {
                if (longitude % 6 != 0)
                {
                    ZoneNumber = Math.Floor(longitude / 6) + 1;
                    CentralMeridianLongitude = 6 * ZoneNumber - 3;
                }
                else
                {
                    ZoneNumber = Math.Floor(longitude / 6);
                    CentralMeridianLongitude = 6 * ZoneNumber - 3;
                }
            }


        }
    }
 }
