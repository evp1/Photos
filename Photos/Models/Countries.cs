using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Photo.Models
{
    public class Countries
    {
        public Countries() {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Country { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        

    }
}
