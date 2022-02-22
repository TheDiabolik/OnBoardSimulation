using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    [Serializable]
    public class TrainOnTracks
    {
        public ThreadSafeList<Track> ActualLocationTracks = new ThreadSafeList<Track>();
        public ThreadSafeList<Track> FootPrintTracks = new ThreadSafeList<Track>();
        public ThreadSafeList<Track> VirtualOccupationTracks = new ThreadSafeList<Track>();
    }
}
