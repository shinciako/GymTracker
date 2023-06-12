namespace GymTracker;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    void History_Clicked(System.Object sender, System.EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
    }

    void Exercise_Clicked(System.Object sender, System.EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new ExercisesPage());
    }

    private async void Frame_Tapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var template = (Template)frame.BindingContext;
        var registerWorkoutPage = new RegisterWorkoutPage(new RegisterWorkoutViewModel(template.Exercises));
        await Shell.Current.Navigation.PushAsync(registerWorkoutPage);
    }
}


