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
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.ComponentModel;
using System.Device.Location;



namespace HAIRCULT
{

    public class MainViewModel
    { 
        //public BitmapImage Image; 
        public bool IsDataLoaded { get; private set; }

        public ObservableCollection<SalonViewModel> SalonCollection { get; private set; }

         
        public MainViewModel()
        {
            IsDataLoaded = false; 
        }
        
        public void LoadData()
        { 
            var wednesday = new Uri("http://users.metropolia.fi/~maimunas/haircult.txt");
            WebClient wc = new WebClient(); 
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
          }

        


          //Event code to ensure the page updates to model changes.
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    


        public void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            SalonCollection = new ObservableCollection<SalonViewModel>();
            try
            {
                SalonCollection = new ObservableCollection<SalonViewModel>();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<SalonViewModel>));
                ObservableCollection<SalonViewModel> list = serializer.ReadObject(e.Result) as ObservableCollection<SalonViewModel>;
                
                foreach (SalonViewModel b in list)
                { 
                   SalonCollection.Add(new SalonViewModel { sid=b.sid,sname=b.sname,scountry=b.scountry,semail=b.semail,sgeo_lat=b.sgeo_lat,sgeo_lon=b.sgeo_lon,scity=b.scity,sdescription=b.sdescription,sphone=b.sphone,sstate=b.sstate,sstreet=b.sstreet,surl=b.surl,szip=b.szip,slocation=b.slocation });
                 }
                
                this.IsDataLoaded = true;               

            }

            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message);
            }
        }




    }
}


            