
using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class InspectionListPage : ContentPage
{
    public InspectionListPage()
    {
        InitializeComponent();

        // Connect the shared Inspection List ViewModel.
        BindingContext = new InspectionListViewModel();
    }

}
