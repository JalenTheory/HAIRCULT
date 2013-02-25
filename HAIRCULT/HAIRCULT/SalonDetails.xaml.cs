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
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace HAIRCULT
{
   

    public partial class SalonDetails : PhoneApplicationPage
    {
        private  SalonViewModel selectedSalon;
        private string selectedIndex;
        public SaveContactTask saveContactTask;
      
        public SalonDetails()
        {
            InitializeComponent();
        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("id", out selectedIndex))
            {
                //selectedSalon = App._viewModel.SalonCollection[Int32.Parse(selectedIndex)];
                DataContext = selectedSalon;
              } 
          }


        
        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault( x =>x.NavigationUri.ToString().Contains("id=" + selectedIndex));
            StandardTileData tileData = new StandardTileData();

            if (tile == null)
            {
                tileData.Title = selectedSalon.sname; 
               //tileData.BackgroundImage = selectedSalon.Image.UriSource;
                ShellTile.Create(new Uri("/SalonDetails.xaml?id=" + selectedIndex, UriKind.Relative), tileData);
            }
        }



        private void Mail_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "message subject";
            emailComposeTask.Body = "message body";
            emailComposeTask.To = selectedSalon.semail; 

            emailComposeTask.Show();

        }



        private void Phone_Click(object sender, EventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = "+358465201970";
            phoneCallTask.DisplayName = selectedSalon.sname; 
            phoneCallTask.Show();

        }



        private void Share_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Message = "I fancy this Salon! Get a haircut from here Girl!" + " #" + selectedSalon.sname + " #" + "#haircult";
            shareLinkTask.LinkUri = selectedSalon.surl;
            shareLinkTask.Title = "Humbaa";
             

            shareLinkTask.Show();

            if (shareLinkTask == null)
            { MessageBox.Show("Set Up a Social Account"); }
        }


        private void SaveContact_Click(object sender, EventArgs e)
        {
            saveContactTask = new SaveContactTask();
            try
            {
                saveContactTask.FirstName = selectedSalon.sname;
                saveContactTask.WorkEmail = selectedSalon.semail;
                saveContactTask.Notes = selectedSalon.sdescription;
                saveContactTask.MobilePhone = selectedSalon.sphone;

                saveContactTask.Show(); 
            }

            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("epic fail. -->"+ex.Message);
            }
        }

         


      



    }
}