using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocial.Models
{
    public class PronosticoDia
    {
        public DateTime Fecha { get; set; }

        public double TemperaturaMinima { get; set; }

        public double TemperaturaMaxima { get; set; }

        public double ProbabilidadLluvia { get; set; }
    }
}
