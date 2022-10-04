using System.ComponentModel.DataAnnotations;
namespace crudCore.Models
{
    public class ContactoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
