using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class TreattheInfantTreatmentDetails : TabbedPage
    {
        TreatAilment treatAilment;
        string content = "";
        public TreattheInfantTreatmentDetails(TreatAilment treatAilment)
        {
            InitializeComponent();

            this.treatAilment = treatAilment;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            content = treatAilment.content;

            List<TreatAilmentTreatment> treatments = await App.Database.GetTreatAilmentTreatmentByAilmentID(treatAilment.id);
            if (!string.IsNullOrEmpty(content))
            {
                var contentPage = new NavigationPage(new TreatTreatmentContentPage(content));
                contentPage.Title = "Content";
                Children.Add(contentPage);
            }

            if(treatments.Count > 0){
                var treatmentPage = new NavigationPage(new TreatTreatAIlmentTreatments(treatments));
                treatmentPage.Title = "Treatments";
                Children.Add(treatmentPage);
            }
        }
    }
}
