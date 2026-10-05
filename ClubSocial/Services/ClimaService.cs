using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClubSocial.Models;

namespace ClubSocial.Services
{
    public class ClimaService
    {
        private readonly HttpClient _httpClient;

        public ClimaService()
        {
            // Reutilizamos este cliente para las consultas.
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.open-meteo.com/"),
                Timeout = TimeSpan.FromSeconds(20)
            };
        }

        public async Task<List<PronosticoDia>> ObtenerPronosticoAsync()
        {
            // Buenos Aires es nuestra ubicación de ejemplo.
            string consulta =
                "v1/forecast?latitude=-34.6037&longitude=-58.3816" +
                "&daily=temperature_2m_min,temperature_2m_max," +
                "precipitation_probability_max" +
                "&temperature_unit=celsius" +
                "&timezone=America%2FArgentina%2FBuenos_Aires" +
                "&forecast_days=7";

            using var respuesta = await _httpClient.GetAsync(consulta);

            // Conserva el código HTTP si el servidor responde con un error.
            respuesta.EnsureSuccessStatusCode();

            string json = await respuesta.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<RespuestaClima>(json);

            var dias = resultado?.Dias;

            if (dias == null ||
                dias.Fechas == null ||
                dias.TemperaturasMinimas == null ||
                dias.TemperaturasMaximas == null ||
                dias.ProbabilidadesLluvia == null)
            {
                throw new JsonException(
                    "La respuesta no contiene los datos diarios esperados.");
            }

            int cantidad = dias.Fechas.Count;

            // Las listas deben tener un valor por cada fecha.
            if (dias.TemperaturasMinimas.Count != cantidad ||
                dias.TemperaturasMaximas.Count != cantidad ||
                dias.ProbabilidadesLluvia.Count != cantidad)
            {
                throw new JsonException(
                    "Las listas del pronóstico tienen diferentes tamaños.");
            }

            var pronostico = new List<PronosticoDia>();

            for (int i = 0; i < cantidad; i++)
            {
                bool fechaValida = DateTime.TryParseExact(
                    dias.Fechas[i],
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fecha);

                if (!fechaValida ||
                    !dias.TemperaturasMinimas[i].HasValue ||
                    !dias.TemperaturasMaximas[i].HasValue ||
                    !dias.ProbabilidadesLluvia[i].HasValue)
                {
                    throw new JsonException(
                        "Hay un día con datos incompletos o una fecha inválida.");
                }

                // Juntamos los valores de la misma posición.
                pronostico.Add(new PronosticoDia
                {
                    Fecha = fecha,
                    TemperaturaMinima =
                        dias.TemperaturasMinimas[i]!.Value,
                    TemperaturaMaxima =
                        dias.TemperaturasMaximas[i]!.Value,
                    ProbabilidadLluvia =
                        dias.ProbabilidadesLluvia[i]!.Value
                });
            }

            return pronostico;
        }
    }
}
