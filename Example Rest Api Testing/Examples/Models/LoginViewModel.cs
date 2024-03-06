using System.ComponentModel.DataAnnotations;

namespace Examples.Models;
public class LoginViewModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
