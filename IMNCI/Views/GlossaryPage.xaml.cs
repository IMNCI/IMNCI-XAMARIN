using System;
using System.Collections.Generic;

using Xamarin.Forms;
using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class GlossaryPage : ContentPage
    {
        List<Glossary> glossaries;
        public GlossaryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            glossaries = await App.Database.GetGlossaries();
            glossaryList.ItemsSource = glossaries;
        }

    }
}
