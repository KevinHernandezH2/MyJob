using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyJob.Models
{
    public class Postulaciones
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public int UsuarioId { get; set; }

            [Required]
            public int EmpleoId { get; set; }

            public DateTime FechaPostulacion { get; set; }

            [ForeignKey("UsuarioId")]
            public Usuario? Usuario { get; set; }

            [ForeignKey("EmpleoId")]
            public Empleo? Empleo { get; set; }
        }
    }

