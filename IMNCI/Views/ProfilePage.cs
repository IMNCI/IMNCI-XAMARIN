﻿using System;

using Xamarin.Forms;

namespace IMNCI
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
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

