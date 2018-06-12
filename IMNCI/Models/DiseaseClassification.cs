using System;

using SQLite;
namespace IMNCI.Models
{
    public class DiseaseClassification
    {
        [PrimaryKey]
        public int id { get; set; }
        public string classification { get; set; }
        public string description { get; set; }
        public string color { get; set; }
    }
}
