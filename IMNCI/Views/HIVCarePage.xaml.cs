using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class HIVCarePage : ContentPage
    {
        List<Models.HIVCare> hIVCares;

        private ObservableCollection<Data.HIVCareGroup> hivParents;
        private ObservableCollection<Data.HIVCareGroup> _expandedGroups;

        public HIVCarePage()
        {
            InitializeComponent();

            this.Title = "HIV Care for Children";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            hIVCares = await App.Database.GetHIVCares();
            List<string> parents = new List<string>();
            foreach(var hivCare in hIVCares){
                string parent_name = hivCare.parent;
                if (!parents.Contains(parent_name))
                {
                    parents.Add(parent_name);
                }
            }
            hivParents = new ObservableCollection<Data.HIVCareGroup>();

            foreach (string parent in parents)
            {
                List<Models.HIVCare> parentHIVCares = new List<Models.HIVCare>();
                Data.HIVCareGroup hivgroup = new Data.HIVCareGroup(parent);
                foreach (var hivCare in hIVCares)
                {
                    if (parent == hivCare.parent)
                    {
                        parentHIVCares.Add(hivCare);
                        hivgroup.Add(hivCare);
                    }
                }

                hivParents.Add(hivgroup);
            }
            updateListContent();

        }

        private async void OpenDetails(object sender, SelectedItemChangedEventArgs e){
            var item = (Models.HIVCare)e.SelectedItem;
            await Navigation.PushAsync(new HIVCareDetails(item));
        }

        private void HeaderTapped(object sender, EventArgs args){
            int selectedIndex = _expandedGroups.IndexOf(
                ((Data.HIVCareGroup)((Button)sender).CommandParameter));
            hivParents[selectedIndex].Expanded = !hivParents[selectedIndex].Expanded;
            updateListContent();
        }

        private void updateListContent(){
            _expandedGroups = new ObservableCollection<Data.HIVCareGroup>();
            foreach(Data.HIVCareGroup group in hivParents){
                Data.HIVCareGroup newGroup = new Data.HIVCareGroup(group.Parent, group.Expanded);
                newGroup.ItemCount = group.Count;
                if(group.Expanded){
                    foreach(Models.HIVCare care in group){
                        newGroup.Add(care);
                    }
                }

                _expandedGroups.Add(newGroup);
            }
            HIVCareList.ItemsSource = _expandedGroups;
        }
    }
}
