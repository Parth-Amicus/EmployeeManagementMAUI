
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;

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
}
