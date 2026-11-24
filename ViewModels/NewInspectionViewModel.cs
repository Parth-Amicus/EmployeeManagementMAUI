using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;
using EmployeeManagementMAUI.ViewModels.Commands;

namespace EmployeeManagementMAUI.ViewModels;

public class NewInspectionViewModel : BaseViewModel
{
    private string _title = string.Empty;
    private string _siteName = string.Empty;
    private string _inspectorName = string.Empty;
    private string _status = "Pending";
    private string _priority = "Medium";
    private DateTime _scheduledOn = DateTime.Today.AddHours(9);
    private string _notes = string.Empty;
    private string _validationMessage = string.Empty;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string SiteName
    {
        get => _siteName;
        set => SetProperty(ref _siteName, value);
    }

    public string InspectorName
    {
        get => _inspectorName;
        set => SetProperty(ref _inspectorName, value);
    }

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public string Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    public DateTime ScheduledOn
    {
        get => _scheduledOn;
        set => SetProperty(ref _scheduledOn, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public string ValidationMessage
    {
        get => _validationMessage;
        set => SetProperty(ref _validationMessage, value);
    }

    public bool HasChanges =>
        !string.IsNullOrWhiteSpace(Title) ||
        !string.IsNullOrWhiteSpace(SiteName) ||
        !string.IsNullOrWhiteSpace(InspectorName) ||
        !string.IsNullOrWhiteSpace(Notes);

    public AsyncRelayCommand SaveCommand { get; }
    public event EventHandler<Inspection>? Saved;

    public NewInspectionViewModel()
    {
        SaveCommand = new AsyncRelayCommand(SaveAsync);
    }

    private Task SaveAsync()
    {
        ValidationMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Title))
        {
            ValidationMessage = "Title is required.";
            return Task.CompletedTask;
        }

        if (string.IsNullOrWhiteSpace(SiteName))
        {
            ValidationMessage = "Site name is required.";
            return Task.CompletedTask;
        }

        var inspection = InspectionService.Add(new Inspection
        {
            Title = Title.Trim(),
            SiteName = SiteName.Trim(),
            InspectorName = InspectorName.Trim(),
            Status = Status,
            Priority = Priority,
            ScheduledOn = ScheduledOn,
            Notes = Notes.Trim()
        });

        Saved?.Invoke(this, inspection);
        return Task.CompletedTask;
    }
}
