using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MessageBoardApp.Models
{
    public class ApplicationUser : IdentityUser
    {
    [Required]
    [StringLength(20, ErrorMessage = "Maximum amount of characters for the username is 20")]
    public override string UserName { get; set; }
    public string UserBio { get; set; }
    [Required]
    public override string Email { get; set; }
    [Required]
    public override string PasswordHash { get; set; }
    public int PostCount { get; set; }
    }
}