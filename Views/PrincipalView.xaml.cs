using MotoAPP.Services;
using MotoAPP.Models;
using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class PrincipalView : ContentPage
{
	public PrincipalView(MotoVM motoVM)
	{
		InitializeComponent();

		BindingContext = motoVM;
	}
}