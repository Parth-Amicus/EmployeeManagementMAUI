using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class InspectionDetailPage : ContentPage
{
    public InspectionDetailPage()
    {
        InitializeComponent();
        BindingContext = new InspectionDetailViewModel();
    }
}
