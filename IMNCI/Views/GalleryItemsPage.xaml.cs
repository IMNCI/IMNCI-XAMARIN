using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class GalleryItemsPage : ContentPage
    {
        void Webclient_DownloadProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
        }


        void Webclient_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
        }


        void Webclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }


        GalleryAIlment ailment;
        public GalleryItemsPage(GalleryAIlment ailment)
        {
            InitializeComponent();

            this.ailment = ailment;

            this.Title = ailment.ailment;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Gallery> galleries = await App.Database.GetGalleries(ailment.id);
            List<Gallery> galleryList = new List<Gallery>();

            List<GalleryItem> items = new List<GalleryItem>();

            foreach(var gallery in galleries){
                int item_id = gallery.gallery_items_id;
                GalleryItem item = await App.Database.GetGalleryItem(item_id);
                items.Add(item);

                gallery.gallery_item_name = item.item;
                galleryList.Add(gallery);
            }

            ItemsList.ItemsSource = galleryList;
        }

        //private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var gallery = (Gallery)e.SelectedItem;
        //    var url = new Uri(App.ServerUrl + "/api/files/get/" + gallery.id);
        //    var webclient = new WebClient();


        //}
    }
}
