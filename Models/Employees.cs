using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO2FinalProject.Models
{
    public partial class Employees
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("phone_num")]
        [StringLength(25)]
        public string PhoneNum { get; set; }
        [Column("hire_date", TypeName = "datetime")]
        public DateTime HireDate { get; set; }
        [Column("job_id")]
        public int? JobId { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(JobId))]
        [InverseProperty(nameof(Jobs.Employees))]
        public virtual Jobs Job { get; set; }
    }
}
