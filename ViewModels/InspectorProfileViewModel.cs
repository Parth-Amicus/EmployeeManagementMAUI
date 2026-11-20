
using System.Diagnostics;
using System.Windows.Input;
using EmployeeManagementMAUI.Models;

namespace EmployeeManagementMAUI.ViewModels;

public class InspectorProfileViewModel : BaseViewModel
{
    // Holds the inspector information displayed on the page
    public Inspector Inspector { get; set; }

    // Command executed when the Edit button is clicked
    // ICommand represnts an action that can be executed from the ui
    public ICommand EditCommand { get; }

    public InspectorProfileViewModel()
    {
        // Sample inspector information
        Inspector = new Inspector
        {
            Name = "Parth Singh",
            EmployeeId = "EM 30330305",
            Role = "Associate Analyst",
            Email = "parth@amicus.com",
            Phone = "+900 000 0000",
            Photo = "inspector_profile.jpg"
        };

        // Connect the Edit button to its command
        EditCommand = new Command(OnEdit);
    }

    private void OnEdit()
    {
        Debug.WriteLine("Edit Profile button clicked");
    }
}
