using System.ComponentModel.DataAnnotations;

namespace AppBanco.Library.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmacaoPassword { get; set; }


        public bool RemmemberMe { get; set; } = false;
    }
}
