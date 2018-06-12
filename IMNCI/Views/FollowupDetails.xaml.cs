using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class FollowupDetails : TabbedPage
    {
        public FollowupDetails(Followup followup, FollowupAilment ailment)
        {
            InitializeComponent();
            this.Title = ailment.ailment;
            var advicePage = new NavigationPage(new FollowupAdvicePage(followup.advice));
            advicePage.Title = "Advice";

            var treatmentPage = new NavigationPage(new FollowupTreatmentPage(followup.treatment));
            treatmentPage.Title = "Treatment";

            Children.Add(advicePage);
            Children.Add(treatmentPage);
        }


    }
}
