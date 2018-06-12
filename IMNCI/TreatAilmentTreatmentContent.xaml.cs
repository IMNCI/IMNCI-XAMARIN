using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI
{
    public partial class TreatAilmentTreatmentContent : ContentPage
    {
        string content = "";
        public TreatAilmentTreatmentContent(String content)
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
