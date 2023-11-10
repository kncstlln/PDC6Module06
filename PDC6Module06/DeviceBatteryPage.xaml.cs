using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;

namespace PDC6Module06
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceBatteryPage : ContentPage
    {
        public DeviceBatteryPage()
        {
            InitializeComponent();

            SetBackground(Battery.ChargeLevel, Battery.State == BatteryState.Charging);
        }

        void SetBackground(double level, bool charging)
        {
            Color? color = null;
            var status = charging ? "Charging" : "Not Charging";
            if (level > 0.5f)
            {
                BackgroundColor = Color.Green.MultiplyAlpha(level);
            }
            else if (level > .1f)
            {
                BackgroundColor = Color.Orange.MultiplyAlpha(level);
            }
            else
            {
                BackgroundColor = Color.Red.MultiplyAlpha(level);
            }
            color = color.Value;
            LabelBatteryLevel.Text = status;
        }
        
        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackground(e.ChargeLevel, e.State == BatteryState.Charging);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
        }

    }
}