using System;
namespace IMNCI.Models
{
    public class CounselTitle
    {
        public int id { get; set; }
        public int age_group_id {get;set;}
        public string title { get; set; }
        public string content { get; set; }
        public int is_parent { get; set; }
    }
}
