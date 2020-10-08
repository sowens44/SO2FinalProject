using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO2FinalProject.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Locations = new HashSet<Locations>();
        }

        [Key]
        [Column("country_id")]
        public int CountryId { get; set; }
        [Required]
        [Column("country_name")]
        [StringLength(50)]
        public string CountryName { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
