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
}
