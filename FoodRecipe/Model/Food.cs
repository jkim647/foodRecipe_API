using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Model
{
    public partial class Food
    {
        public Food()
        {
            Restaurant = new HashSet<Restaurant>();
        }

        public int FoodId { get; set; }
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public int? Cal { get; set; }
        [StringLength(500)]
        public string Ingredients { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        [Column("isFavourite")]
        public bool? IsFavourite { get; set; }

        [InverseProperty("Food")]
        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
