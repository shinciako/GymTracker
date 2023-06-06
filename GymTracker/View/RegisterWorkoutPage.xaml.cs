using CommunityToolkit.Maui.Views;

namespace GymTracker.View;

public partial class RegisterWorkoutPage : ContentPage
{
    private RegisterWorkoutViewModel viewModel;

    public RegisterWorkoutPage(RegisterWorkoutViewModel viewModel)
	{
        InitializeComponent();
        viewModel = new RegisterWorkoutViewModel();
        BindingContext = viewModel;
    }

    public void AddSelectedExercise(Exercise exercise)
    {
        viewModel.AddExercise(exercise);
    }
}
