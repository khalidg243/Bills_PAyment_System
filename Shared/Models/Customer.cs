
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BPS_Shared.Models;

//[Keyless]
[Index(nameof(C_Passport_No), nameof(C_Email), nameof(C_Phone), IsUnique = true)]
public class Customer
{
    [Key]
    public int C_Id { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
    
    public string C_Name { get; set; }

    [Required]
    [EmailAddress]
    public string C_Email { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
    public string C_Password { get; set; }

    [NotMapped]
    [Compare(nameof(C_Password), ErrorMessage = "Passwords don't match.")]
    public string C_ConfirmPassword { get; set; }

    [Required]
    public string C_Phone { get; set; }

    [Required]
    public string C_Passport_No { get; set; }

    [ForeignKey(nameof(Bill.Customer_Id))]
    public List<Bill> Bills { get; set; } = new List<Bill>();
}
