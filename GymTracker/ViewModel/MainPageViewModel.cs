namespace GymTracker.ViewModel;

public partial class MainPageViewModel: BaseViewModel
{
	public ObservableCollection<Template> Templates { get; }
    private SessionDb sessionDb; 

    public MainPageViewModel()
    {
        sessionDb = new();
        var exercises = sessionDb.GetExercises();

        Templates = new()
        {
            new Template { Name = "Chest Workout", Exercises = exercises.Where(e => e.MusclePart == "Chest").ToList() },
            new Template { Name = "Leg Workout", Exercises = exercises.Where(e => e.MusclePart == "Lower body").ToList() }
        };
    }

    [RelayCommand]
	async Task GoToRegisterWorkout()
	{
        var registerWorkoutPage = new RegisterWorkoutPage(new RegisterWorkoutViewModel(null));
        await Shell.Current.Navigation.PushAsync(registerWorkoutPage);
	}
}

