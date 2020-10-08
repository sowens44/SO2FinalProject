using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO2FinalProject.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [Column("job_id")]
        public int JobId { get; set; }
        [Required]
        [Column("title")]
        [StringLength(30)]
        public string Title { get; set; }
        [Column("min_salary", TypeName = "numeric(10, 2)")]
        public decimal? MinSalary { get; set; }
        [Column("max_salary", TypeName = "numeric(10, 2)")]
        public decimal? MaxSalary { get; set; }

        [InverseProperty("Job")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
