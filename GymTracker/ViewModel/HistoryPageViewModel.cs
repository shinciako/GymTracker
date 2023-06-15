using System;
using System.Windows.Input;

namespace GymTracker.ViewModel;

public class HistoryPageViewModel
{
    public ObservableCollection<Session> sessions { get; set; }
    public List<Exercise> exercises { get; set; }
    SessionDb sessionDb;

    public HistoryPageViewModel()
    {
        sessionDb = new SessionDb();
        sessions = new ObservableCollection<Session>(sessionDb.GetSessions());

        //to be refactored - null exercise when getting from sessions
        exercises = sessionDb.GetExercises();

        if(sessions.Count > 0)
        {
            foreach (var session in sessions)
            {
                if (session.Trainings != null && session.Trainings.Count > 0)
                {
                    foreach (var training in session.Trainings)
                    {
                        training.Exercise = exercises[training.ExerciseId - 1];
                    }
                }
            }
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Error", "You need to add an Session", "OK");
        }
    }

    public void DeleteSession(Session session)
    {
        sessionDb.DeleteSession(session);
    }

}