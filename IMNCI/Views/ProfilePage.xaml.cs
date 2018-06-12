using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            //var countyList = App.Database.getCounties();
            this.Title = "My Profile";

            // Create age group list for picker
            var ageGroupList = new List<string>();

            ageGroupList.Add("Youth (15-24 Years)");
            ageGroupList.Add("Adult (26-64 Years)");
            ageGroupList.Add("Senior (65 Years and Over)");

            var ageGroupPicker = (Picker)age_group;
            ageGroupPicker.ItemsSource = ageGroupList;

            // Create profession list for picker
            var professionList = new List<string>();

            professionList.Add("Care Provider(Health Care Worker)");
            professionList.Add("Interested party");
            professionList.Add("Student");

            var professionPicker = (Picker)profession;
            professionPicker.ItemsSource = professionList;

            // create cadre list for picker
            var cadreList = new List<string>();

            cadreList.Add("Doctor");
            cadreList.Add("Nurse");
            cadreList.Add("Nutritionist");
            cadreList.Add("Other");

            var cadrePicker = (Picker)cadre;
            cadrePicker.ItemsSource = cadreList;
        }

        private void submitProfile(object sender, EventArgs e){
            var genderPicker = (Picker)gender;


            var emailValue = email_address.Text;
            var genderValue = genderPicker.SelectedItem;

            DisplayAlert("Alert", "Email Address: " + emailValue + "\n Gender: " + genderValue, "OK");
        }

        private void skipProfile(object sender, EventArgs e){
            Application.Current.MainPage = new NavigationPage(new KeyElementsPage());
        }

        private void handleProfessionChange(object sender, EventArgs e){
            var professionPicker = (Picker)profession;
            var cadrePicker = (Picker)cadre;
            var professionValue = professionPicker.SelectedItem;

            switch(professionValue){
                case "Student":
                    cadreLayout.IsVisible = false;
                    break;
                default:
                    cadreLayout.IsVisible = true;
                    break;
            }
        }

        protected async override void OnAppearing(){
            base.OnAppearing();
            county.ItemsSource = await App.Database.getCounties();
        }
    }
}
