using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;
using System.Collections.ObjectModel;

namespace IMNCI.Views
{
    public partial class AssessClassificationDetails : ContentPage
    {
        string parent;
        List<AssessmentClassification> assessmentClassifications;

        private ObservableCollection<Data.ClassificationGroup> classificationParents;
        //private ObservableCollection<Data.ClassificationGroup> _expandedGroups;
        public AssessClassificationDetails(Assessment assessment, string parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.Title = parent;
        }

        protected async override void OnAppearing(){
            assessmentClassifications = await App.Database.GetAssessmentClassificationsByParent(parent);
            classificationParents = new ObservableCollection<Data.ClassificationGroup>();
            foreach (var classification in assessmentClassifications)
            {
                Data.ClassificationGroup classificationGroup = new Data.ClassificationGroup(classification.classification);
                classificationGroup.Add(classification);
                classificationParents.Add(classificationGroup);
            }

            ClassificationDetails.ItemsSource = classificationParents;
        }
    }
}
