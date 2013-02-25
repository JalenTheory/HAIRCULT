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
 

namespace HAIRCULT
{
    public partial class PictureView : PhoneApplicationPage
    {
          
        public Image slectedimage;


        public PictureView()
        {
            InitializeComponent();
           // this.Loaded += new RoutedEventHandler(Default_Loaded);
             

        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {  
            //if (NavigationContext.QueryString.TryGetValue("id", out selectedIndex))
            //{
            //    selectedImage = listBox.Items[Int32.Parse(selectedIndex)];
            //    DataContext = selectedImage;
            //}

        }

        //private void Default_Loaded(Object sender, RoutedEventArgs e)
        //{
        //    Image thePhoto = new Image();
        //    thePhoto.Source = NavigationContext.QueryString.Values.First();
        //    thePhoto = Utils.GetImage(NavigationContext.QueryString.Values.First());

        //    this.DataContext = thePhoto;
        //}


    }

  
}