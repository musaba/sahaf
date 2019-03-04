using System;

namespace Entity.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int State { get; set; }
        public string Title { get; set; }
        public int LatestVersion { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
