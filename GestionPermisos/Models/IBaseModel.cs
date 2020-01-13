using System.ComponentModel.DataAnnotations;

namespace GestionPermisos.Models
{
    public interface IBaseModel
    {
        [Key]
        int Id { get; set; }

    }
}