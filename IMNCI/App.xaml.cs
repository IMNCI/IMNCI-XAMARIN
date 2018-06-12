using System;

using Xamarin.Forms;
using IMNCI.Models;
using RestSharp;
using System.Net.Http;
using System.Collections.Generic;
using SQLite;

using Newtonsoft.Json;

namespace IMNCI
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static string ServerUrl = "http://imci.nascop.org";
        static IMNCIDatabase database;

        public App()
        {
            InitializeComponent();
            //Database.clearDatabase();
            Console.WriteLine("Checking counties");
            if(Database.numberofcounties().Result != 47){
                Console.WriteLine("No counties. Fetching data");
                getServerData();
            }

            MainPage = new NavigationPage(new KeyElementsPage());
        }

        public static IMNCIDatabase Database{
            get{
                if(database == null){
                    database = new IMNCIDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("IMNCIDatabase.db3"));
                }

                return database;
            }
        }


        public static void getServerData(){
            var client = new RestClient(ServerUrl);
            var counties_request = new RestRequest("api/counties");
            var glossary_request = new RestRequest("api/glossary");
            var hivcare_request = new RestRequest("api/hiv-care");
            var followup_ailments = new RestRequest("api/ailment");
            var follwups = new RestRequest("api/ailment-followup");
            var categories_request = new RestRequest("api/assessment_class_group");
            var assessments_request = new RestRequest("api/assessment");
            var disease_classification_request = new RestRequest("api/disease_classfication");
            var assessment_classification_request = new RestRequest("api/classifications");
            var treat_titles_request = new RestRequest("api/titles");
            var treat_ailments_request = new RestRequest("api/treat_ailments");
            var treat_ailments_treatment_request = new RestRequest("api/treat_ailment_treatments");
            var counsel_titles_request = new RestRequest("api/counsel-titles");
            var counsel_subcontents_request = new RestRequest("api/counsel-sub-contents");
            var gallery_request = new RestRequest("api/gallery");
            var gallery_ailments_request = new RestRequest("api/gallery-ailments");
            var gallery_items_request = new RestRequest("api/galleryitems");

            IRestResponse response = client.Execute(counties_request);
            IRestResponse glossaryResponse = client.Execute(glossary_request);
            IRestResponse hivcareResponse = client.Execute(hivcare_request);
            IRestResponse followupAilmentsResponse = client.Execute(followup_ailments);
            IRestResponse followupsResponse = client.Execute(follwups);
            IRestResponse categoriesResponse = client.Execute(categories_request);
            IRestResponse assessmentsResponse = client.Execute(assessments_request);
            IRestResponse diseaseClassificationResponse = client.Execute(disease_classification_request);
            IRestResponse assessmentClassificationResponse = client.Execute(assessment_classification_request);
            IRestResponse treatTitlesResponse = client.Execute(treat_titles_request);
            IRestResponse treatAilmentsResponse = client.Execute(treat_ailments_request);
            IRestResponse treatAilmentsTreatmentResponse = client.Execute(treat_ailments_treatment_request);
            IRestResponse counselTitleResponse = client.Execute(counsel_titles_request);
            IRestResponse counselSubContentsResponse = client.Execute(counsel_subcontents_request);
            IRestResponse galleryResponse = client.Execute(gallery_request);
            IRestResponse galleryAilmentResponse = client.Execute(gallery_ailments_request);
            IRestResponse galleryItemResponse = client.Execute(gallery_items_request);

            var counties = JsonConvert.DeserializeObject<IEnumerable<County>>(response.Content);
            var glossaries = JsonConvert.DeserializeObject<IEnumerable<Glossary>>(glossaryResponse.Content);
            var hivcares = JsonConvert.DeserializeObject<IEnumerable<HIVCare>>(hivcareResponse.Content);
            var followupAilments = JsonConvert.DeserializeObject<IEnumerable<FollowupAilment>>(followupAilmentsResponse.Content);
            var followups = JsonConvert.DeserializeObject<IEnumerable<Followup>>(followupsResponse.Content);
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(categoriesResponse.Content);
            var assessments = JsonConvert.DeserializeObject<IEnumerable<Assessment>>(assessmentsResponse.Content);
            var disease_classifications = JsonConvert.DeserializeObject<IEnumerable<DiseaseClassification>>(diseaseClassificationResponse.Content);
            var assessment_classifications = JsonConvert.DeserializeObject<IEnumerable<AssessmentClassification>>(assessmentClassificationResponse.Content);
            var treat_titles = JsonConvert.DeserializeObject<IEnumerable<TreatTitle>>(treatTitlesResponse.Content);
            var treat_ailments = JsonConvert.DeserializeObject<IEnumerable<TreatAilment>>(treatAilmentsResponse.Content);
            var treat_ailment_treatments = JsonConvert.DeserializeObject<IEnumerable<TreatAilmentTreatment>>(treatAilmentsTreatmentResponse.Content);
            var counsel_titles = JsonConvert.DeserializeObject<IEnumerable<CounselTitle>>(counselTitleResponse.Content);
            var counsel_subcontents = JsonConvert.DeserializeObject<IEnumerable<CounselSubContent>>(counselSubContentsResponse.Content);
            var galleries = JsonConvert.DeserializeObject<IEnumerable<Gallery>>(galleryResponse.Content);
            var gallery_ailments = JsonConvert.DeserializeObject<IEnumerable<GalleryAIlment>>(galleryAilmentResponse.Content);
            var gallery_items = JsonConvert.DeserializeObject<IEnumerable<GalleryItem>>(galleryItemResponse.Content);
            //Database.truncateCounty();
            foreach(var county in counties){
                Database.SaveCountyAsync(county);
            }

            foreach(var glossary in glossaries){
                Database.SaveGlossaryAsync(glossary);
            }

            foreach(var hivcare in hivcares){
                Database.SaveHIVCare(hivcare);
            }

            foreach(var ailment in followupAilments){
                Database.saveFollowUpAilment(ailment);
            }

            foreach(var followup in followups){
                Database.saveFollowUp(followup);
            }

            foreach(var category in categories){
                Database.saveCategory(category);
            }

            foreach(var assessment in assessments){
                Database.saveAssessment(assessment);
            }

            foreach(var classification in disease_classifications){
                Database.saveDiseaseClassification(classification);
            }

            foreach(var assessmentClassification in assessment_classifications){
                Database.saveAssessmentClassification(assessmentClassification);
            }

            foreach(var treatTitle in treat_titles){
                Database.saveTreatTitle(treatTitle);
            }

            foreach(var treatAilment in treat_ailments){
                Database.saveTreatAilment(treatAilment);
            }

            foreach(var treatAilmentTreatment in treat_ailment_treatments){
                Database.saveTreatAilmentTreatment(treatAilmentTreatment);
            }

            foreach(var counsel_title in counsel_titles){
                Database.saveCounselTitle(counsel_title);
            }

            foreach(var subcontent in counsel_subcontents){
                Database.saveCounselSubContent(subcontent);
            }

            foreach (var gallery in galleries)
            {
                Database.saveGallery(gallery);
            }

            foreach (var galleryAilment in gallery_ailments)
            {
                Database.saveGalleryAilment(galleryAilment);
            }

            foreach (var galleryItem in gallery_items)
            {
                Database.saveGalleryItem(galleryItem);
            }
        }
    }
}
