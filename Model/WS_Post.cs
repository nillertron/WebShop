using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class WS_Post:BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage ="Write a district")]
        public string Distrikt { get; set; }
        [Required]
        public int PostNr { get; set; }
    }
}
