using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class TreatTitleTreatmentsPage : ContentPage
    {
        List<TreatAilment> treatAilments;
        int treat_title_id;
        public TreatTitleTreatmentsPage(int treat_title_id)
        {
            InitializeComponent();

            this.treat_title_id = treat_title_id;
        }

        //treatmentsList
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            treatAilments = await App.Database.GetTreatAilmentByTreatTitle(treat_title_id);
            treatmentsList.ItemsSource = treatAilments;
        }

        private async void openTreatmentPage(object sender, SelectedItemChangedEventArgs e)
        {
            var treatment = (TreatAilment)e.SelectedItem;
            await Navigation.PushAsync(new TreattheInfantTreatmentDetails(treatment));

        }
    }
}
