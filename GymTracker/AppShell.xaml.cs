namespace GymTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RegisterWorkoutPage), typeof(RegisterWorkoutPage));
	}
}

