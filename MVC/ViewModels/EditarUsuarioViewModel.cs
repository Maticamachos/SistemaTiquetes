using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class EditarUsuarioViewModel : CrearUsuarioViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "El usuario no es válido.")]
        public int UsuarioId { get; set; }
    }
}