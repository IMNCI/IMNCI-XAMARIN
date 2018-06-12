using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class AssessClassifySignTreat : TabbedPage
    {
        Assessment assessment;
        public AssessClassifySignTreat(Assessment assessment)
        {
            InitializeComponent();
            this.Title = assessment.title;
            this.assessment = assessment;

            var assessPage = new NavigationPage(new AssessmentAssessPage(assessment));
            assessPage.Title = "Assess";

            var classificationPage = new NavigationPage(new AssessmentClassifyPage(assessment));
            classificationPage.Title = "Classification, Signs and Treatment";

            Children.Add(assessPage);
            Children.Add(classificationPage);
        }
    }
}
