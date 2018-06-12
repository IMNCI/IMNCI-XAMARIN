using System;
using System.Collections.Generic;

using Xamarin.Forms;
using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class FollowupCarePage : ContentPage
    {
        List<FollowupAilment> ailments;
        public FollowupCarePage()
        {
            InitializeComponent();

            this.Title = "Follow up care";
        }

        protected async override void OnAppearing(){
            base.OnAppearing();
            ailments = await App.Database.GetFollowupAilments();
            ailmentsList.ItemsSource = ailments;
        }

        private async void OpenDetails(object sender, SelectedItemChangedEventArgs e)
        {
            var ailment = (FollowupAilment)e.SelectedItem;
            int ailment_id = ailment.id;

            Followup followup = await App.Database.GetFollowupByAilmentID(ailment_id);
            await Navigation.PushAsync(new FollowupDetails(followup, ailment));
        }
    }
}
