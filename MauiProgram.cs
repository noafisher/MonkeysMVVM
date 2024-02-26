using Microsoft.Extensions.Logging;
using MonkeysMVVM.Services;
using MonkeysMVVM.ViewModels;
using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

			});
		builder.Services.AddSingleton<MonkeysService>()
	.AddTransient<FindMonkeyByLocationPage>()
	.AddTransient<MonkeysPageViewModel>()
	.AddTransient<ShowMonkeyViewModel>()
	.AddTransient<MonkeysPage>()
	.AddTransient<FindMonkeyByLocationPage>()
	.AddTransient<ShowMonkeyView>();			
		


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
