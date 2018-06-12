using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IMNCI.Models;

namespace IMNCI.Views
{
    public partial class CounseltheMotherDetails : ContentPage
    {
        CounselTitle counselTitle;
        public CounseltheMotherDetails(CounselTitle title)
        {
            InitializeComponent();
            this.Title = title.title;

            counselTitle = title;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @counselTitle.content;
            counselContent.Source = htmlSource;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();


        //}
    }
}
