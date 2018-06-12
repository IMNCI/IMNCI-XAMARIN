using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class TreatTreatAIlmentTreatments : ContentPage
    {
        List<TreatAilmentTreatment> treatAilmentTreatments;
        public TreatTreatAIlmentTreatments(List<TreatAilmentTreatment> treatAilmentTreatments)
        {
            InitializeComponent();
            this.treatAilmentTreatments = treatAilmentTreatments;
            treatmentsList.ItemsSource = treatAilmentTreatments;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    treatmentsList.ItemsSource = treatAilmentTreatments;
        //}

        private async void openTreatmentPage(object sender, SelectedItemChangedEventArgs e)
        {
            var treatment = (TreatAilmentTreatment)e.SelectedItem;
            await Navigation.PushAsync(new TreatAilmentTreatmentContent(treatment.content));
        }
    }
}
