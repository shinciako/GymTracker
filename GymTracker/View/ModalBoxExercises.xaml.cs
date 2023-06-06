using CommunityToolkit.Maui.Views;
using GymTracker.ViewModel;
using Microsoft.Maui.Controls;


namespace GymTracker.View;

public partial class ModalBoxExercises : Popup
{
    Exercise selectedItem;
    RegisterWorkoutViewModel registerWorkoutViewModel;

    public ModalBoxExercises(RegisterWorkoutViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = new ModalBoxExercisesViewModel();
        registerWorkoutViewModel = viewModel;
    }

    private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedItem = e.CurrentSelection.FirstOrDefault() as Exercise;
        if (selectedItem != null)
        {
            ((ModalBoxExercisesViewModel)BindingContext).SelectedExercise = selectedItem;
            selectedExerciseLabel.Text = selectedItem.Name;
        }
    }


    private void AddExercise(object sender, EventArgs e)
    {
        if (selectedItem != null)
        {
            registerWorkoutViewModel.AddExercise(selectedItem);
        }
        Close();
    }

}
