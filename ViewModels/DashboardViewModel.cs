
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.ViewModels.Commands;

namespace EmployeeManagementMAUI.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    private AsyncRelayCommand? _refreshTodaysInspectionsCommand;
    private bool _isRefreshing;

    // Hardcoded summary counts for the dashboard
    public int TotalInspections { get; set; } = 24;
    public int PendingInspections { get; set; } = 8;
    public int InProgressInspections { get; set; } = 6;
    public int CompletedInspections { get; set; } = 10;

    //  ObservableCollection is a collection that notifies the UI when items are added or removed
    public ObservableCollection<Inspection> TodaysInspections { get; set; }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    public AsyncRelayCommand RefreshTodaysInspectionsCommand =>
        _refreshTodaysInspectionsCommand ??= new AsyncRelayCommand(RefreshTodaysInspectionsAsync);

    public DashboardViewModel()
    {
        TodaysInspections = new ObservableCollection<Inspection>
        {
            new Inspection
            {
                Title = "Safety Equipment Check",
                SiteName = "Building A",
                Status = "Pending",
                ScheduledOn = DateTime.Today.AddHours(10).AddMinutes(30)
            },

            new Inspection
            {
                Title = "Fire Extinguisher Inspection",
                SiteName = "Building B",
                Status = "In Progress",
                ScheduledOn = DateTime.Today.AddHours(12)
            },

            new Inspection
            {
                Title = "Electrical Inspection",
                SiteName = "Building C",
                Status = "Completed",
                ScheduledOn = DateTime.Today.AddHours(14).AddMinutes(30)
            }
        };
    }

    private async Task RefreshTodaysInspectionsAsync()
    {
        IsRefreshing = true;

        try
        {
            await Task.Delay(1000);

            // Rebuild the same sample list to simulate a fresh data fetch.
            var refreshedItems = new List<Inspection>
            {
                new Inspection
                {
                    Title = "Safety Equipment Check",
                    SiteName = "Building A",
                    Status = "Pending",
                    ScheduledOn = DateTime.Today.AddHours(10).AddMinutes(30)
                },
                new Inspection
                {
                    Title = "Fire Extinguisher Inspection",
                    SiteName = "Building B",
                    Status = "In Progress",
                    ScheduledOn = DateTime.Today.AddHours(12)
                },
                new Inspection
                {
                    Title = "Electrical Inspection",
                    SiteName = "Building C",
                    Status = "Completed",
                    ScheduledOn = DateTime.Today.AddHours(14).AddMinutes(30)
                }
            };

            TodaysInspections.Clear();

            foreach (var inspection in refreshedItems)
            {
                TodaysInspections.Add(inspection);
            }
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}
