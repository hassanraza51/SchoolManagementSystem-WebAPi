using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    [Index(nameof(TeacherID),IsUnique =true)]
    public class Teacher:Person
    {
        public string TeacherID { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
    }
}
