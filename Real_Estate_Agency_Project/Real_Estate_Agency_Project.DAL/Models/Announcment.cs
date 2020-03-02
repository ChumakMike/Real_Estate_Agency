using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate_Agency_Project.DAL.Models {

    internal class Announcment {
        [Key]
        public int AnnouncmentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title length should be less than 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(15000, ErrorMessage = "Description length should be less than 15000 characters")]
        public string Description { get; set; }

        [Required]
        public int Square { get; set; }

        [Required]
        public int RoomsNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Floors { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Renovation { get; set; }

        [Required]
        public string Objective { get; set; }
        
        [ForeignKey("AuthorId")]
        public string UserId { get; set; }
        public virtual UserProfile Author { get; set; }
    }
}
