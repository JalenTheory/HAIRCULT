using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using HAIRCULT.ViewModels;



namespace HAIRCULT
{
    public partial class gallery : PhoneApplicationPage
    {
        

        

        public gallery()
        {
            InitializeComponent();

            //SalonViewModel salonDB = new SalonViewModel();
            this.listBox.ItemsSource = App._pviewModel.PhotosCollection;

            Image g = new Image();
            BitmapImage h = new BitmapImage(new Uri("image01.png", UriKind.Relative));
            g.Source = h; 


            DataContext = App._pviewModel;
               this.Loaded += new RoutedEventHandler(Gallery_Loaded);

        }

        private void Gallery_Loaded(object sender, RoutedEventArgs e)
        {

            App._pviewModel.LoadData(); 
        }
         


        private void Search_Click(Object sender,EventArgs e)
        {
            Search_StackPanel.Visibility = Visibility.Visible;

        }

        private void FavouriteStyles_Click(Object sender, EventArgs e)
        {
                this.NavigationService.Navigate(new Uri("/FavouriteStyles_Page.xaml",UriKind.Relative));
        
        }

      
    
        private void search_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PictureView.xaml?x="+ listBox.SelectedIndex, UriKind.Relative));
        }
        

        
        


     
    }
}
