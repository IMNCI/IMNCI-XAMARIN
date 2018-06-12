using System;

using SQLite;
using Xamarin.Forms;

namespace IMNCI.Models
{
    public class AssessmentClassification{
        public int id { get; set; }
        public int assessment_id { get; set; }
        public int disease_classification_id { get; set; }
        public string classification { get; set; }
        public string parent { get; set; }
        public string signs { get; set; }
        public string treatments { get; set; }
        public HtmlWebViewSource signsHTMLView {
            get {
                var htmlWebSource = new HtmlWebViewSource();
                htmlWebSource.Html = @signs;
                return htmlWebSource;
            }
        }

        public HtmlWebViewSource treatmentHTMLView
        {
            get
            {
                var htmlWebSource = new HtmlWebViewSource();
                htmlWebSource.Html = @treatments;
                return htmlWebSource;
            }
        }
    }
}
