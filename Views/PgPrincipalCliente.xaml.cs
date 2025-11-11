// Em PgPrincipalCliente.xaml.cs
using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class PgPrincipalCliente : ContentPage
{
    private readonly MotoVM _viewModel; // Ou o nome da sua ViewModel principal do cliente

    public PgPrincipalCliente(MotoVM viewModel) // Injeta a ViewModel
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Chama o comando para carregar as motos (assumindo que MotoVM tem este comando)
        _viewModel.CommandVisualizar.Execute(null);
    }
}