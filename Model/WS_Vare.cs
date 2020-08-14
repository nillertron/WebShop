using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class WS_Vare:BaseEntity
    {
        [Required]
        public string Navn { get; set; }
        [Required]
        public string Beskrivelse { get; set; }
        [Required]
        public double Pris { get; set; }
        [Required]
        public int AntalLager { get; set; }
        [Required]
        public double IndkøbsPris { get; set; }
        [Required]
        public double Discount { get; set; }
        public WS_Distributør Distributør { get; set; }
        public DateTime Oprettet { get; set; }
        public WS_Category Category { get; set; }
        public List<WS_Pictures> PictureList { get; set; } = new List<WS_Pictures>();
        [NotMapped]
        public string DisplayPrice { get => Discounted?$"${DiscountedPrice}":$"${Pris}"; }
        [NotMapped]
        public bool Discounted { get; set; } = false;
        [NotMapped]
        public double DiscountedPrice { get; set; }
    }
}
