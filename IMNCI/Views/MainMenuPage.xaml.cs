using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void handleAssessClassifyClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssessClassifyTreatPage());
        }

        private async void handleTreatClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreatInfantPage());
        }

        private async void handleCounselClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CounselTheMotherPage());
        }

        private async void handleFollowUpClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FollowupCarePage());
        }

        private async void handleHIVClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HIVCarePage());
        }

        private async void handleGalleryClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GalleryPage());
        }

        private async void handleGlossaryClick(object sender, EventArgs e){
            await Navigation.PushAsync(new GlossaryPage());
        }

        private async void handleReportIssue(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportIssuePage());
        }
    }
}
