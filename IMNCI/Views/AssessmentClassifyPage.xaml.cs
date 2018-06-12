using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class AssessmentClassifyPage : ContentPage
    {
        List<string> parents = new List<string>();
        Assessment assessment;
        public AssessmentClassifyPage(Assessment assessment)
        {
            InitializeComponent();
            this.assessment = assessment;
        }

        protected async override void OnAppearing(){
            List<AssessmentClassification> assessmentClassifications = await App.Database.GetAssessmentClassificationsByAssessment(this.assessment.id);
            foreach(AssessmentClassification assessmentClassification in assessmentClassifications){
                if(!parents.Contains(assessmentClassification.parent)){
                    parents.Add(assessmentClassification.parent);
                }
            }

            ClassificationParents.ItemsSource = parents;
        }

        private async void OpenDetails(object sender, SelectedItemChangedEventArgs e)
        {
            string parent = (string)e.SelectedItem;
            await Navigation.PushAsync(new AssessClassificationDetails(assessment, parent));
        }
    }
}
