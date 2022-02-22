using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {

        /// <summary>
        /// Trenin o anki hızına göre yavaşlama ivmesiyle duracağı mesafeyi bulur.
        /// </summary>
        public double CalculateBrakingDistance(double maxTrainDeceleration, double currentTrainSpeedCMS)
        {
            double brakingDistance = ((0.5) * maxTrainDeceleration * Math.Pow(currentTrainSpeedCMS / maxTrainDeceleration, 2));

            return brakingDistance;
        }


        //public TrackWithPosition CalculateLocationInTrack(Track track, Track nextTrack, Enums.Direction direction, Vehicle vehicle, double location)
        //{
        //    TrackWithPosition returnValues = new TrackWithPosition();// = Tuple.Create<double, Track>[];

        //    //double currentLocation = -1;

        //    //if (RouteTracks.Count == 0)
        //    //    return -1;

        //    // Bir önceki konum ile son zaman aralığında gidilen konum toplanır.
        //    if (direction == Enums.Direction.Right)
        //    {

        //        location = location + (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

        //        //if (location >= track.Track_End_Position + 0.1)
        //        if (location >= track.Track_Length + 0.1)
        //        {
        //            location = location - track.Track_Length;
        //            track = nextTrack;
        //        }


        //    }
        //    else if (direction == Enums.Direction.Left)
        //    {
        //        location = location - (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

        //        if (location <= 0.1)
        //        //if (location <= track.Track_Length + 0.1)
        //        //if (location <= track.Track_Start_Position - 0.1)
        //        {
        //            track = nextTrack;
        //            //location = track.Track_End_Position + location;

        //            location = track.Track_Length + location;
        //        }

        //    }

        //    //currentLocation = location;

        //    //bu değişecek
        //    //CurrentTrack = track;


        //    returnValues.Track = track;
        //    //returnValues.Location = currentLocation;
        //    returnValues.Location = location;


        //    TotalTrainDistance += (0.5 * (this.Vehicle.CurrentTrainSpeedCMS + this.Vehicle.PreviousSpeedCMS) * OperationTime);

        //    return returnValues;


        //}


        public TrackWithPosition CalculateLocationInTrack(Track track, Track nextTrack, Enums.Direction direction, Vehicle vehicle, double location)
        {
            TrackWithPosition returnValues = new TrackWithPosition();// = Tuple.Create<double, Track>[]; 

            // Bir önceki konum ile son zaman aralığında gidilen konum toplanır.
            if (direction == Enums.Direction.Right)
            {
                double osman = location; 

                location = location + (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime); 

                if (location >= track.Track_Length + 0.1) 
                {
                    if(track.Track_ID != nextTrack.Track_ID)
                    { 
                        location = location - track.Track_Length;
                        track = nextTrack;
                    }
                    else if (track.Track_ID == nextTrack.Track_ID)
                    {
                        location = osman; 
                    } 
                } 
            }
            else if (direction == Enums.Direction.Left)
            {
                double osman = location;

                location = location - (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

                if (location <= 0.1) 
                {
                    if (track.Track_ID != nextTrack.Track_ID)
                    {
                        track = nextTrack; 
                        location = track.Track_Length + location;
                    }
                    else if (track.Track_ID == nextTrack.Track_ID)
                    {
                        location = osman;
                    }
  
                }

            }
 
            returnValues.Track = track; 
            returnValues.Location = location;  

            TotalTrainDistance += (0.5 * (this.Vehicle.CurrentTrainSpeedCMS + this.Vehicle.PreviousSpeedCMS) * OperationTime);

            return returnValues; 
        }


        bool m_shouldStopRear = false;

        //public TrackWithPosition CalculateLocationInTrack(Track track, Track nextTrack, Enums.Direction direction, Vehicle vehicle, double location)
        //{
        //    TrackWithPosition returnValues = new TrackWithPosition();// = Tuple.Create<double, Track>[]; 

        //    // Bir önceki konum ile son zaman aralığında gidilen konum toplanır.
        //    if (direction == Enums.Direction.Right)
        //    {
        //        double osman = location;


        //        location = location + (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

        //        //if (location >= track.Track_Length + 0.1)
        //        if ((location >= track.Track_Length + 0.1) && (nextTrack != null))
        //        {
        //            location = location - track.Track_Length;
        //            track = nextTrack;


        //            returnValues.Track = track;
        //            returnValues.Location = location;
        //        }
        //        //else
        //        //{
        //        //    returnValues.Location = location;
        //        //}
        //        else if ((location >= track.Track_Length + 0.1) && (nextTrack == null))
        //        {
        //            location = osman;

        //            if (track.Track_ID == ActualFrontOfTrainCurrent.Track.Track_ID)
        //            {
        //                m_shouldStopRear = true;
        //            }

        //            //track = track;
        //        }


        //    }
        //    else if (direction == Enums.Direction.Left)
        //    {
        //        location = location - (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

        //        if (location <= 0.1)
        //        //if (location <= track.Track_Length + 0.1)
        //        //if (location <= track.Track_Start_Position - 0.1)
        //        {
        //            //if (track.Track_ID != nextTrack.Track_ID)
        //            {
        //                track = nextTrack;
        //                //location = track.Track_End_Position + location;

        //                location = track.Track_Length + location;
        //            }
        //        }

        //    }

        //    //currentLocation = location;

        //    //bu değişecek
        //    //CurrentTrack = track;

        //    //if (track.Track_ID != nextTrack.Track_ID)
        //    //{
        //    returnValues.Track = track;
        //    //returnValues.Location = currentLocation;
        //    returnValues.Location = location;
        //    //}



        //    TotalTrainDistance += (0.5 * (this.Vehicle.CurrentTrainSpeedCMS + this.Vehicle.PreviousSpeedCMS) * OperationTime);

        //    return returnValues;


        //}

        bool m_trainStop = false;

        public Tuple<TrackWithPosition, TrackWithPosition> CalculateTrainLocationInTrack(Vehicle vehicle, TrackWithPosition frontTrack, Track frontNextTrack, Enums.Direction direction, TrackWithPosition rearTrack, Track rearNextTrack)
        {
            TrackWithPosition front = new TrackWithPosition();
            TrackWithPosition rear = new TrackWithPosition(); 


            front = CalculateLocationInTrack(frontTrack.Track, frontNextTrack, direction, vehicle, frontTrack.Location);



            if ((front.Track.Track_ID != frontTrack.Track.Track_ID) && (front.Location != frontTrack.Location))
            {
                rear = CalculateLocationInTrack(rearTrack.Track, rearNextTrack, direction, vehicle, rearTrack.Location);
                m_trainStop = false;
            }
               
            else if ((front.Track.Track_ID == frontTrack.Track.Track_ID) && (front.Location != frontTrack.Location))
            {
                rear = CalculateLocationInTrack(rearTrack.Track, rearNextTrack, direction, vehicle, rearTrack.Location);
                m_trainStop = false;
            }
              
            else if ((front.Track.Track_ID == frontTrack.Track.Track_ID) && (front.Location == frontTrack.Location))
            {
                rear = rearTrack;
                m_trainStop = true;
            }
              

            //if (!m_shouldStopRear)
            //rear = CalculateLocationInTrack(rearTrack.Track, rearNextTrack, direction, vehicle, rearTrack.Location);
            //else
            //{
            //    rear = rearTrack;
            //}


            Tuple<TrackWithPosition, TrackWithPosition> calculateTrainLocationInTrack = Tuple.Create<TrackWithPosition, TrackWithPosition>(front, rear);

            return calculateTrainLocationInTrack;
        }

        public Vehicle CalculateSpeed(Vehicle vehicle)
        {
            double currentTrainSpeed = vehicle.CurrentTrainSpeedCMS;

            vehicle.PreviousSpeedCMS = vehicle.CurrentTrainSpeedCMS;

            if (vehicle.CurrentAcceleration == 0)  // ivme yoksa hız değişmez hız değişmiyorsa hiç ellemesek daha iyi değil mi? previousspeed değerini başka yerlerde kullanıyor muyuz?
            {
                currentTrainSpeed = vehicle.PreviousSpeedCMS;
            }
            else if (vehicle.CurrentAcceleration != 0)  // ivme varsa mevcut hıza ivme zaman çarpımı eklenir
            {
                currentTrainSpeed += (vehicle.CurrentAcceleration * OperationTime);
            }

            vehicle.CurrentTrainSpeedCMS = currentTrainSpeed;

            return vehicle;
        }


        //public double CalculateSpeed(Vehicle vehicle)
        //{
        //    //double currentTrainSpeed = 0;

        //    double currentTrainSpeed = vehicle.CurrentTrainSpeedCMS;

        //    vehicle.PreviousSpeedCMS = vehicle.CurrentTrainSpeedCMS;

        //    if (vehicle.CurrentAcceleration == 0)  // ivme yoksa hız değişmez hız değişmiyorsa hiç ellemesek daha iyi değil mi? previousspeed değerini başka yerlerde kullanıyor muyuz?
        //    {
        //        currentTrainSpeed = vehicle.PreviousSpeedCMS;
        //    }
        //    else if (vehicle.CurrentAcceleration != 0)  // ivme varsa mevcut hıza ivme zaman çarpımı eklenir
        //    {
        //        currentTrainSpeed += (vehicle.CurrentAcceleration * OperationTime);
        //    }




        //    //if (currentTrainSpeed = vehicle.TargetSpeedCMS)
        //    //    currentTrainSpeed = vehicle.TargetSpeedCMS;

        //    //if (currentTrainSpeed > 40)
        //    //    currentTrainSpeed = vehicle.TargetSpeedCMS;

        //    return currentTrainSpeed;
        //}


        //public Tuple<double, Track> CalculateLocation(Track track, Track nextTrack, Enums.Direction direction, Vehicle vehicle, double location)
        //{
        //    Tuple<double, Track> returnValues;// = Tuple.Create<double, Track>[];

        //    double currentLocation = -1;

        //    //if (RouteTracks.Count == 0)
        //    //    return -1;

        //    // Bir önceki konum ile son zaman aralığında gidilen konum toplanır.
        //    if (direction == Enums.Direction.Right)
        //    {



        //        location = location + (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);

        //        //if (location >= track.Track_End_Position + 0.1)
        //        if (location >= track.Track_Length + 0.1)
        //        {
        //            double cation = location - track.Track_End_Position;
        //            location = location - track.Track_Length;
        //            track = nextTrack;
        //        }


        //    }
        //    else if (direction == Enums.Direction.Left)
        //    {
        //        location = location - (0.5 * (vehicle.CurrentTrainSpeedCMS + vehicle.PreviousSpeedCMS) * OperationTime);


        //        //if (location <= track.Track_Length + 0.1)
        //        if (location <= track.Track_Start_Position - 0.1)
        //        {
        //            track = nextTrack;
        //            //location = track.Track_End_Position + location;

        //            location = track.Track_Length + location;
        //        }

        //    }

        //    currentLocation = location;

        //    //bu değişecek
        //    //CurrentTrack = track;


        //    returnValues = Tuple.Create<double, Track>(currentLocation, track);


        //    TotalTrainDistance += (0.5 * (this.Vehicle.CurrentTrainSpeedCMS + this.Vehicle.PreviousSpeedCMS) * OperationTime);

        //    return returnValues;


        //}


    }
}
