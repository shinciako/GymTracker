namespace GymTracker.View;

public partial class HistoryPage : ContentPage
{
    private HistoryPageViewModel viewModel;

    public HistoryPage()
    {
        InitializeComponent();
        viewModel = new HistoryPageViewModel();
        BindingContext = viewModel;
    }

    public void DeleteSession(System.Object sender, System.EventArgs e)
    {
        var session = (Model.Session)((Button)sender).CommandParameter;

        if (BindingContext is ViewModel.HistoryPageViewModel viewModel)
        {
            viewModel.DeleteSession(session);
            viewModel.sessions.Remove(session);
        }
    }
}
