using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO2FinalProject.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Required]
        [Column("department_name")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Column("location_id")]
        public int? LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty(nameof(Locations.Department))]
        public virtual Locations Location { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
