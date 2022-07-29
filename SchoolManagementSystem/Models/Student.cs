using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{

    [Index(nameof(StudentId), IsUnique = true)]
    [Index(nameof(CNIC),IsUnique =true)]
    public class Student:Person
    {
        public string StudentId { get; set; }

        [EnumDataType(typeof(Class))]
        public Class Class { get; set; }
        public string Section { get; set; }=String.Empty;

        [Required(ErrorMessage = "{0} is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime DateOfAdmission { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [ForeignKey("Guardian")]
        public int GuardianID { get; }
        public Guardian? Guardian { get; set; }
    }
}
