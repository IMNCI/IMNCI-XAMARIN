using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class FollowupTreatmentPage : ContentPage
    {
        public FollowupTreatmentPage(String treatment)
        {
            InitializeComponent();
            this.Title = "Treatment";
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @treatment;
            treatmentView.Source = htmlSource;
        }
    }
}
