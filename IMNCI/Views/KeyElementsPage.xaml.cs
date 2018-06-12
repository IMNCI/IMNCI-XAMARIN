using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI
{
    public partial class KeyElementsPage : ContentPage
    {
        public KeyElementsPage()
        {
            InitializeComponent();

            this.Title = "Key Elements of IMCI";
        }

        private async void handleInfoClickedAsync(object sender, EventArgs e) {
            await Navigation.PushAsync(new Views.InfoPage());
        }
        private void handleHomeClicked(object sender, EventArgs e) {
            Application.Current.MainPage = new NavigationPage(new Views.DashboardView());
        }
            
    }
}
