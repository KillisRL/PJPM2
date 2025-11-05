using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class VisMotoView : ContentPage
{
	public VisMotoView(MotoVM motoVM)
	{
		InitializeComponent();

        BindingContext = motoVM;
    }
}