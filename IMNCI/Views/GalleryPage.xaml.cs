using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class GalleryPage : ContentPage
    {
        public GalleryPage()
        {
            InitializeComponent();

            this.Title = "Ailments";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<GalleryAIlment> aIlments = await App.Database.GetGalleryAilments();
            this.AilmentsList.ItemsSource = aIlments;
        }

        private async void AilmentClicked(object sender, SelectedItemChangedEventArgs e)
        {
            var galleryAilment = (GalleryAIlment)e.SelectedItem;
            await Navigation.PushAsync(new GalleryItemsPage(galleryAilment));
        }
    }
}
