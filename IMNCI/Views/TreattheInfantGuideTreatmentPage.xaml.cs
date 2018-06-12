using System;
using System.Collections.Generic;

using Xamarin.Forms;
using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class TreattheInfantGuideTreatmentPage : TabbedPage
    {
        public TreattheInfantGuideTreatmentPage(TreatTitle title)
        {
            InitializeComponent();

            this.Title = title.title;

            var contentPage = new NavigationPage(new TreatTitleContentPage(title.guide));
            contentPage.Title = "Guide";

            var treatmentsPage = new NavigationPage(new TreatTitleTreatmentsPage(title.id));
            treatmentsPage.Title = "Treatment";

            Children.Add(contentPage);
            Children.Add(treatmentsPage);
        }
    }
}
