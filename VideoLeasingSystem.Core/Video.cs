using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VideoLeasingSystem.Core
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string VideoName { get; set; }
        public string Language { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public int NoOfCopies { get; set; }
        public string LeaseAmount { get; set; }
    }
}
