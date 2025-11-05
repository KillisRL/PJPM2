using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

		BindingContext = new UserVM();
	}
}