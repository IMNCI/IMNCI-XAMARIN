using System;
namespace IMNCI.Models
{
    public class TreatAilmentTreatment
    {
        public int id { get; set; }
        public int ailment_id { get; set; }
        public string treatment { get; set; }
        public string content { get; set; }
    }
}
