
using System.Collections.ObjectModel;
using EmployeeManagementMAUI.Models;

namespace EmployeeManagementMAUI.ViewModels;

public class InspectionListViewModel
{
    // Holds all inspection records displayed in both list pages
    public ObservableCollection<InspectionItem> Inspections { get; set; }

    public InspectionListViewModel()
    {
        //observable colletion - list which notify the ui when items are added or removed
        Inspections = new ObservableCollection<InspectionItem>
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
                Title = "Electrical Safety Inspection",
                Site = "Building C",
                Status = "Completed",
                ScheduledDate = DateTime.Today.AddHours(14)
            },

            new InspectionItem
            {
                Title = "Emergency Exit Inspection",
                Site = "Building D",
                Status = "Pending",
                ScheduledDate = DateTime.Today.AddDays(1).AddHours(9)
            },

            new InspectionItem
            {
                Title = "Fire Alarm System Check",
                Site = "Building E",
                Status = "In Progress",
                ScheduledDate = DateTime.Today.AddDays(1).AddHours(11)
            },

            new InspectionItem
            {
                Title = "Electrical Panel Inspection",
                Site = "Building F",
                Status = "Completed",
                ScheduledDate = DateTime.Today.AddDays(1).AddHours(15)
            },

            new InspectionItem
            {
                Title = "Workplace Safety Audit",
                Site = "Building G",
                Status = "Pending",
                ScheduledDate = DateTime.Today.AddDays(2).AddHours(10)
            },

            new InspectionItem
            {
                Title = "Equipment Maintenance Check",
                Site = "Building H",
                Status = "In Progress",
                ScheduledDate = DateTime.Today.AddDays(2).AddHours(13)
            },

            new InspectionItem
            {
                Title = "Emergency Lighting Check",
                Site = "Building I",
                Status = "Completed",
                ScheduledDate = DateTime.Today.AddDays(3).AddHours(9)
            },

            new InspectionItem
            {
                Title = "Building Security Inspection",
                Site = "Building J",
                Status = "Pending",
                ScheduledDate = DateTime.Today.AddDays(3).AddHours(14)
            }
        };
    }
}
