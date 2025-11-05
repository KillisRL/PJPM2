using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class CadMotoView : ContentPage
{
	public CadMotoView(MotoVM motoVM)
	{
		InitializeComponent();

        BindingContext = motoVM;
    }
}