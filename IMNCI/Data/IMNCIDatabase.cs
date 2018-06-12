using System;

using IMNCI.Models;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IMNCI
{
    public class IMNCIDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly SQLiteConnection connection;

        public IMNCIDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            connection = new SQLiteConnection(dbPath);
            database.CreateTableAsync<County>().Wait();
            database.CreateTableAsync<Glossary>().Wait();
            database.CreateTableAsync<HIVCare>().Wait();
            database.CreateTableAsync<FollowupAilment>().Wait();
            database.CreateTableAsync<Followup>().Wait();
            database.CreateTableAsync<Category>().Wait();
            database.CreateTableAsync<Assessment>().Wait();
            database.CreateTableAsync<DiseaseClassification>().Wait();
            database.CreateTableAsync<AssessmentClassification>().Wait();
            database.CreateTableAsync<TreatTitle>().Wait();
            database.CreateTableAsync<TreatAilment>().Wait();
            database.CreateTableAsync<TreatAilmentTreatment>().Wait();
            database.CreateTableAsync<CounselTitle>().Wait();
            database.CreateTableAsync<CounselSubContent>().Wait();
            database.CreateTableAsync<Gallery>().Wait();
            database.CreateTableAsync<GalleryAIlment>().Wait();
            database.CreateTableAsync<GalleryItem>().Wait();
        }

        public void clearDatabase(){
            truncateCounty();
            truncateGlosssary();
            truncateHIVCare();
            truncateFollowupAilment();
            truncateFollowup();
            truncateCategory();
            truncateAssessment();
            truncateDiseaseClassification();
            truncateAssessmentClassification();
            truncateTreatTitle();
            truncateTreatAilment();
            truncateTreatAilmentTreatment();
            truncateCounselTitle();
            truncateCounselSubContent();
            truncateGallery();
            truncateGalleryAilment();
            truncateGalleryItem();
        }

        public void truncateCounty()
        {
            database.DropTableAsync<County>().Wait();
            database.CreateTableAsync<County>().Wait();
        }

        public void truncateGlosssary()
        {
            database.DropTableAsync<Glossary>().Wait();
            database.CreateTableAsync<Glossary>().Wait();
        }

        public void truncateHIVCare(){
            database.DropTableAsync<HIVCare>().Wait();
            database.CreateTableAsync<HIVCare>().Wait();
        }

        public void truncateFollowupAilment()
        {
            database.DropTableAsync<FollowupAilment>().Wait();
            database.CreateTableAsync<FollowupAilment>().Wait();
        }

        public void truncateFollowup()
        {
            database.DropTableAsync<Followup>().Wait();
            database.CreateTableAsync<Followup>().Wait();
        }

        public void truncateCategory()
        {
            database.DropTableAsync<Category>().Wait();
            database.CreateTableAsync<Category>().Wait();
        }

        public void truncateAssessment()
        {
            database.DropTableAsync<Assessment>().Wait();
            database.CreateTableAsync<Assessment>().Wait();
        }

        public void truncateDiseaseClassification()
        {
            database.DropTableAsync<DiseaseClassification>().Wait();
            database.CreateTableAsync<DiseaseClassification>().Wait();
        }

        public void truncateAssessmentClassification()
        {
            database.DropTableAsync<AssessmentClassification>().Wait();
            database.CreateTableAsync<AssessmentClassification>().Wait();
        }

        public void truncateTreatTitle()
        {
            database.DropTableAsync<TreatTitle>().Wait();
            database.CreateTableAsync<TreatTitle>().Wait();
        }

        public void truncateTreatAilment()
        {
            database.DropTableAsync<TreatAilment>().Wait();
            database.CreateTableAsync<TreatAilment>().Wait();
        }

        public void truncateTreatAilmentTreatment()
        {
            database.DropTableAsync<TreatAilmentTreatment>().Wait();
            database.CreateTableAsync<TreatAilmentTreatment>().Wait();
        }

        public void truncateCounselTitle()
        {
            database.DropTableAsync<CounselTitle>().Wait();
            database.CreateTableAsync<CounselTitle>().Wait();
        }

        public void truncateCounselSubContent()
        {
            database.DropTableAsync<CounselSubContent>().Wait();
            database.CreateTableAsync<CounselSubContent>().Wait();
        }

        public void truncateGallery()
        {
            database.DropTableAsync<Gallery>().Wait();
            database.CreateTableAsync<Gallery>().Wait();
        }

        public void truncateGalleryAilment()
        {
            database.DropTableAsync<GalleryAIlment>().Wait();
            database.CreateTableAsync<GalleryAIlment>().Wait();
        }

        public void truncateGalleryItem()
        {
            database.DropTableAsync<GalleryItem>().Wait();
            database.CreateTableAsync<GalleryItem>().Wait();
        }

        public Task<List<County>> getCounties(){
            return database.Table<County>().ToListAsync();
        }

        public Task<County> GetCountyAsync(int id){
            return database.Table<County>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCountyAsync(County county){
            return database.InsertAsync(county);
        }

        public int SaveCounty(County county){
            return connection.Insert(county);
        }

        public Task<int> DeleteCountyAsync(County county){
            return database.DeleteAsync(county);
        }

        public Task<int> numberofcounties(){
            var counties = database.Table<County>();
            return counties.CountAsync();
        }

        //Glossary Table
        public Task<int> SaveGlossaryAsync(Glossary glossary){
            return database.InsertAsync(glossary);
        }

        public Task<List<Glossary>> GetGlossaries(){
            return database.Table<Glossary>().ToListAsync();
        }

        public Task<Glossary> GetGlossary(int id){
            return database.Table<Glossary>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        //HIVCare Table
        public Task<int> SaveHIVCare(HIVCare hIVCare){
            return database.InsertAsync(hIVCare);
        }

        public Task<List<HIVCare>> GetHIVCares(){
            return database.Table<HIVCare>().ToListAsync();
        }

        public Task<HIVCare> GetHIVCare(int id)
        {
            return database.Table<HIVCare>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<HIVCare> GetHIVCare(string parent)
        {
            return database.Table<HIVCare>().Where(i => i.parent == parent).FirstOrDefaultAsync();
        }

        //FollowupAilment Table
        public Task<int> saveFollowUpAilment(FollowupAilment followupAilment)
        {
            return database.InsertAsync(followupAilment);
        }

        public Task<List<FollowupAilment>> GetFollowupAilments()
        {
            return database.Table<FollowupAilment>().ToListAsync();
        }

        public Task<FollowupAilment> GetFollowupAilment(int id)
        {
            return database.Table<FollowupAilment>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        //Followup Table
        public Task<int> saveFollowUp(Followup followup)
        {
            return database.InsertAsync(followup);
        }

        public Task<List<Followup>> GetFollowup()
        {
            return database.Table<Followup>().ToListAsync();
        }

        public Task<Followup> GetFollowup(int id)
        {
            return database.Table<Followup>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<Followup> GetFollowupByAilmentID(int ailment_id){
            return database.Table<Followup>().Where(i => i.ailment_id == ailment_id).FirstOrDefaultAsync();
        }

        //Category Table
        public Task<int> saveCategory(Category category)
        {
            return database.InsertAsync(category);
        }

        public Task<List<Category>> GetCategories()
        {
            return database.Table<Category>().ToListAsync();
        }

        public Task<Category> GetCategory(int id)
        {
            return database.Table<Category>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        //Assessment Table
        public Task<int> saveAssessment(Assessment assessment)
        {
            return database.InsertAsync(assessment);
        }

        public Task<List<Assessment>> GetAssessments()
        {
            return database.Table<Assessment>().ToListAsync();
        }

        public Task<Assessment> GetAssessment(int id)
        {
            return database.Table<Assessment>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<Assessment> GetAssessmentByCategory(int category_id)
        {
            return database.Table<Assessment>().Where(i => i.category_id == category_id).FirstOrDefaultAsync();
        }

        //DiseaseClassification Table
        public Task<int> saveDiseaseClassification(DiseaseClassification classification)
        {
            return database.InsertAsync(classification);
        }

        public Task<List<DiseaseClassification>> GetDiseaseClassifications()
        {
            return database.Table<DiseaseClassification>().ToListAsync();
        }

        public Task<DiseaseClassification> GetDiseaseClassification(int id)
        {
            return database.Table<DiseaseClassification>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        // AssessmentClassificationTable
        public Task<int> saveAssessmentClassification(AssessmentClassification assessmentClassification)
        {
            return database.InsertAsync(assessmentClassification);
        }

        public Task<List<AssessmentClassification>> GetAssessmentClassifications()
        {
            return database.Table<AssessmentClassification>().ToListAsync();
        }

        public Task<AssessmentClassification> GetAssessmentClassification(int id)
        {
            return database.Table<AssessmentClassification>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<List<AssessmentClassification>> GetAssessmentClassificationsByDiseaseClassification(int classification_id){
            return database.Table<AssessmentClassification>().Where(i => i.disease_classification_id == classification_id).ToListAsync();
        }

        public Task<List<AssessmentClassification>> GetAssessmentClassificationsByAssessment(int assessment_id)
        {
            return database.Table<AssessmentClassification>().Where(i => i.assessment_id == assessment_id).ToListAsync();
        }

        public Task<List<AssessmentClassification>> GetAssessmentClassificationsByParent(string parent)
        {
            return database.Table<AssessmentClassification>().Where(i => i.parent == parent).ToListAsync();
        }

        //TreatTitle table
        public Task<int> saveTreatTitle(TreatTitle treatTitle)
        {
            return database.InsertAsync(treatTitle);
        }

        public Task<List<TreatTitle>> GetTreatTitles()
        {
            return database.Table<TreatTitle>().ToListAsync();
        }

        public Task<TreatTitle> GetTreatTitle(int id)
        {
            return database.Table<TreatTitle>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        //TreatAilment table
        public Task<int> saveTreatAilment(TreatAilment treatAilment)
        {
            return database.InsertAsync(treatAilment);
        }

        public Task<List<TreatAilment>> GetTreatAilments()
        {
            return database.Table<TreatAilment>().ToListAsync();
        }

        public Task<TreatAilment> GetTreatAilment(int id)
        {
            return database.Table<TreatAilment>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<List<TreatAilment>> GetTreatAilmentByTreatTitle(int treat_title_id){
            return database.Table<TreatAilment>().Where(i => i.treat_titles_id == treat_title_id).ToListAsync();
        }

        //TreatAilmentTreatment table
        public Task<int> saveTreatAilmentTreatment(TreatAilmentTreatment treatAilmentTreatment)
        {
            return database.InsertAsync(treatAilmentTreatment);
        }

        public Task<List<TreatAilmentTreatment>> GetTreatAilmentTreatments()
        {
            return database.Table<TreatAilmentTreatment>().ToListAsync();
        }

        public Task<TreatAilmentTreatment> GetTreatAilmentTreatments(int id)
        {
            return database.Table<TreatAilmentTreatment>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<List<TreatAilmentTreatment>> GetTreatAilmentTreatmentByAilmentID(int ailment_id)
        {
            return database.Table<TreatAilmentTreatment>().Where(i => i.ailment_id == ailment_id).ToListAsync();
        }

        //CounselTitle Table
        public Task<int> saveCounselTitle(CounselTitle counselTitle)
        {
            return database.InsertAsync(counselTitle);
        }

        public Task<List<CounselTitle>> GetCounselTitles()
        {
            return database.Table<CounselTitle>().ToListAsync();
        }

        public Task<CounselTitle> GetCounselTitle(int id)
        {
            return database.Table<CounselTitle>().Where(i => i.id == id).FirstOrDefaultAsync();
        }
        //CounselSubContent Table
        public Task<int> saveCounselSubContent(CounselSubContent counselSubContent)
        {
            return database.InsertAsync(counselSubContent);
        }

        public Task<List<CounselSubContent>> GetCounselSubContents()
        {
            return database.Table<CounselSubContent>().ToListAsync();
        }

        public Task<CounselSubContent> GetCounselSubContent(int id)
        {
            return database.Table<CounselSubContent>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<List<CounselSubContent>> GetCounselSubContentsByCounselTitle(int counsel_title_id)
        {
            return database.Table<CounselSubContent>().Where(i => i.counsel_titles_id == counsel_title_id).ToListAsync();
        }

        //Gallery Table
        public Task<int> saveGallery(Gallery gallery)
        {
            return database.InsertAsync(gallery);
        }

        public Task<List<Gallery>> GetGalleries()
        {
            return database.Table<Gallery>().ToListAsync();
        }

        public Task<Gallery> GetGallery(int id)
        {
            return database.Table<Gallery>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<List<Gallery>> GetGalleries(int ailment_id)
        {
            return database.Table<Gallery>().Where(i => i.gallery_ailments_id == ailment_id).ToListAsync();
        }

        public Task<List<Gallery>> GetGalleries(int ailment_id, int item_id)
        {
            return database.Table<Gallery>().Where(i => (i.gallery_ailments_id == ailment_id && i.gallery_items_id == item_id)).ToListAsync();
        }

        //GalleryAilment Table
        public Task<int> saveGalleryAilment(GalleryAIlment ailment)
        {
            return database.InsertAsync(ailment);
        }

        public Task<List<GalleryAIlment>> GetGalleryAilments()
        {
            return database.Table<GalleryAIlment>().ToListAsync();
        }

        public Task<GalleryAIlment> GetGalleryAilment(int id)
        {
            return database.Table<GalleryAIlment>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        //GalleryItem Table
        public Task<int> saveGalleryItem(GalleryItem item)
        {
            return database.InsertAsync(item);
        }

        public Task<List<GalleryItem>> GetGalleryItems()
        {
            return database.Table<GalleryItem>().ToListAsync();
        }

        public Task<GalleryItem> GetGalleryItem(int id)
        {
            return database.Table<GalleryItem>().Where(i => i.id == id).FirstOrDefaultAsync();
        }
    }
}
