using System;
using System.Collections.Generic;

using Xamarin.Forms;
using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class TreatInfantPage : ContentPage
    {
        List<TreatTitle> treatTitles;
        public TreatInfantPage()
        {
            InitializeComponent();

            this.Title = "Treat the Infant/Child";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            treatTitles = await App.Database.GetTreatTitles();
            treatTitlesList.ItemsSource = treatTitles;
        }

        private async void openTreatTitle(object sender, SelectedItemChangedEventArgs e)
        {
            var treatTitle = (TreatTitle)e.SelectedItem;
            await Navigation.PushAsync(new TreattheInfantGuideTreatmentPage(treatTitle));
        }
    }
}
