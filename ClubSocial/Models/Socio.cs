using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocial.Models
{
    public class Socio
    {
        // Este número nos sirve para identificar al socio dentro de la app.
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        // El DNI se guarda como texto porque no hacemos cálculos con él.
        public string Dni { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // Por ahora cada socio tiene un sector principal del club.
        public string Sector { get; set; } = string.Empty;

        // Al dar de alta un socio, arrancamos con la fecha de hoy.
        public DateTime FechaAlta { get; set; } = DateTime.Today;

        // Podemos marcarlo como inactivo sin borrar sus datos.
        public bool Activo { get; set; } = true;
    }
}
