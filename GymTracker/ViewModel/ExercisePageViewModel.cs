using System.Collections.ObjectModel;
using System.Linq;
using GymTracker.Model;

namespace GymTracker.ViewModel
{
    public class ExercisePageViewModel : BaseViewModel
    {
        private SessionDb sessionDb;
        private ObservableCollection<Exercise> _exercises;
        private ObservableCollection<Exercise> _filteredExercises;
        private string _selectedMusclePart;

        public ObservableCollection<Exercise> Exercises
        {
            get { return _exercises; }
            set { SetProperty(ref _exercises, value); }
        }

        public ObservableCollection<Exercise> FilteredExercises
        {
            get { return _filteredExercises; }
            set { SetProperty(ref _filteredExercises, value); }
        }

        public string SelectedMusclePart
        {
            get { return _selectedMusclePart; }
            set
            {
                SetProperty(ref _selectedMusclePart, value);
                ApplyFilter(_selectedMusclePart);
            }
        }

        public ExercisePageViewModel()
        {
            sessionDb = new SessionDb();
            Exercises = new ObservableCollection<Exercise>(sessionDb.GetExercises().ToList());
            FilteredExercises = new ObservableCollection<Exercise>(Exercises);
        }

        public void ApplyFilter(string musclePart)
        {
            if (string.IsNullOrEmpty(musclePart) || musclePart.Equals("All"))
            {
                FilteredExercises = new ObservableCollection<Exercise>(Exercises);
            }
            else
            {
                FilteredExercises = new ObservableCollection<Exercise>(
                    Exercises.Where(exercise => exercise.MusclePart == musclePart).ToList());
            }
        }
    }
}
