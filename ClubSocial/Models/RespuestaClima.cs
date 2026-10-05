using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubSocial.Models
{
    // Esta clase sigue la estructura del JSON que devuelve la API de Open-meteo para el pronóstico del clima.
    public class RespuestaClima
    {
        [JsonPropertyName("daily")]
        public DatosDiarios? Dias { get; set; }
    }

    public class DatosDiarios
    {
        [JsonPropertyName("time")]
        public List<string>? Fechas { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double?>? TemperaturasMinimas { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double?>? TemperaturasMaximas { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<double?>? ProbabilidadesLluvia { get; set; }
    }
}
