
using System.Collections.ObjectModel;

using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;
using EmployeeManagementMAUI.ViewModels.Commands;


namespace EmployeeManagementMAUI.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    private AsyncRelayCommand? _loadInspectionsCommand;
    private bool _hasSearchResults;

    public bool HasSearchResults
    {
        get => _hasSearchResults;
        set
        {
            if (SetProperty(ref _hasSearchResults, value))
                OnPropertyChanged(nameof(ShowEmptyState));
        }
    }

    // Empty state appears only when loading is complete
    // and no matching inspections are available
    public bool ShowEmptyState => !IsBusy && !HasSearchResults;

    private string _searchText = string.Empty;

    // Holds inspections matching the search text
    public ObservableCollection<Inspection> FilteredInspections { get; set; }

    // Stores the text entered by the user
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                ApplySearchFilter();
            }
        }
    }

    // Holds all inspection records
    public ObservableCollection<Inspection> Inspections { get; set; }

    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                OnPropertyChanged(nameof(ShowEmptyState));
                _loadInspectionsCommand?.NotifyCanExecuteChanged();
            }
        }
    }

    public AsyncRelayCommand LoadInspectionsCommand =>
        _loadInspectionsCommand ??= new AsyncRelayCommand(LoadInspectionAsync, () => !IsBusy);


    public InspectionListViewModel()
    {
        // list which will notify the ui when items are added
        Inspections = new ObservableCollection<Inspection>(); // firstly initialize the empty list because we want to add item after delay

        FilteredInspections = new ObservableCollection<Inspection>();

        // Start the first load through the command pipeline so re-entry protection is used consistently.
        LoadInspectionsCommand.Execute(null);

    }

    public async Task LoadInspectionAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            await Task.Delay(2000);
            Inspections.Clear();
            foreach(var inspection in InspectionService.GetInspections())
            {
                Inspections.Add
                    (inspection);
            }
            ApplySearchFilter();
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void ApplySearchFilter()
    {
        // Clear the previous search results
        FilteredInspections.Clear();

        // Find inspections matching the search text
        var filteredItems = Inspections.Where(inspection =>
            string.IsNullOrWhiteSpace(SearchText) ||
            inspection.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            inspection.SiteName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            inspection.InspectorName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
        );

        // Add matching inspections to the collection displayed by the UI
        foreach (var inspection in filteredItems)
        {
            FilteredInspections.Add(inspection);
        }
        // Check whether the search returned any results
        HasSearchResults = FilteredInspections.Count > 0;
    }
}
