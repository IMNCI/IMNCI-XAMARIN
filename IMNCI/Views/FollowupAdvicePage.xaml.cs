using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class FollowupAdvicePage : ContentPage
    {
        public FollowupAdvicePage(String advice)
        {
            InitializeComponent();
            this.Title = "Advice";
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @advice;
            adviceView.Source = htmlSource;
        }
    }
}
