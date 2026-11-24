using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class NewInspectionPage : ContentPage
{
    private readonly NewInspectionViewModel _viewModel;

    public NewInspectionPage()
    {
        InitializeComponent();

        _viewModel = new NewInspectionViewModel();
        _viewModel.Saved += OnSaved;
        BindingContext = _viewModel;
    }

    private async void OnSaved(object? sender, Models.Inspection inspection)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        if (_viewModel.HasChanges)
        {
            var discard = await DisplayAlertAsync(
                "Discard changes?",
                "You have unsaved changes. Discard them?",
                "Discard",
                "Keep editing");

            if (!discard)
            {
                return;
            }
        }

        await Navigation.PopModalAsync();
    }
}
