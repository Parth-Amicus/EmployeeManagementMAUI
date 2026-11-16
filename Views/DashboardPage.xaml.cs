
using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        // Connect the Dashboard ViewModel to the page
        BindingContext = new DashboardViewModel();
    }
}
