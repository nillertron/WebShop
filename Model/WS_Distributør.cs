using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class WS_Distributør : BaseEntity
    {
        [Required]
        public string Navn { get; set; }
        [Required]
        public string CVR { get; set; }
        [Required]
        public string Adresse { get; set; }
    }
}
