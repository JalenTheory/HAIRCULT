using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using PixelLab.Common;
using PixelLab.Common.Extensions;
using System.Collections;
using MessageBoxService;

namespace HAIRCULT
{
    public partial class me : PhoneApplicationPage
    {
        CameraCaptureTask cameraCaptureTask;
        PhotoChooserTask photoChooserTask;
        private PixelLab.Common.MessageBoxService _service = new PixelLab.Common.MessageBoxService();

       
        public me()
        {
            InitializeComponent();

        
            cameraCaptureTask = new CameraCaptureTask();
            photoChooserTask = new PhotoChooserTask();
            cameraCaptureTask.Completed += new EventHandler<PhotoResult>(photoCaptureOrSelectionCompleted);
     
          //  photoChooserTask.Completed +=new EventHandler<PhotoResult>(photoChooserTask_Completed);
             
        }


        void photoCaptureOrSelectionCompleted(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                
                    //MessageBox.Show(e.ChosenPhoto.Length.ToString());  //Code to display the photo on the page in an image control named myImage. 


                    System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                    bmp.SetSource(e.ChosenPhoto);
                   ProfilePic.Source = bmfp;


                   ProfilePic.Stretch = Stretch.Uniform;
                    //// swap UI element states

                }


                else
                {
                    MessageBox.Show("something has gone awry.");
                }
            
        }

   


        private void Camera_button_Click(object sender, EventArgs e)
        { 
            DictionaryEntry dict = new DictionaryEntry("Yes/No", MessageBoxServiceButton.YesNo);
            this._service.Closed += this.MessageBoxService_Closed;
            this._service.Show(
                "Do you want to...",
                "Change Profile Picture",
                (MessageBoxServiceButton)((DictionaryEntry)dict).Value); 
        }


        private void MessageBoxService_Closed(object sender, EventArgs e)
        {
            this._service.Closed -= this.MessageBoxService_Closed;
            String result = this._service.Result.ToString();

            if (result == "Yes")
            {
                cameraCaptureTask.Show();

            }

            else
            {
                photoChooserTask.Show();
            }

        }


    }
}



//-EXAMPLE FOR NUMERAL KEYBOARD -->
//public partial class me : PhoneApplicationPage
//{
//    // Constructor
//    public me()
//    {
//        InitializeComponent();

//        InputScope iscope = new InputScope();
//        InputScopeName iscopeName = new InputScopeName();
//        iscopeName.NameValue = InputScopeNameValue.TelephoneNumber;
//        iscope.Names.Add(iscopeName);
//        textBox2.InputScope = iscope;
//    }
//}
