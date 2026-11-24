using EmployeeManagementMAUI.Models;

namespace EmployeeManagementMAUI.Services;

public static class InspectionService
{
    private static readonly List<Inspection> Inspections =
    [
        new() { Id = 1, Title = "Safety Equipment Check", SiteName = "Building A", Status = "Pending", Priority = "High", ScheduledOn = DateTime.Today.AddHours(10).AddMinutes(30), InspectorName = "Arjun", Notes = "Check Safety" },
        new() { Id = 2, Title = "Fire Extinguisher Inspection", SiteName = "Building B", Status = "In Progress", Priority = "Low", ScheduledOn = DateTime.Today.AddHours(12), InspectorName = "Arjeet", Notes = "Check fire extinguishers and add new equipment" },
        new() { Id = 3, Title = "Electrical Safety Inspection", SiteName = "Building C", Status = "Completed", Priority = "Medium", ScheduledOn = DateTime.Today.AddHours(14), InspectorName = "Boby", Notes = "Verify breakers and panel labels" },
        new() { Id = 4, Title = "Emergency Exit Inspection", SiteName = "Building D", Status = "Pending", Priority = "High", ScheduledOn = DateTime.Today.AddDays(1).AddHours(9), InspectorName = "Chetan", Notes = "Add proper sign boards" },
        new() { Id = 5, Title = "Fire Alarm System Check", SiteName = "Building E", Status = "In Progress", Priority = "Low", ScheduledOn = DateTime.Today.AddDays(1).AddHours(11), InspectorName = "Parth", Notes = "Check alarms" },
        new() { Id = 6, Title = "Electrical Panel Inspection", SiteName = "Building F", Status = "Completed", ScheduledOn = DateTime.Today.AddDays(1).AddHours(15), Notes = "Panel is in good condition", Priority = "Medium", InspectorName = "Rahul" },
        new() { Id = 7, Title = "Workplace Safety Audit", SiteName = "Building G", Status = "Pending", Priority = "Low", InspectorName = "Amit", Notes = "Check safety", ScheduledOn = DateTime.Today.AddDays(2).AddHours(10) },
        new() { Id = 8, Title = "Equipment Maintenance Check", SiteName = "Building H", Status = "In Progress", Priority = "High", ScheduledOn = DateTime.Today.AddDays(2).AddHours(13), InspectorName = "Dev", Notes = "Check gears" },
        new() { Id = 9, Title = "Emergency Lighting Check", SiteName = "Building I", Status = "Completed", Priority = "Low", InspectorName = "Harsh", Notes = "Check connections", ScheduledOn = DateTime.Today.AddDays(3).AddHours(9) },
        new() { Id = 10, Title = "Building Security Inspection", SiteName = "Building J", Status = "Pending", InspectorName = "Keshav", Notes = "Check lifts", Priority = "High", ScheduledOn = DateTime.Today.AddDays(3).AddHours(14) }
    ];

    public static IReadOnlyList<Inspection> GetInspections() => Inspections;

    public static Inspection? GetById(int id) =>
        Inspections.FirstOrDefault(inspection => inspection.Id == id);

    public static Inspection Add(Inspection inspection)
    {
        inspection.Id = Inspections.Count == 0
            ? 1
            : Inspections.Max(item => item.Id) + 1;

        Inspections.Add(inspection);
        return inspection;
    }
}
