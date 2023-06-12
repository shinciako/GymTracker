using System.Windows.Input;
using CommunityToolkit.Maui.Views;

namespace GymTracker.ViewModel;

public class RegisterWorkoutViewModel : BaseViewModel
{
    public ObservableCollection<Training> Trainings { get; set; }
    private List<Training> _trainings { get; set; }
    private RegisterWorkoutViewModel _viewModel;

    public RegisterWorkoutViewModel(List<Exercise> exercices)
    {
        _viewModel = this;
        Trainings = new();
        _trainings = new();
        if (exercices != null)
        {
            foreach (var exercise in exercices)
            {
                AddExercise(exercise);
            }
        }
    }

    public ICommand DisplayPopupCommand => new Command(DisplayPopup);

    public void DisplayPopup()
    {
        var popup = new ModalBoxExercises(this);
        popup.BindingContext = new ModalBoxExercisesViewModel();
        Shell.Current.CurrentPage.ShowPopup(popup);
    }


    public void AddExercise(Exercise exercise)
    {
        Training training = new Training
        {
            Weight = 0,
            Repetition = 0,
            ExerciseId = exercise.Id,
            Exercise = exercise
        };
        Trainings.Add(training);
        _trainings.Add(training);
    }

    public ICommand CompleteSessionCommand => new Command(CompleteSession);

    public async void CompleteSession()
    {
        SessionDb sessionDb = new SessionDb();
        Session newSession = new Session { Timestamp = DateTime.Now, Trainings = _trainings};
        if (newSession.Trainings.Count > 0)
        {
            sessionDb.AddSession(newSession);
            ClearTraining(); 
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "You need to add an Exercise", "OK");
        }
    }

    public ICommand CancelCommand => new Command(ClearTraining);

    public void ClearTraining()
    {
        Trainings.Clear();
        _trainings.Clear();
        Application.Current.MainPage.Navigation.PopToRootAsync();
    }
}
