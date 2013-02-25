using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HAIRCULT
{
    public partial class SplashScreenControl : PhoneApplicationPage
    {
        public SplashScreenControl()
        {
            InitializeComponent();
            this.progressBar1.IsIndeterminate = true;
        }
    }
}