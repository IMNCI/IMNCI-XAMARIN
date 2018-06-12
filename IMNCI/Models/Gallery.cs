using System;
namespace IMNCI.Models
{
    public class Gallery
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int gallery_ailments_id { get; set; }
        public int gallery_items_id { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string gallery_item_name { get; set; }
    }
}
