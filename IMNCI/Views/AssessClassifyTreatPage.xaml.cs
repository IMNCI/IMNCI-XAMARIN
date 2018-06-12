using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace IMNCI.Views
{
    public partial class AssessClassifyTreatPage : ContentPage
    {
        List<Assessment> assessments;

        private ObservableCollection<Data.AssessmentCategoryGroup> assessmentCategories;
        private ObservableCollection<Data.AssessmentCategoryGroup> _expandedGroup;

        public AssessClassifyTreatPage()
        {
            InitializeComponent();

            this.Title = "Assess, Classify and Treat";
        }

        protected async override void OnAppearing(){
            assessments = await App.Database.GetAssessments();
            List<Category> categories = new List<Category>();
            foreach (var assessment in assessments)
            {
                Category category = await App.Database.GetCategory(assessment.category_id);
                if (!categories.Any(item => item.id == category.id))
                {
                    categories.Add(category);
                }
            }

            assessmentCategories = new ObservableCollection<Data.AssessmentCategoryGroup>();

            foreach (Category category in categories)
            {
                List<Assessment> categoryAssessments = new List<Assessment>();
                Data.AssessmentCategoryGroup categoryGroup = new Data.AssessmentCategoryGroup(category.category);

                foreach (var assessment in assessments)
                {
                    if (category.id == assessment.category_id)
                    {
                        categoryAssessments.Add(assessment);
                        categoryGroup.Add(assessment);
                    }
                }

                assessmentCategories.Add(categoryGroup);
            }

            updateList();
        }

        private async void OpenDetails(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Assessment)e.SelectedItem;
            await Navigation.PushAsync(new AssessClassifySignTreat(item));
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroup.IndexOf(
                ((Data.AssessmentCategoryGroup)((Button)sender).CommandParameter));
            assessmentCategories[selectedIndex].Expanded = !assessmentCategories[selectedIndex].Expanded;
            updateList();
        }

        private void updateList(){
            _expandedGroup = new ObservableCollection<Data.AssessmentCategoryGroup>();
            foreach(Data.AssessmentCategoryGroup group in assessmentCategories){
                Data.AssessmentCategoryGroup newGroup = new Data.AssessmentCategoryGroup(group.Category, group.Expanded);
                if(group.Expanded){
                    foreach(Assessment assessment in group){
                        newGroup.Add(assessment);
                    }
                }

                _expandedGroup.Add(newGroup);
            }
            assessmentList.ItemsSource = _expandedGroup;
        }
    }
}
