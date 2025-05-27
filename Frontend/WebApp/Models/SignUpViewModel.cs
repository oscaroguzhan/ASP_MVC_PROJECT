using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Required]
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = string.Empty;

    
    [Display(Name = "Email Address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Username", Prompt = "Choose a username")]
    [Required(ErrorMessage = "Username is required.")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Confirm Password", Prompt = "Re-enter your password")]
    [Required(ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty; 

    public bool Terms { get; set; } 
}
