using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Media.Imaging; 

namespace HAIRCULT.ViewModels
{
    public class PhotosViewModel
    {
        public event PropertyChangedEventHandler Handler;
        private void Notify(String property)
        {
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(property));
            }
        }

        private BitmapImage _image { get; set; }
        public BitmapImage image { get { return _image; } set { if (_image != value) { _image = value; Notify("image"); } } }
        private String _name { get; set; } 
        public String name { get { return _name; } set { if (_name != value) { _name = value; Notify("name"); } } }
        

    }
}
