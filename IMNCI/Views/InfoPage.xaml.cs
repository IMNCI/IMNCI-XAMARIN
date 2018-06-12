using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class InfoPage : ContentPage
    {
        public List<string> MyList { get; private set; } = new List<string>() { "Line 1", "Line 2", "Line 3" };
        public InfoPage()
        {
            InitializeComponent();
        }
    }
}
