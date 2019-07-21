using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rairi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void HomeButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
