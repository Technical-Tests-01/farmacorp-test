using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace activate_assurance.Models
{
    public class BaseEntity
    {
        [Required]
        public DateTime createdAt { get; set; }


        public DateTime lastUpdated { get; set; }

        public int isDeleted { get; set; }

    }
}