using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MaqtaAssignment.Models
{
    public class Employees
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string firstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string lastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DateOfBrirth { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Department { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string JobTitle { get; set; }
        public decimal? Salary { get; set; }
    }
}
