using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class CompraMotoView : ContentPage
{
	public CompraMotoView(CompraVM compraVM)
	{
		InitializeComponent();

		BindingContext = compraVM;
	}
}