using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSocial.Models;
using Microsoft.Maui.Controls;

namespace ClubSocial.ViewModels
{
    // "dia" es la misma clave que enviamos al navegar.
    [QueryProperty(nameof(Dia), "dia")]
    public class DetalleClimaViewModel : BaseViewModel
    {
        private PronosticoDia? _dia;

        public PronosticoDia? Dia
        {
            get => _dia;
            set => SetProperty(ref _dia, value);
        }
    }
}