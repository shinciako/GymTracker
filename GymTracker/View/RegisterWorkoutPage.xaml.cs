using CommunityToolkit.Maui.Views;

namespace GymTracker.View;

public partial class RegisterWorkoutPage : ContentPage
{
    private RegisterWorkoutViewModel viewModel;

    public RegisterWorkoutPage(RegisterWorkoutViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }


    public void AddSelectedExercise(Exercise exercise)
    {
        viewModel.AddExercise(exercise);
    }
}
