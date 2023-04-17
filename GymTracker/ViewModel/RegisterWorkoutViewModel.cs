using System.Windows.Input;
using CommunityToolkit.Maui.Views;

namespace GymTracker.ViewModel;

public partial class RegisterWorkoutViewModel : BaseViewModel
{
    public ObservableCollection<Exercise> Exercises { get; } = new ObservableCollection<Exercise>()
    {
        new Exercise("Bench press", "Chest"),
        new Exercise("Squat front", "Lower body"),
        new Exercise("Squat back", "Lower body"),
    };

    public RegisterWorkoutViewModel()
	{
	}

    public ICommand DisplayPopupCommand => new Command(DisplayPopup);

    public void DisplayPopup()
    {
        var popup = new ModalBoxExercises();
        Shell.Current.CurrentPage.ShowPopup(popup);
    }
}

