using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class MinhasComprasView : ContentPage
{
    private readonly MinhasComprasVM _viewModel;

    public MinhasComprasView(MinhasComprasVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    // Carrega os dados toda vez que a tela aparecer
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.CarregarMinhasComprasCommand.Execute(null);
    }
}