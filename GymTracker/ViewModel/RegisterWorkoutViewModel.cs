﻿using System.Windows.Input;
using CommunityToolkit.Maui.Views;

namespace GymTracker.ViewModel;

public class RegisterWorkoutViewModel : BaseViewModel
{
    public ObservableCollection<Training> Trainings { get; set; }

    public RegisterWorkoutViewModel()
    {
        Trainings = new();
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
            Sets = 0,
            Repetitions = new List<int> { 0 },
            Kilograms = new List<float> { 0 },
            Exercise = exercise
        };
        Trainings.Add(training);
    }
}
