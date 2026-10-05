using ClubSocial.ViewModels;
using Microsoft.Maui.Controls;

namespace ClubSocial.Views
{
    public partial class DetalleClimaPage : ContentPage
    {
        public DetalleClimaPage(DetalleClimaViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}