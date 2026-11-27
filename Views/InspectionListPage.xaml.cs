
using EmployeeManagementMAUI.ViewModels;
using EmployeeManagementMAUI.Models;

namespace EmployeeManagementMAUI.Views;

public partial class InspectionListPage : ContentPage
{
    private readonly InspectionListViewModel _viewModel;

    public InspectionListPage()
    {
        InitializeComponent();

        // Connect the ViewModel to the page
        _viewModel = new InspectionListViewModel();
        BindingContext = _viewModel;

        // Initially display all inspections
      //  InspectionCollection.ItemsSource = _viewModel.Inspections;

        // Select All as the default status filter
      //  StatusPicker.SelectedIndex = 0;
    }


    private void OnInspectionSelectionChanged(object? sender, SelectionChangedEventArgs e) // sender is the object that raised the event (collection view) and e contains info about the selection change
    {
      if (sender is CollectionView collectionView && e.CurrentSelection.Count > 0)
      {
        if (e.CurrentSelection[0] is Inspection inspection)
        {
          _ = NavigateToDetailAsync(inspection.Id);
        }

        collectionView.SelectedItem = null; //clears the selected item
      }
    }

    private static async Task NavigateToDetailAsync(int inspectionId)
    {
      await Shell.Current.GoToAsync($"InspectionDetailPage?inspectionId={inspectionId}");
    }
}
