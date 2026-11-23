
using EmployeeManagementMAUI.ViewModels;

namespace EmployeeManagementMAUI.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        BindingContext = new LoginViewModel();
    }
}
