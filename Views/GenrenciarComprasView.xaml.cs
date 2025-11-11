using MotoAPP.ViewModels;
namespace MotoAPP.Views;

public partial class GenrenciarComprasView : ContentPage
{
	private readonly GerenciarComprasVM _gerenciarCompras; 
    public GenrenciarComprasView(GerenciarComprasVM gerenciarComprasVM)
	{
		InitializeComponent();

		BindingContext = gerenciarComprasVM;
		_gerenciarCompras = gerenciarComprasVM;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _gerenciarCompras.CarregarMinhasComprasCommand.Execute(null);
    }
}