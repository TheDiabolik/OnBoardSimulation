using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    [Serializable]
    public struct TrackWithPosition
    {
        //public volatile Track Track;
        [Category("Track")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public   Track Track { get; set; }

        //public volatile WrappedVolatileDouble Location;
        public   double Location { get; set; }

    }

    //public class VolatileDoubleDemo
    //{
    //    private volatile WrappedVolatileDouble volatileData;
    //}
    //public class WrappedVolatileDouble
    //{
    //    public double Data { get; set; }
    //}
}