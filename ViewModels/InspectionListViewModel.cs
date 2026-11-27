
using System.Collections.ObjectModel;

using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;
using EmployeeManagementMAUI.ViewModels.Commands;

namespace EmployeeManagementMAUI.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    // holds the command 
    private AsyncRelayCommand? _loadInspectionsCommand; //initial load
    private AsyncRelayCommand? _refreshInspectionsCommand; // for pull to refresh

    // Private fields
    private bool _hasSearchResults;
    private string _searchText = string.Empty;
    private bool _isBusy; // tracks whether an operation is running
    private bool _isLoading; // controls initial loading indicator
    private bool _isRefreshing; // control pull refresh indicator

    // Holds all inspection records
    public ObservableCollection<Inspection> Inspections { get; set; }

    // Holds inspections matching the search text
    public ObservableCollection<Inspection> FilteredInspections { get; set; }

    public ObservableCollection<Inspection> TodaysInspections { get; set; } = new ObservableCollection<Inspection>();
    public AsyncRelayCommand OpenNewInspectionCommand { get; }

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

    public bool HasSearchResults
    {
        get => _hasSearchResults;
        set
        {
            if (SetProperty(ref _hasSearchResults, value)) // set property check whether the value has changed 
                OnPropertyChanged(nameof(ShowEmptyState));
        }
    }
    // Empty state appears only when loading is complete
    // and no matching inspections are available
    public bool ShowEmptyState => !IsBusy && !HasSearchResults;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                OnPropertyChanged(nameof(ShowEmptyState));
                _loadInspectionsCommand?.NotifyCanExecuteChanged();
                _refreshInspectionsCommand?.NotifyCanExecuteChanged();
            }
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    // Commands exposed to the View
    public AsyncRelayCommand LoadInspectionsCommand =>
        _loadInspectionsCommand ??= new AsyncRelayCommand(
            LoadInspectionAsync,
            () => !IsBusy);

    public AsyncRelayCommand RefreshInspectionsCommand =>
        _refreshInspectionsCommand ??= new AsyncRelayCommand(
            RefreshInspectionAsync,
            () => !IsBusy); // allows refreshing only when another command is not running

    public InspectionListViewModel()
    {
        // list which will notify the ui when items are added
        Inspections = new ObservableCollection<Inspection>(); // firstly initialize the empty list because we want to add item after delay

        FilteredInspections = new ObservableCollection<Inspection>();

        // Start the first load through the command pipeline so re-entry protection is used consistently.
        LoadInspectionsCommand.Execute(null);

        OpenNewInspectionCommand = new AsyncRelayCommand(OpenNewInspectionAsync);
        RefreshInspections();


        
    }

    public async Task LoadInspectionAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            IsLoading = true;

            await Task.Delay(2000);

            Inspections.Clear();

            foreach (var inspection in InspectionService.GetInspections())
            {
                Inspections.Add
                    (inspection);
            }

            ApplySearchFilter();
        }
        finally
        {
            IsLoading = false;
            IsBusy = false;
        }
    }

    public async Task RefreshInspectionAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            IsRefreshing = true;

            await Task.Delay(2000);

            Inspections.Clear();

            foreach (var inspection in InspectionService.GetInspections())
            {
                Inspections.Add(inspection);
            }

            ApplySearchFilter();
        }
        finally
        {
            IsRefreshing = false;
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

    private async Task OpenNewInspectionAsync()
    {
        if (Shell.Current is not null)
        {
            await Shell.Current.Navigation.PushModalAsync(new Views.NewInspectionPage());
        }

        RefreshInspections();
    }
    public void RefreshInspections()
    {
        TodaysInspections = new ObservableCollection<Inspection>
            (InspectionService.GetInspections().Where(inspection => inspection.ScheduledOn.Date == DateTime.Today).Take(3));
        OnPropertyChanged(nameof(TodaysInspections));
    }
}
