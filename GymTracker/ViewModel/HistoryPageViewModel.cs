using System;
using System.Windows.Input;

namespace GymTracker.ViewModel;

public class HistoryPageViewModel
{
    public ObservableCollection<Session> sessions { get; set; }
    public List<Exercise> exercises { get; set; }
    public ICommand DeleteSessionCommand { get; }
    SessionDb sessionDb;

    public HistoryPageViewModel()
    {
        DeleteSessionCommand = new Command<Session>(DeleteSession);
        sessionDb = new SessionDb();
        sessions = new ObservableCollection<Session>(sessionDb.GetSessions());

        //to be refactored - null exercise when getting from sessions
        exercises = sessionDb.GetExercises();

        foreach (var session in sessions)
        {
            if (session.Trainings != null && session.Trainings.Count > 0)
            {
                foreach (var training in session.Trainings)
                {
                    training.Exercise = exercises[training.ExerciseId - 1];
                }
            }
            else
            {
                Console.WriteLine("No trainings found for this session.");
            }
        }
    }

    private void DeleteSession(Session session)
    {
        sessionDb.DeleteSession(session);
    }

}