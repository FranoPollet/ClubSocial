using ClubSocial.ViewModels;
using Microsoft.Maui.Controls;

namespace ClubSocial.Views
{
    public partial class ClimaPage : ContentPage
    {
        public ClimaPage(ClimaViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}