using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyJob.Models
{
    public class Empleo
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public int EmpresaId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Titulo { get; set; }

            public string Descripcion { get; set; }

            [MaxLength(100)]
            public string Ubicacion { get; set; }

            public DateTime FechaPublicacion { get; set; }

            [ForeignKey("EmpresaId")]
            public Empresa Empresa { get; set; }
        }
    }


