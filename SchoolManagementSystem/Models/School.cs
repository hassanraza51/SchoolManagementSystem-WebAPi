using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class School
    {
        [Required(ErrorMessage ="{0} is required")]
        [MinLength(5,ErrorMessage ="School {0} should be more than {1} characters")]
        public string Name { get; set; }
        [Key]
        public string RegistrationID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(5,ErrorMessage ="{0} should be more than {1} characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int PhoneNo { get; set; }
        public string? Description { get; set; }

    }
}
