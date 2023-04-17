using CommunityToolkit.Maui.Views;

namespace GymTracker.View;

public partial class RegisterWorkoutPage : ContentPage
{
	public RegisterWorkoutPage(RegisterWorkoutViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
