using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO2FinalProject.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Department = new HashSet<Department>();
        }

        [Key]
        [Column("location_id")]
        public int LocationId { get; set; }
        [Required]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [Column("state_province")]
        [StringLength(2)]
        public string StateProvince { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Locations))]
        public virtual Countries Country { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<Department> Department { get; set; }
    }
}
