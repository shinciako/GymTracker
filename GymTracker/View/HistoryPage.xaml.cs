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

    public void DeleteSession(Object sender, EventArgs e)
    {
        var session = (Session)((Button)sender).CommandParameter;

        if (BindingContext is HistoryPageViewModel viewModel)
        {
            viewModel.DeleteSession(session);
            viewModel.sessions.Remove(session);
        }
    }   
}
