using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CrearUsuarioViewModel
    {
        [Required(ErrorMessage = "Escribe el nombre.")]
        [StringLength(100, ErrorMessage = "El nombre debe contener menos de 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escribe el primer apellido.")]
        [StringLength(100, ErrorMessage = "El apellido debe contener menos de 100 caracteres.")]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Escribe el segundo apellido.")]
        [StringLength(100, ErrorMessage = "El apellido debe contener menos de 100 caracteres.")]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Escribe el correo.")]
        [StringLength(100, ErrorMessage = "El correo debe contener menos de 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Escribe un correo electrónico válido.")]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Selecciona un rol.")]
        [Display(Name = "Rol")]
        public int? RolId { get; set; }

        [Required(ErrorMessage = "Selecciona un estado.")]
        [Display(Name = "Estado")]
        public int? EstadoId { get; set; }
    }
}