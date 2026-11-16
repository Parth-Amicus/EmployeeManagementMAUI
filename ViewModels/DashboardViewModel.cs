
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
                Location = "Building A",
                Time = "10:30 AM",
                Priority = "High"
            },

            new InspectionItem
            {
                Title = "Fire Extinguisher Inspection",
                Location = "Building B",
                Time = "12:00 PM",
                Priority = "Medium"
            },

            new InspectionItem
            {
                Title = "Electrical Inspection",
                Location = "Building C",
                Time = "02:30 PM",
                Priority = "Low"
            }
        };
    }
}
