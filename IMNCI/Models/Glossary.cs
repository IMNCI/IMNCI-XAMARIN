using System;
using SQLite;

namespace IMNCI.Models
{
    public class Glossary
    {
        [PrimaryKey]
        public int id { get; set;}
        public string acronym { get; set; }
        public string description { get; set; }
    }
}
