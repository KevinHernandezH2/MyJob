using System.ComponentModel.DataAnnotations;

namespace MyJob.Models
{
        public class Usuario
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Nombre { get; set; }

            [Required]
            [MaxLength(100)]
            public string Correo { get; set; }

            [Required]
            [MaxLength(100)]
            public string Contraseña { get; set; }

            [MaxLength(20)]
            public string Telefono { get; set; }

            [MaxLength(100)]
            public string Ubicacion { get; set; }
        }
    }



