using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.WebHost
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            
            Title = "Modal Page";
            Button backButton = new Button
            {
                Text = "go back",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            backButton.Clicked += BackButton_Click;
 
            Content = backButton;
        }
        
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}