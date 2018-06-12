using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class AssessmentAssessPage : ContentPage
    {
        public AssessmentAssessPage(Assessment assessment)
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @assessment.assessment;
            assesmentView.Source = htmlSource;
        }
    }
}
