
using System.Collections.ObjectModel;

using EmployeeManagementMAUI.Models;


namespace EmployeeManagementMAUI.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    // Holds all inspection records displayed in both list pages
    public ObservableCollection<Inspection> Inspections { get; set; }
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value); // base view model provides this 
    }
    public InspectionListViewModel()
    {
        // list which will notify the ui when items are added
        Inspections = new ObservableCollection<Inspection>(); // firstly initialize the empty list because we want to add item after delay
        //loading the inspection
        _ =LoadInspectionAsync(); // because returning a task
    }

    public async Task LoadInspectionAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            await Task.Delay(2000);
            foreach(var inspection in GetSampleInspection ())
            {
                Inspections.Add
                    (inspection);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    private List<Inspection> GetSampleInspection()
    {
        return new List<Inspection>
        {
            new Inspection
            {
                Id = 1,
                Title = "Safety Equipment Check",
                SiteName = "Building A",
                Status = "Pending",
                Priority = "High",
                ScheduledOn = DateTime.Today.AddHours(10).AddMinutes(30),
                InspectorName = "Arjun",
                Notes = "Check Safety"
            },

            new Inspection
            {
                Id = 2,
                Title = "Fire Extinguisher Inspection",
                SiteName = "Building B",
                Status = "In Progress",
                Priority = "Low",
                ScheduledOn= DateTime.Today.AddHours(12),
                InspectorName = "Arjeet",
                Notes = "Check fire extinguishers and add new eqipments"
            },

            new Inspection
            {
                Id = 3,
                Title = "Electrical Safety Inspection",
                SiteName  = "Building C",
                Status = "Completed",
                Priority = "Medium",
                ScheduledOn = DateTime.Today.AddHours(14),
                InspectorName = "Boby",


            },

            new Inspection
            {
                Id = 4,
                Title = "Emergency Exit Inspection",
                SiteName = "Building D",
                Status = "Pending",
                Priority = "High",
                ScheduledOn = DateTime.Today.AddDays(1).AddHours(9),
                InspectorName = "Chetan",
                Notes = "Add proper sign boards"
            },

            new Inspection
            {
                Id = 5,
                Title = "Fire Alarm System Check",
                SiteName = "Building E",
                Status = "In Progress",
                Priority = "Low",
                ScheduledOn = DateTime.Today.AddDays(1).AddHours(11),
                InspectorName = "Parth",
                Notes = "check alarms",

            },

            new Inspection
            {
                Id = 6,
                Title = "Electrical Panel Inspection",
                SiteName = "Building F",
                Status = "Completed",
                ScheduledOn = DateTime.Today.AddDays(1).AddHours(15),
                Notes = "",
                Priority = "Medium",
                InspectorName = "Rahul"

            },

            new Inspection
            {
                Id = 7,
                Title = "Workplace Safety Audit",
                SiteName = "Building G",
                Status = "Pending",
                Priority = "Low",
                InspectorName = "Amit",
                Notes = "Check safety",
                ScheduledOn = DateTime.Today.AddDays(2).AddHours(10)
            },

            new Inspection
            {
                Id = 8,
                Title = "Equipment Maintenance Check",
                SiteName = "Building H",
                Status = "In Progress",
                Priority = "High",
                ScheduledOn = DateTime.Today.AddDays(2).AddHours(13),
                InspectorName = "Dev",
                Notes = "Check gears"
            },

            new Inspection
            {   Id = 9,
                Title = "Emergency Lighting Check",
                SiteName = "Building I",
                Status = "Completed",
                Priority = "Low",
                InspectorName = "Harsh",
                Notes = "check connections",
                ScheduledOn = DateTime.Today.AddDays(3).AddHours(9)
            },

            new Inspection
            {
                Id = 10,
                Title = "Building Security Inspection",
                SiteName = "Building J",
                Status = "Pending",
                InspectorName = "Keshav",
                Notes = "Check lifts",
                Priority = "High",
                ScheduledOn = DateTime.Today.AddDays(3).AddHours(14)
            }
        };
    }
}
