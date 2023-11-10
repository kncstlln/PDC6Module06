using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PDC6Module06
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectivityPage : ContentPage
    {
        public ConnectivityPage()
        {
            InitializeComponent();
        }

        private void Connectivity_Clicked(object sender, EventArgs e)
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet) 
            {
                DisplayAlert("No Internet Access", "Please Connect to an internet", "Okay");
                return;
            }
        }
    }
}