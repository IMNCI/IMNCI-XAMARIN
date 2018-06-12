using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class HIVCareDetails : ContentPage
    {
        public HIVCareDetails(Models.HIVCare care)
        {
            InitializeComponent();

            BindingContext = this;

            this.Title = care.title;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @care.content;
            hivContent.Source = htmlSource;
        }
    }
}
