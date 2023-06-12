using System.Windows.Input;
using CommunityToolkit.Maui.Views;

namespace GymTracker.ViewModel;

public class RegisterWorkoutViewModel : BaseViewModel
{
    public ObservableCollection<Training> Trainings { get; set; }
    private List<Training> _trainings { get; set; }
    private RegisterWorkoutViewModel _viewModel;

    public RegisterWorkoutViewModel()
    {
        _viewModel = this;
        Trainings = new();
        _trainings = new();
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

        if (newSession.Trainings.Count < 0)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "You need to add Exercise", "OK");
        }
        else
        {
            sessionDb.AddSession(newSession);
            ClearTraining();
        }

        //var sessions = sessionDb.GetSessions();

        //foreach (var session in sessions)
        //{
        //    Console.WriteLine($"Session ID: {session.Id}");
        //    if (session.Trainings != null && session.Trainings.Count > 0)
        //    {
        //        foreach (var training in session.Trainings)
        //        {
        //            Console.WriteLine($"Weight: {training.Weight}");
        //            Console.WriteLine($"Repetition: {training.Repetition}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No trainings found for this session.");
        //    }
        //}
    }

    public ICommand CancelCommand => new Command(ClearTraining);

    public void ClearTraining()
    {
        Trainings.Clear();
        _trainings.Clear();
        Application.Current.MainPage.Navigation.PopToRootAsync();
    }
}
