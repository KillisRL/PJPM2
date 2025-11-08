using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class PgPrincipalCliente : ContentPage
{
	public PgPrincipalCliente(MotoVM motoVM)
	{
		InitializeComponent();
		BindingContext = motoVM;

    }
}