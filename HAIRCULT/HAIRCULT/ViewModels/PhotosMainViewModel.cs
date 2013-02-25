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

namespace HAIRCULT.ViewModels
{
    public class PhotosMainViewModel
    {


       public  bool IsDataLoaded ;
        public ObservableCollection<PhotosViewModel> PhotosCollection { get; private set; }


       
        public PhotosMainViewModel()
        {
            this.PhotosCollection = new ObservableCollection<PhotosViewModel>();
            IsDataLoaded = false;
        }


            
        public void LoadData()
        {
            this.PhotosCollection.Add(new PhotosViewModel() { image = new BitmapImage(new Uri("/IMAGES/I1.jpg", UriKind.Relative)), name = "kjhb" }); 
            this.PhotosCollection.Add(new PhotosViewModel() { image = new BitmapImage(new Uri("/IMAGES/I1.jpg", UriKind.Relative)), name = "kjhb" }); 
            this.PhotosCollection.Add(new PhotosViewModel() { image = new BitmapImage(new Uri("/IMAGES/I1.jpg", UriKind.Relative)), name = "kjhb" }); 
            IsDataLoaded = true;
        }
         
         
    }
}
 