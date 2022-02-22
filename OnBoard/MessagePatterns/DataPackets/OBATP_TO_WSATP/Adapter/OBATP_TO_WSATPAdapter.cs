using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class OBATP_TO_WSATPAdapter : OBATP_TO_WSATP
    {
        private OBATP_TO_WSATPAdaptee _adaptee;



        public OBATP_TO_WSATPAdapter(OBATP OBATPToAdapt)
        {
            _adaptee = new OBATP_TO_WSATPAdaptee(OBATPToAdapt);


            AdaptData();
        }

        public void AdaptData()
        {
            base.EmergencyBrakeApplied = _adaptee.EmergencyBrakeApplied.BoolToHex(); 
            base.TrainAbsoluteZeroSpeed = _adaptee.TrainAbsoluteZeroSpeed.BoolToHex();
            base.AllTrainDoorsClosedAndLocked = _adaptee.AllTrainDoorsClosedAndLocked.BoolToHex();
            base.EnablePSD1 = Convert.ToByte(_adaptee.EnablePSD1);
            base.EnablePSD2 = Convert.ToByte(_adaptee.EnablePSD2);
            //OBATP_TO_WSATP.ActiveATP = Convert.ToByte("\x02".Substring(2), NumberStyles.HexNumber); // Encoding.ASCII.GetBytes("\x02");
            base.ActiveATP = Convert.ToByte(_adaptee.ActiveATP); // Byte.Parse("0x02".Substring(2), NumberStyles.HexNumber); // Encoding.ASCII.GetBytes("\x02");
            base.ActiveCab = Convert.ToByte(_adaptee.ActiveCab);//Convert.ToByte("\x03");
            base.TrainDirection = Convert.ToByte(_adaptee.TrainDirection);
            base.TrainCoupled = Convert.ToByte(_adaptee.TrainCoupled); //Byte.Parse("0x04".Substring(2), NumberStyles.HexNumber); //Convert.ToByte("\x04");
            base.TrainIntegrity = _adaptee.TrainIntegrity.BoolToHex();
            base.TrainLocationDeterminationFault = _adaptee.TrainLocationDeterminationFault.BoolToHex();
            base.TrackDatabaseVersionMajor = Convert.ToByte(_adaptee.TrackDatabaseVersionMajor);
            base.TrackDatabaseVersionMinor = Convert.ToByte(_adaptee.TrackDatabaseVersionMinor);
            base.TrainDerailment = _adaptee.TrainDerailment.BoolToHex();


            ////footprint
            //base.FootPrintTrackSectionID1 = _adaptee.FootPrintTrackSectionID[0];
            //base.FootPrintTrackSectionID2 = _adaptee.FootPrintTrackSectionID[1];
            //base.FootPrintTrackSectionID3 = _adaptee.FootPrintTrackSectionID[2];
            //base.FootPrintTrackSectionID4 = _adaptee.FootPrintTrackSectionID[3];
            //base.FootPrintTrackSectionID5 = _adaptee.FootPrintTrackSectionID[4];
            //base.FootPrintTrackSectionID6 = _adaptee.FootPrintTrackSectionID[5];
            //base.FootPrintTrackSectionID7 = _adaptee.FootPrintTrackSectionID[6];
            //base.FootPrintTrackSectionID8 = _adaptee.FootPrintTrackSectionID[7];
            //base.FootPrintTrackSectionID9 = _adaptee.FootPrintTrackSectionID[8];
            //base.FootPrintTrackSectionID10 = _adaptee.FootPrintTrackSectionID[9];
            //base.FootPrintTrackSectionID11 = _adaptee.FootPrintTrackSectionID[10];
            //base.FootPrintTrackSectionID12 = _adaptee.FootPrintTrackSectionID[11];
            //base.FootPrintTrackSectionID13 = _adaptee.FootPrintTrackSectionID[12];
            //base.FootPrintTrackSectionID14 = _adaptee.FootPrintTrackSectionID[13];
            //base.FootPrintTrackSectionID15 = _adaptee.FootPrintTrackSectionID[14];



            ////footprint
            //base.VirtualOccupancyTrackSectionID1 = _adaptee.VirtualOccupancyTrackSectionID[0];
            //base.VirtualOccupancyTrackSectionID2 = _adaptee.VirtualOccupancyTrackSectionID[1];
            //base.VirtualOccupancyTrackSectionID3 = _adaptee.VirtualOccupancyTrackSectionID[2];
            //base.VirtualOccupancyTrackSectionID4 = _adaptee.VirtualOccupancyTrackSectionID[3];
            //base.VirtualOccupancyTrackSectionID5 = _adaptee.VirtualOccupancyTrackSectionID[4];
            //base.VirtualOccupancyTrackSectionID6 = _adaptee.VirtualOccupancyTrackSectionID[5];
            //base.VirtualOccupancyTrackSectionID7 = _adaptee.VirtualOccupancyTrackSectionID[6];
            //base.VirtualOccupancyTrackSectionID8 = _adaptee.VirtualOccupancyTrackSectionID[7];
            //base.VirtualOccupancyTrackSectionID9 = _adaptee.VirtualOccupancyTrackSectionID[8];
            //base.VirtualOccupancyTrackSectionID10 = _adaptee.VirtualOccupancyTrackSectionID[9];
            //base.VirtualOccupancyTrackSectionID11 = _adaptee.VirtualOccupancyTrackSectionID[10];
            //base.VirtualOccupancyTrackSectionID12 = _adaptee.VirtualOccupancyTrackSectionID[11];
            //base.VirtualOccupancyTrackSectionID13 = _adaptee.VirtualOccupancyTrackSectionID[12];
            //base.VirtualOccupancyTrackSectionID14 = _adaptee.VirtualOccupancyTrackSectionID[13];
            //base.VirtualOccupancyTrackSectionID15 = _adaptee.VirtualOccupancyTrackSectionID[14];
            //base.VirtualOccupancyTrackSectionID16 = _adaptee.VirtualOccupancyTrackSectionID[15];
            //base.VirtualOccupancyTrackSectionID17 = _adaptee.VirtualOccupancyTrackSectionID[16];
            //base.VirtualOccupancyTrackSectionID18 = _adaptee.VirtualOccupancyTrackSectionID[17];
            //base.VirtualOccupancyTrackSectionID19 = _adaptee.VirtualOccupancyTrackSectionID[18];
            //base.VirtualOccupancyTrackSectionID20 = _adaptee.VirtualOccupancyTrackSectionID[19]; 

            Array.Copy(_adaptee.FootPrintTrackSectionID, base.FootPrintTrackSectionID, _adaptee.FootPrintTrackSectionID.Length);
            Array.Copy(_adaptee.VirtualOccupancyTrackSectionID, base.VirtualOccupancyTrackSectionID, _adaptee.VirtualOccupancyTrackSectionID.Length);

            base.BerthingOk = _adaptee.BerthingOk.BoolToHex();


            base.TrainNumber = Convert.ToByte(_adaptee.TrainNumber);


        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} : {1}", "EmergencyBrakeApplied", _adaptee.EmergencyBrakeApplied.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrainAbsoluteZeroSpeed", _adaptee.TrainAbsoluteZeroSpeed.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "AllTrainDoorsClosedAndLocked", _adaptee.AllTrainDoorsClosedAndLocked.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "EnablePSD1", _adaptee.EnablePSD1.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "EnablePSD2", _adaptee.EnablePSD2.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "ActiveATP", _adaptee.ActiveATP.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "TrainDirection", ((Enums.Direction)_adaptee.TrainDirection).ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrainCoupled", _adaptee.TrainCoupled.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "TrainIntegrity",  _adaptee.TrainIntegrity.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrainLocationDeterminationFault", _adaptee.TrainLocationDeterminationFault.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "TrackDatabaseVersionMajor", _adaptee.TrackDatabaseVersionMajor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrackDatabaseVersionMinor", _adaptee.TrackDatabaseVersionMinor.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "TrainDerailment", _adaptee.TrainDerailment.ToString());
            stringBuilder.AppendLine();




            for (int i = 0; i < _adaptee.FootPrintTrackSectionID.Length; i++)
            {
                stringBuilder.AppendFormat("{0}{1} : {2}", "FootPrintTrackSectionID", (i + 1).ToString(), _adaptee.FootPrintTrackSectionID[i].ToString());
                stringBuilder.AppendLine();

            }

            for (int i = 0; i < _adaptee.VirtualOccupancyTrackSectionID.Length; i++)
            {
                stringBuilder.AppendFormat("{0}{1} : {2}", "VirtualOccupancyTrackSectionID", (i + 1).ToString(), _adaptee.VirtualOccupancyTrackSectionID[i].ToString());
                stringBuilder.AppendLine();

            }




            stringBuilder.AppendFormat("{0} : {1}", "BerthingOk", _adaptee.BerthingOk.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "TrainNumber", ((Enums.Train_ID)_adaptee.TrainNumber).ToString());
            stringBuilder.AppendLine();






            return stringBuilder.ToString();
        }
    }
}
