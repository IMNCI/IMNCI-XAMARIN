using System;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public class KeyElementsPage : ContentPage
    {
        public KeyElementsPage()
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

