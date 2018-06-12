using System;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public class SplashPage : ContentPage
    {
        public SplashPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

