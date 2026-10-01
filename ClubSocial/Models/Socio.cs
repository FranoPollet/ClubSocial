using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocial.Models
{
    public class Socio
    {
        // SQLite genera este número cuando guardamos un socio nuevo.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        // El índice también evita guardar dos socios con el mismo DNI.
        [Indexed(Unique = true)]
        public string Dni { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Sector { get; set; } = string.Empty;

        public DateTime FechaAlta { get; set; } = DateTime.Today;

        public bool Activo { get; set; } = true;
    }
}
