using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoLeasingSystem.Core
{
    public class UserMovieRecord
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Video Video { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int DueAmount { get; set; }
    }
}
