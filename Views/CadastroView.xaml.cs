using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class CadastroView : ContentPage
{
	public CadastroView()
	{
		InitializeComponent();

		BindingContext = new UserVM();
	}
}