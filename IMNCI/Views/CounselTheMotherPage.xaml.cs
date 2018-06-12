using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class CounselTheMotherPage : ContentPage
    {
        public CounselTheMotherPage()
        {
            InitializeComponent();

            this.Title = "Counsel the Mother";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<CounselTitle> titles = new List<CounselTitle>();

            List<CounselTitle> counselTitles = await App.Database.GetCounselTitles();

            foreach(var counselTitle in counselTitles){
                if(counselTitle.is_parent == 0){
                    CounselTitle title = new CounselTitle();
                    title.title = counselTitle.title;
                    title.content = counselTitle.content;
                    titles.Add(title);
                }else{
                    Console.WriteLine("Subcontent => " + counselTitle.title);
                    List<CounselSubContent> counselSubContents = await App.Database.GetCounselSubContentsByCounselTitle(counselTitle.id);
                    Console.WriteLine("Number: " + counselSubContents.Count);
                    foreach(var subcontent in counselSubContents){
                        Console.WriteLine("Main subcontent: " + subcontent.sub_content_title);
                        CounselTitle title = new CounselTitle();
                        title.title = subcontent.sub_content_title;
                        title.content = subcontent.content;

                        titles.Add(title);
                    }
                }
            }

            CounselTitlesList.ItemsSource = titles;
        }


        private async void OpenDetails(object sender, SelectedItemChangedEventArgs e)
        {
            var couselTitle = (CounselTitle)e.SelectedItem;
            await Navigation.PushAsync(new CounseltheMotherDetails(couselTitle));
        }
    }
}
