
using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class InspectorProfilePage : ContentPage
{
    public InspectorProfilePage()
    {
        InitializeComponent();

        // Connect the ViewModel to the View.
        BindingContext = new InspectorProfileViewModel();
    }
}
