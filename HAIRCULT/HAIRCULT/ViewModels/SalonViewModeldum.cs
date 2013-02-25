using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace HAIRCULT
{
    public class SalonViewModel 
    {

        private string _contactnumber;
        public string ContactNumber
        {
            get
            {
                return _contactnumber;
            }
            set
            {
                if (_contactnumber != value)
                {
                    _contactnumber = value;
                    Notify("ContactNumber");
                }
            }
        }


        private Uri _link;
        public Uri Link
        {
            get
            {
                return _link;
            }
            set
            {
                if (_link != value)
                {
                    _link = value;
                    Notify("Link");
                }
            }
        }


        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    Notify("Email");
                }
            }
        }

        private Double _Latitude;
        public Double Longitude
        {
            get { return _Latitude; }
            set{
                if(_Latitude !=value)
                {
                    _Latitude = value;
                    Notify("Latitude");
                }
            }
        }



        private Double _Longitude;
        public Double Latitude
        {
            get { return _Longitude; }
            set
            {
                if (_Longitude != value)
                {
                    _Longitude = value;
                    Notify("Longitude");
                }
            }
        }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    Notify("Image");
                }
            }
        }


        private int _rate;
        public int Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    Notify("Rate");
                }
            }
        }


        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }




        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }


        public event PropertyChangedEventHandler Handler;
        private void Notify(String property)
        {
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}