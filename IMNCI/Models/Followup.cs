using System;
namespace IMNCI.Models
{
    public class Followup
    {
        public int id { get; set; }
        public int ailment_id { get; set; }
        public string advice { get; set; }
        public string treatment { get; set; }
    }
}
