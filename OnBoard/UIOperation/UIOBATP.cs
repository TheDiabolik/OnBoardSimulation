using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class UIOBATP :  IDisposable
    {
        private bool m_disposed = false;

        //general
        public string ID { get; set; }
        public string Train_Name { get; set; }
        public string Speed { get; set; }
        //front
        public string Front_Track_ID { get; set; }
        public string Front_Track_Location { get; set; }
        public string Front_Track_Length { get; set; }
        public string Front_Track_Max_Speed { get; set; }
        //rear
        public string Rear_Track_ID { get; set; }
        public string Rear_Track_Location { get; set; }
        public string Rear_Track_Length { get; set; }
        public string Rear_Track_Max_Speed { get; set; }

        //general
        public string Total_Route_Distance { get; set; }


        [Browsable(false)]
        public TrainOnTracks TrainOnTracks = new TrainOnTracks();

      
        [Browsable(false)]
        public bool RefreshRouteTracks { get; set; }


        [Browsable(false)]
        public bool NewMovementAuthorityTracksCome { get; set; }


        [Browsable(false)]
        public bool RefreshActualLocationTracks { get; set; }

        [Browsable(false)]
        public bool RefreshFootPrintTracks { get; set; }

        [Browsable(false)]
        public bool RefreshVirtualOccupationTracks { get; set; }


        [Browsable(false)]
        public ThreadSafeList<Track> NewMovementAuthorityTracks = new ThreadSafeList<Track>();


        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Dispose time code 
                    //buraya sonlanma için method eklenecek
                }

                // Finalize time code 
                m_disposed = true;
            }


        }

        public void Dispose()
        {
            //if (m_disposed)
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }

    }
}
