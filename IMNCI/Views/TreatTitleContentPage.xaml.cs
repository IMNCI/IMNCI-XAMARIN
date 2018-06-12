using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class TreatTitleContentPage : ContentPage
    {
        public TreatTitleContentPage(String guide)
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @guide;
            guideView.Source = htmlSource;
        }
    }
}
