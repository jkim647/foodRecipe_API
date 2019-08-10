using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Model
{
    public partial class Restaurant
    {
        [Column("Restaurant")]
        public int Restaurant1 { get; set; }
        [Required]
        [StringLength(500)]
        public string Names { get; set; }
        public int? Latitude { get; set; }
        public int? Longitude { get; set; }
        public int? FoodId { get; set; }

        [ForeignKey("FoodId")]
        [InverseProperty("Restaurant")]
        public virtual Food Food { get; set; }
    }
}
