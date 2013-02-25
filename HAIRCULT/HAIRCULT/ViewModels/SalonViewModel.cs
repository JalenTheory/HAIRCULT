using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Net.Browser;
using System.Collections.ObjectModel;
using System.Device.Location;


namespace HAIRCULT
{
    [DataContract]
    public class SalonViewModel
    {

        public GeoCoordinate l;
         [DataMember]
        public int sid { get; set; }
        [DataMember]
        public string sname { get; set; }
        [DataMember]
        public string sstreet { get; set; }
        [DataMember]
        public int szip { get; set; }
        [DataMember]
        public string scity { get; set; }
        [DataMember]
        public object sstate { get; set; }
        [DataMember]
        public object scountry { get; set; }
        [DataMember]
        public string sphone { get; set; }
        [DataMember]
        public Uri surl { get; set; }
        [DataMember]
        public string semail { get; set; }
        [DataMember]
        public string sdescription { get; set; }
        [DataMember]
        public double sgeo_lon { get; set; }
        [DataMember]
        public double sgeo_lat { get; set; }
        [DataMember]
        public GeoCoordinate slocation {
            get{ 
                  l = new GeoCoordinate(sgeo_lat,sgeo_lon);
                return l;
            }
            set
            {
                if(l != value) 
                {
                    l = value;
                };
            }
        }
    }
}

  

