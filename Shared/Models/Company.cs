
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BPS_Shared.Models
{
    //[NotMapped]

    [Index(nameof(CP_Email), nameof(CP_Phone), IsUnique = true)]

    public class Company
    {
        [Key]
        public int CP_Id { get; set; }

        [Required(ErrorMessage = "Please fill in Code section")]
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        public string CP_Name { get; set; }


        [Required]
        [EmailAddress]
        public string CP_Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string CP_Password { get; set; }

        [NotMapped]
        //[JsonIgnore]
        [Compare(nameof(CP_Password), ErrorMessage = "Passwords don't match.")]
        public string C_ConfirmPassword { get; set; }

        [Required]
        public string CP_Phone { get; set; }

        [ForeignKey(nameof(Bill.Company_Id))]
        public List<Bill> Bills { get; set; } = new List<Bill>();

        

    }
}
