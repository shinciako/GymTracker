namespace GymTracker.ViewModel;

public partial class MainPageViewModel: BaseViewModel
{
    public ObservableCollection<Template> Templates { get; } = new ObservableCollection<Template>()
    {
        new Template("Legs", "Squat, Extension"),
        new Template("Legs", "Bench press, Incline Bench"),
        new Template("Legs", "Squat, Extension"),
        new Template("Legs", "Bench press, Incline Bench"),
    };


    public MainPageViewModel()
	{
	}

	[RelayCommand]
	async Task GoToRegisterWorkout()
	{
		await Shell.Current.GoToAsync(nameof(RegisterWorkoutPage));
	}
}

