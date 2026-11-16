using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingresá tu correo.")]
        [EmailAddress(ErrorMessage = "Ingresá un correo válido.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingresá tu contraseña.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ingresá tu correo.")]
        [EmailAddress(ErrorMessage = "Ingresá un correo válido.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingresá una contraseña.")]
        [StringLength(
            100,
            MinimumLength = 8,
            ErrorMessage = "La contraseña debe tener entre 8 y 100 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmá tu contraseña.")]
        [DataType(DataType.Password)]
        [Compare(
            "Password",
            ErrorMessage = "Las contraseñas no coinciden.")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
    }
}