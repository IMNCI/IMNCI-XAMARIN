using System;
using SQLite;

namespace IMNCI.Models
{
    public class HIVCare
    {
        [PrimaryKey]
        public int id { get; set; }
        public string title { get; set; }
        public string parent { get; set; }
        public string content { get; set; }
    }
}
