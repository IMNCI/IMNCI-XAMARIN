using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class TreatTreatmentContentPage : ContentPage
    {
        string content;
        public TreatTreatmentContentPage(String content)
        {
            InitializeComponent();
            this.content = content;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @content;
            contentView.Source = htmlSource;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //}
    }
}
