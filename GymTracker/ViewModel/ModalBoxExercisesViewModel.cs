using Microsoft.Maui.Controls;
using System;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace GymTracker.ViewModel;

public class ModalBoxExercisesViewModel : BaseViewModel
{
    private ObservableCollection<Exercise> exercises;
    public ObservableCollection<Exercise> Exercises
    {
        get { return exercises; }
        set { SetProperty(ref exercises, value); }
    }

    private Exercise selectedExercise;
    public Exercise SelectedExercise
    {
        get { return selectedExercise; }
        set
        {
            if (selectedExercise != value)
            {
                selectedExercise = value;
                OnPropertyChanged("SelectedExercise");
            }
        }
    }

    public ModalBoxExercisesViewModel()
    {
        Exercises = new ObservableCollection<Exercise>()
        {
            new Exercise("Bench press", "Chest"),
            new Exercise("Squat front", "Lower body"),
            new Exercise("Squat back", "Lower body"),
            new Exercise("Plank", "Abdominal"),
            new Exercise("Squat front", "Lower body"),
            new Exercise("Squat back", "Lower body"),
        };  
    }
}

