using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Newtonsoft.Json;
using System.IO;
 
using Microsoft.Phone.Reactive;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Phone.Shell;



namespace HAIRCULT
{
    public partial class salon_map : PhoneApplicationPage
    {

        public MapLayer Layer = new MapLayer();
        public GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        ProgressIndicator progressIndicator = new ProgressIndicator() { IsVisible = true, IsIndeterminate = true, Text = "loading salons ..." };
      
        public salon_map()
        {
            InitializeComponent();

            SystemTray.SetProgressIndicator(this, progressIndicator);

            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            watcher.MovementThreshold = 20;


            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);


            MainViewModel view = new MainViewModel();
            this.DataContext = view;
            view.LoadData();
            watcher.Start();

              Map1.Loaded += new RoutedEventHandler(Map_loaded);
             
        }

        private void Map_loaded(object sender, RoutedEventArgs e)
        {
            progressIndicator.IsVisible = false;

        }

         


        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Map1.Center = e.Position.Location;
            Map1.ZoomLevel = 15;

            if (e.Position.Location.IsUnknown)
            {
                MessageBox.Show("Please wait while your position is determined....");
                return;
            }
        }




        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    MessageBox.Show("Location Service is not enabled on the device");
                    break;

                case GeoPositionStatus.NoData:
                    MessageBox.Show(" The Location Service is working, but it cannot get location data.");
                    break;
            }
        }






        // private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (SalonDBListBox.SelectedIndex == -1)
        //        return;

        //    NavigationService.Navigate(new Uri("/SalonDetails.xaml?id=" + SalonDBListBox.SelectedIndex, UriKind.Relative));

        //    SalonDBListBox.SelectedIndex = -1;
        // }


         



        private void Pushpin_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //Pushpin pin = (Pushpin)sender;
            //var q = SalonCollection.Where(X
        }
    }




    public class MainViewModel : INotifyPropertyChanged
    {
        //public BitmapImage Image; 

        public void LoadData()
        {
            WebClient wc = new WebClient();
            var wednesday = new Uri("http://users.metropolia.fi/~maimunas/haircult.txt");
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(wednesday);
           // wc.DownloadStringAsync(wednesday);
        
        
        }


        private ObservableCollection<SalonViewModel> _SalonColleciton = new ObservableCollection<SalonViewModel>();
        public ObservableCollection<SalonViewModel> SalonCollection
        {
            get { return _SalonColleciton; }
            set
            {
                _SalonColleciton = value; RaisePropertyChanged("SalonCollection");
            }
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

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<SalonViewModel>));
            ObservableCollection<SalonViewModel> list = serializer.ReadObject(e.Result) as ObservableCollection<SalonViewModel>;
             
            foreach (SalonViewModel b in list)
            {
                SalonCollection.Add(new SalonViewModel { sid = b.sid, sname = b.sname, scountry = b.scountry, semail = b.semail, sgeo_lat = b.sgeo_lat, sgeo_lon = b.sgeo_lon, scity = b.scity, sdescription = b.sdescription, sphone = b.sphone, sstate = b.sstate, sstreet = b.sstreet, surl = b.surl, szip = b.szip, slocation = b.slocation });
                 
            }


            
        }


        public class SalonViewModel
        {

            private GeoCoordinate l;
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
            public GeoCoordinate slocation
            {
                get
                {
                    l = new GeoCoordinate(sgeo_lon, sgeo_lat);
                    return l;
                }
                set
                {
                    if (l != value)
                    {
                        l = value;
                    };
                }
            }
        }
    }
}





//////Manually Load Collection
// App._viewModel.SalonCollection.Clear();

//Map1.Children.Remove(Layer);



//foreach (SalonViewModel Salon in _SalonCollection)
//{
//    MessageBox.Show(Salon.sname);
//    Pushpin p = new Pushpin();
//    p.Content = Salon.sname + System.Environment.NewLine + "Rate: ";// +Salon.Rate;
//    Layer.AddChild(p, new GeoCoordinate(Salon.sgeo_lon, Salon.sgeo_lat)); 
//}

//Map1.Children.Add(Layer); 