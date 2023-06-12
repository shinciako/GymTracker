using System;
using GymTracker.ViewModel;

namespace GymTracker.View
{
    public partial class ExercisesPage : ContentPage
    {
        public ExercisesPage()
        {
            InitializeComponent();
            BindingContext = new ExercisePageViewModel();
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var viewModel = (ExercisePageViewModel)BindingContext;
            var selectedMusclePart = (string)((Picker)sender).SelectedItem;
            viewModel.ApplyFilter(selectedMusclePart);
        }
    }
}
