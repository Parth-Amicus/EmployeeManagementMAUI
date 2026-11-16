
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;

namespace EmployeeManagementMAUI.ViewModels;

public class DashboardViewModel
{
    // Hardcoded summary counts for the dashboard
    public int TotalInspections { get; set; } = 24;
    public int PendingInspections { get; set; } = 8;
    public int InProgressInspections { get; set; } = 6;
    public int CompletedInspections { get; set; } = 10;

    //  ObservableCollection is a collection that notifies the UI when items are added or removed
    public ObservableCollection<InspectionItem> TodaysInspections { get; set; }

    public DashboardViewModel()
    {
        TodaysInspections = new ObservableCollection<InspectionItem>
        {
            new InspectionItem
            {
                Title = "Safety Equipment Check",
                Site = "Building A",
                Status = "Pending",
                ScheduledDate = DateTime.Today.AddHours(10).AddMinutes(30)
            },

            new InspectionItem
            {
                Title = "Fire Extinguisher Inspection",
                Site = "Building B",
                Status = "In Progress",
                ScheduledDate = DateTime.Today.AddHours(12)
            },

            new InspectionItem
            {
                Title = "Electrical Inspection",
                Site = "Building C",
                Status = "Completed",
                ScheduledDate = DateTime.Today.AddHours(14).AddMinutes(30)
            }
        };
    }
}
