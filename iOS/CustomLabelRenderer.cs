using System;
using IMNCI.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace IMNCI.iOS
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.LineBreakMode = UIKit.UILineBreakMode.TailTruncation;
                Control.Lines = 2;
            }
        }
    }
}
