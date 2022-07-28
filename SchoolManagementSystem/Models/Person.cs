using SchoolManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public abstract class Person
    {
        [Key]
        public int ID { get; set; }
        public byte[]? Image { get; set; }
        
        [Required(ErrorMessage ="{0} is required")]
        [Display(Name = "First Name")]
        [MinLength(3,ErrorMessage ="{0} should have minimum {1} characters")]
        public string FirstName { get; set; }=String.Empty;

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "{0} should have minimum {1} characters")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "{0} is required")]
        public int CNIC { get; set; }

      
        public Gender Gender { get; set; }
        

        [Required(ErrorMessage ="{0} is required")] 
        public int ContactNumber { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [MinLength(5,ErrorMessage ="{0} should have minimum {1} characters")]
        public string Address { get; set; }=String.Empty;

        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }=String.Empty;
    }
}
