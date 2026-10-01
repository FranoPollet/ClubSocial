using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSocial.Models;

namespace ClubSocial.Repositories
{
    public interface ISocioRepository
    {
        Task<List<Socio>> ObtenerTodosAsync();

        Task<Socio?> ObtenerPorDniAsync(string dni);

        Task<int> GuardarAsync(Socio socio);

        Task<int> EliminarAsync(Socio socio);
    }
}
