
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;

namespace EmployeeManagementMAUI.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    // Hardcoded summary counts for the dashboard
    public int TotalInspections { get; set; } = 24;
    public int PendingInspections { get; set; } = 8;
    public int InProgressInspections { get; set; } = 6;
    public int CompletedInspections { get; set; } = 10;

    //  ObservableCollection is a collection that notifies the UI when items are added or removed
    public ObservableCollection<Inspection> TodaysInspections { get; set; }

    public DashboardViewModel()
    {
        TodaysInspections = new ObservableCollection<Inspection>
        {
            InspectionService.GetById(1)!,
            InspectionService.GetById(2)!,
            InspectionService.GetById(3)!
        };
    }
}
