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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;



namespace HAIRCULT
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Popup popup;
        BackgroundWorker backroungWorker;
           
            

        public MainPage()
        {
            InitializeComponent();
            ShowSplash();
           
                // Set the data context of the listbox control to the sample data
          //  DataContext = App._viewModel;
          
             WebClient twitter= new WebClient();
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_downloadstringCompleted);
            twitter.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + "HAIRCULTme"));

        }



        private void ShowSplash()
        {
              popup = new Popup();
            popup.Child = new SplashScreenControl();
             popup.IsOpen = true;
            StartLoadingData();
        }

        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(9000);
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
            }
            );
        }


        void twitter_downloadstringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
                if (e.Error != null) return;

                 XElement xmlTweets = XElement.Parse(e.Result);
        
                 listboxtweets.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                             select new TwitterItem
                                             {
                                                 ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                                 Message =  tweet.Element("text").Value,
                                                
                                             };
            }




        private void Button_find_a_style(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("/Gallery.xaml", UriKind.Relative));
        }





        private void Button_find_a_salon(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/salon_map.xaml", UriKind.Relative));
        }






        private void Button_Me(object sender, RoutedEventArgs e)
        {
           // this.NavigationService.Navigate(new Uri("/me.xaml", UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/me.xaml", UriKind.Relative));
        }

       

     
    





      
    }
}