
using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class InspectionListListViewPage : ContentPage
{
    public InspectionListListViewPage()
    {
        InitializeComponent();

        // Reuse the same Inspection List ViewModel
        BindingContext = new InspectionListViewModel();
    }
}
