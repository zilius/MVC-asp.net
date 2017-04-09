using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_BA_TASK.Models.Models
{
    //Yup, no entity framework
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage ="Required")]
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name ="Date of birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(255,MinimumLength =8,ErrorMessage ="Password must be at least 8 chars")]
        public string Password { get; set; }


        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name="Comfirm Passwrod")]
        public string ComfirmPassword { get; set; }

        [Display(Name="Additional Info")]
        public string AdditionalInfo { get; set; }

    }
}