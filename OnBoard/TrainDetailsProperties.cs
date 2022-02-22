using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class TrainDetailsProperties  
    {
        [Category("ATS Server")]
        public Enums.SkipStation SkipStationStatus { get; set; }

        [Category("ATS Server")]
        public Enums.CancelSkipStation CancelSkipStationStatus { get; set; }
        [Category("ATS Server")]
        public bool SkipStation { get; set; }
        [Category("ATS Server")]
        public bool CancelSkipStation { get; set; }


        [Category("ATS Server")]
        public Enums.HoldTrain HoldTrainStatus { get; set; }

        [Category("ATS Server")]
        public bool CancelHoldStationAccepted { get; set; }
        [Category("ATS Server")]
        public bool HoldStation { get; set; }





        [Category("Vehicle")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Vehicle Vehicle { get; set; }






        [Category("Real Location Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition ActualFrontOfTrainCurrent { get; set; }

        [Category("Real Location Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition ActualRearOfTrainCurrent { get; set; }


        [Category("FootPrint Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition FrontOfTrainTrackWithFootPrint { get; set; }

        [Category("FootPrint Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition RearOfTrainTrackWithFootPrint { get; set; }


        [Category("Virtual Occupation Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition FrontOfTrainVirtualOccupation { get; set; }

        [Category("Virtual Occupation Tracks")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TrackWithPosition RearOfTrainVirtualOccupation { get; set; }


        public double FrontOfTrainLocationWithFootPrintInRoute { get; set; }

        public double RearOfTrainLocationWithFootPrintInRoute { get; set; }

        [Category("Next Track")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Track FrontOfTrainNextTrack { get; set; }
        [Category("Next Track")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Track RearOfTrainNextTrack { get; set; }

        [Category("Location Fault Values")]
        public double FrontOfTrainLocationFault { get; set; }
        [Category("Location Fault Values")]
        public double RearOfTrainLocationFault { get; set; }





        [Category("Direction")]
        public Enums.Direction Direction { get; set; }
        [Category("Direction")]
        public Enums.Direction RearDirection { get; set; }



        [Category("Door")]
        public int DwellTime { get; set; }
        [Category("Door")]
        public Enums.DoorStatus DoorStatus { get; set; }


        [Category("OBATP")]
        public Enums.Status Status { get; set; }
        [Category("ATS Server")]
        public bool TrainAbsoluteZeroSpeed { get; set; }
        [Category("ATS Server")]
        public bool OBATCtoWSATC_BerthingOk { get; set; }


        [Category("MovementAuthorityTracks")]
        [TypeConverter(typeof(MyTypeConverter))]
        public List<Track> movementTrack { get; set; }


        private  ThreadSafeList<Track> zozomovementTrack { get; set; }


        [Category("FootPrint Tracks")]
        [TypeConverter(typeof(MyTypeConverter))]
        public List<Track> footPrintTracks { get; set; }

        [Category("Virtual Occupation Tracks")]
        [TypeConverter(typeof(MyTypeConverter))]
        public List<Track> virtualOccupationTracks { get; set; }


        //[Category("FootPrint Tracks")]
        //[TypeConverter(typeof(MyTypeConverter))]
        //public ushort[] footPrintTracks { get; set; }

        //[Category("Virtual Occupation Tracks")]
        //[TypeConverter(typeof(MyTypeConverter))]
        //public ushort[] virtualOccupationTracks { get; set; }
        public TrainDetailsProperties()
        {

        }

        public TrainDetailsProperties ConvertThis(OBATP OBATP)
        {
            this.SkipStationStatus = OBATP.SkipStationStatus;
            this.CancelSkipStationStatus = OBATP.CancelSkipStationStatus;
            this.HoldTrainStatus = OBATP.HoldTrainStatus;
            this.DoorStatus = OBATP.DoorStatus;
 

            this.TrainAbsoluteZeroSpeed = OBATP.TrainAbsoluteZeroSpeed;
            this.OBATCtoWSATC_BerthingOk = OBATP.OBATCtoWSATC_BerthingOk;



            this.SkipStation = OBATP.SkipStation;
            this.HoldStation = OBATP.HoldStation;
            this.CancelHoldStationAccepted = OBATP.CancelHoldStationAccepted;
            this.CancelSkipStation = OBATP.CancelSkipStation;  



            this.FrontOfTrainNextTrack = OBATP.FrontOfTrainNextTrack;
            this.RearOfTrainNextTrack = OBATP.RearOfTrainNextTrack;

             

            this.ActualFrontOfTrainCurrent = OBATP.ActualFrontOfTrainCurrent;
            this.ActualRearOfTrainCurrent = OBATP.ActualRearOfTrainCurrent;

            this.FrontOfTrainTrackWithFootPrint = OBATP.FrontOfTrainTrackWithFootPrint;
            this.RearOfTrainTrackWithFootPrint = OBATP.RearOfTrainTrackWithFootPrint;

            this.FrontOfTrainVirtualOccupation = OBATP.FrontOfTrainVirtualOccupation;
            this.RearOfTrainVirtualOccupation = OBATP.RearOfTrainVirtualOccupation;

            zozomovementTrack = OBATP.movementTrack;

            this.movementTrack = OBATP.movementTrack.ToList();

            this.FrontOfTrainLocationFault = OBATP.FrontOfTrainLocationFault;
            this.RearOfTrainLocationFault = OBATP.RearOfTrainLocationFault;


            this.DwellTime = OBATP.zongurt;


            this.Direction = OBATP.Direction;
            this.RearDirection = OBATP.RearDirection;

            this.Vehicle = OBATP.Vehicle;

            this.Status = OBATP.Status;


            this.footPrintTracks = HelperClass.FindTrackRangeInAllTracksTrainDetail(this.FrontOfTrainTrackWithFootPrint.Track, this.RearOfTrainTrackWithFootPrint.Track, zozomovementTrack);
            this.virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracksTrainDetail(this.FrontOfTrainVirtualOccupation.Track, this.RearOfTrainVirtualOccupation.Track, zozomovementTrack);


            //this.footPrintTracks = HelperClass.FindTrackRangeInAllTracks(this.FrontOfTrainTrackWithFootPrint.Track, this.RearOfTrainTrackWithFootPrint.Track, zozomovementTrack);
            //this.virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracks(this.FrontOfTrainVirtualOccupation.Track, this.RearOfTrainVirtualOccupation.Track, zozomovementTrack);


            return this;
        }
      

      


    }
}
