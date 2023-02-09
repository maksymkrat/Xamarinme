using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarinme;

namespace DemoApp.WebHost
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            Ip.Text = App.WebHostParameters.ServerIpEndpoint.Address.ToString();
            Url.Text = $"http://{Ip.Text}:{App.WebHostParameters.ServerIpEndpoint.Port}";

            var display = DeviceDisplay.MainDisplayInfo;
            var h = display.Height;
            var w = display.Width;
            Size.Text = h + " x " + w;
        }

        protected override void OnAppearing()
        {
            nextPage.Clicked += NextPageOnClicked;
        }

        private async void NextPageOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Page1());
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
