
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

    // Called whenever the user types in the search Entry
    //private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    //{
    //   // ApplyFilters();
    //}

    //// Called whenever the user selects a different status
    //private void OnStatusChanged(object sender, EventArgs e)
    //{
    //    //ApplyFilters();
    //}

    //// Apply search and status filters to the inspection list
    //private void ApplyFilters()
    //{
    //    string searchText = SearchEntry.Text?.Trim() ?? string.Empty;

    //    string selectedStatus = StatusPicker.SelectedItem?.ToString() ?? "All";

    //    var filteredInspections = _viewModel.Inspections
    //        .Where(inspection =>
    //            (inspection.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
    //             inspection.SiteName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) &&
    //            (selectedStatus == "All" || inspection.Status == selectedStatus))
    //        .ToList();

    //    InspectionCollection.ItemsSource = filteredInspections;
    //}

    private void OnInspectionSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
      if (sender is CollectionView collectionView && e.CurrentSelection.Count > 0)
      {
        if (e.CurrentSelection[0] is Inspection inspection)
        {
          _ = NavigateToDetailAsync(inspection.Id);
        }

        collectionView.SelectedItem = null;
      }
    }

    private static async Task NavigateToDetailAsync(int inspectionId)
    {
      await Shell.Current.GoToAsync($"InspectionDetailPage?inspectionId={inspectionId}");
    }
}
