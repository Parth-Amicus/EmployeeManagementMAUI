
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;
using EmployeeManagementMAUI.ViewModels.Commands;

namespace EmployeeManagementMAUI.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    // Hardcoded summary counts for the dashboard
    public int TotalInspections { get; set; } = 24;
    public int PendingInspections { get; set; } = 8;
    public int InProgressInspections { get; set; } = 6;
    public int CompletedInspections { get; set; } = 10;

    //  ObservableCollection is a collection that notifies the UI when items are added or removed
    public ObservableCollection<Inspection> TodaysInspections { get; set; } = new ObservableCollection<Inspection>();

    public AsyncRelayCommand OpenNewInspectionCommand { get; }

    public DashboardViewModel()
    {
        OpenNewInspectionCommand = new AsyncRelayCommand(OpenNewInspectionAsync);
        RefreshInspections();
    }

    public void RefreshInspections()
    {
        TodaysInspections = new ObservableCollection<Inspection>
            (InspectionService.GetInspections().Where(inspection => inspection.ScheduledOn.Date == DateTime.Today).Take(3));
        OnPropertyChanged(nameof(TodaysInspections));
    }

    private async Task OpenNewInspectionAsync()
    {
        if (Shell.Current is not null)
        {
            await Shell.Current.Navigation.PushModalAsync(new Views.NewInspectionPage());
        }

        RefreshInspections();
    }
}
