using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class ShowMonkeyView : ContentPage
{
	public ShowMonkeyView(ShowMonkeyViewModel showMonkeyViewModel)
	{
		InitializeComponent();
		this.BindingContext = showMonkeyViewModel;
	}
}