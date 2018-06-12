using System;
using SQLite;


namespace IMNCI.Models
{
    public class County
    {
        [PrimaryKey]
        public int id { get; set; }
        public string county { get; set; }
    }
}
