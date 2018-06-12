using System;
namespace IMNCI.Models
{
    public class Assessment
    {
        public int id { get; set; }
        public int age_group_id { get; set; }
        public int category_id { get; set; }
        public string title { get; set; }
        public string assessment { get; set; }
    }
}
