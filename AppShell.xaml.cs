namespace EmployeeManagementMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                nameof(Views.InspectionDetailPage),
                typeof(Views.InspectionDetailPage));
        }
    }
}
