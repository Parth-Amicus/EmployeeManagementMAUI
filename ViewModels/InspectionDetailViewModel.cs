using EmployeeManagementMAUI.Models;
using EmployeeManagementMAUI.Services;

namespace EmployeeManagementMAUI.ViewModels;

[QueryProperty(nameof(InspectionId), "inspectionId")]
public class InspectionDetailViewModel : BaseViewModel
{
    private string _inspectionId = string.Empty;
    private Inspection? _inspection;

    public string InspectionId
    {
        get => _inspectionId;
        set
        {
            if (SetProperty(ref _inspectionId, value) &&
                int.TryParse(value, out var id))
            {
                Inspection = InspectionService.GetById(id);
            }
        }
    }

    public Inspection? Inspection
    {
        get => _inspection;
        set
        {
            SetProperty(ref _inspection, value);
            OnPropertyChanged(nameof(IsInspectionFound));
        }
    }

    public bool IsInspectionFound => Inspection is not null;
}
