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

}


