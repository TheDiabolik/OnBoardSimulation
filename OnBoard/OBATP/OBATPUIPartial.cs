using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    partial class OBATP
    {
        //general
        [DisplayName("ID")]
        public string ID { get; set; }

        const string sdfsdf = "ahmet abi";

        //[DisplayName(sdfsdf)]
        [DisplayName("Train Name")]
        public string Train_Name { get; set; }
        [DisplayName("Speed(km/h)")]
        public string Speed { get; set; }

        //front
        [DisplayName("Front Track ID")]
        public string Front_Track_ID { get; set; }
        [DisplayName("Front Track Location(cm)")]
        public string Front_Track_Location { get; set; }
        [DisplayName("Front Track Length(cm)")]
        public string Front_Track_Length { get; set; }
        [Browsable(false)]
        [DisplayName("Front Track Max Speed(km/sa)")]
        public string Front_Track_Max_Speed { get; set; }
        
        //rear
        [DisplayName("Rear Track ID")]
        public string Rear_Track_ID { get; set; }
        [DisplayName("Rear Track Location(cm)")]
        public string Rear_Track_Location { get; set; }
        [DisplayName("Rear Track Length(cm)")]
        public string Rear_Track_Length { get; set; }
        [Browsable(false)]
        [DisplayName("Rear Track Max Speed(km/sa)")]
        public string Rear_Track_Max_Speed { get; set; }

        //general
        [Browsable(false)]
        [DisplayName("Total Route Distance(cm)")]
        public string Total_Route_Distance { get; set; }
    }
}
