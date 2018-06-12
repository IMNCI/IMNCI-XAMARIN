using System;
using System.Collections.Generic;
using RestSharp;

using Xamarin.Forms;

namespace IMNCI.Views
{
    public partial class ReportIssuePage : ContentPage
    {
        public ReportIssuePage()
        {
            InitializeComponent();

            this.Title = "Report an Issue";
        }

        private void HandleReportIssueClicked(object sender, EventArgs e){
            var Name = name.Text;
            var Email = email.Text;
            var Issue = issue.SelectedItem;
            var Description = description.Text;

            var client = new RestClient(App.ServerUrl);

            var issue_request = new RestRequest("api/review", Method.POST);

            issue_request.AddParameter("name", Name);
            issue_request.AddParameter("email", Email);
            issue_request.AddParameter("issue", Issue);
            issue_request.AddParameter("comment", Description);
            issue_request.AddParameter("rating", 0);

            var asyncHandle = client.ExecuteAsync<Models.Review>(issue_request, response => {
                Console.WriteLine(response.Data.id);
                DisplayAlert("Alert", "Your issue was reported successfully and will be sorted out soon", "OK");
            });

            asyncHandle.Abort();

        }
    }
}
