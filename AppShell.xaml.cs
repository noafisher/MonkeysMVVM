using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RoutingPages();
	}

    private void RoutingPages()
    {
		Routing.RegisterRoute("ShowMonkey", typeof(ShowMonkeyView));
    }
}
