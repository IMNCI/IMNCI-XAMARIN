using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class DashboardView : MasterDetailPage
    {
        public List<MasterPageItem> menuList
        {
            get;
            set;
        }
        public DashboardView()
        {
            InitializeComponent();
            menuList = new List < MasterPageItem > (); 

            menuList.Add(new MasterPageItem()
            {
                Title = "Dashboard",
                IconSource = "homeIcon",
                TargetType = typeof(MainMenuPage)
            });

            menuList.Add(new MasterPageItem(){
                Title = "Elements",
                IconSource = "homeIcon",
                TargetType = null
            });

            //menuList.Add(new MasterPageItem(){
            //    Title = "Notifications",
            //    IconSource = "homeIcon",
            //    TargetType = typeof(NotificationsPage)
            //});

            //menuList.Add(new MasterPageItem(){
            //    Title = "Glossary",
            //    IconSource = "big-dictionary.png",
            //    TargetType = null
            //});

            //menuList.Add(new MasterPageItem(){
            //    Title = "Other Apps",
            //    IconSource = "homeIcon",
            //    TargetType = typeof(MainMenuPage)
            //});

            //menuList.Add(new MasterPageItem(){
            //    Title = "My Profile",
            //    IconSource = "homeIcon",
            //    TargetType = null
            //});

            //menuList.Add(new MasterPageItem(){
            //    Title = "Check for Updates",
            //    IconSource = "homeIcon",
            //    TargetType = typeof(MainMenuPage)
            //});

            //menuList.Add(new MasterPageItem(){
            //    Title = "Tell a Friend",
            //    IconSource = "homeIcon",
            //    TargetType = null
            //});

            menuList.Add(new MasterPageItem(){
                Title = "Report an Issue",
                IconSource = "homeIcon",
                TargetType = typeof(MainMenuPage)
            });
            navigationDrawerList.ItemsSource = menuList;

            NavigationPage.SetHasNavigationBar(this, false);

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainMenuPage)));
            this.Title = "IMNCI 2018 Edition";
        }

        //private async void handleInfoClickedAsync(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Views.InfoPage());
        //}

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) {  
            var item = (MasterPageItem) e.SelectedItem;
            if(item.TargetType != null){
                Type page = item.TargetType;
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;  
            }else{
                switch(item.Title){
                    case "Elements":
                        openElementsPage();
                        break;
                    case "My Profile":
                        openProfilePage();
                        break;
                    case "Glossary":
                        openGlossaryPage();
                        break;
                    default:
                        break;
                }
            }
        }

        private async void openElementsPage(){
            await Navigation.PushAsync(new KeyElementsPage());
        }

        private async void openProfilePage()
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void openGlossaryPage()
        {
            await Navigation.PushAsync(new GlossaryPage());
        }
    }
}
