using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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

    [DataContract]
    public class VideoDTO
    {
        [DataMember]
        public int FoodId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Cal { get; set; }

        [DataMember]
        public string Ingredients { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public bool IsFavourite { get; set; }
    }
}
