namespace EmployeeManagementMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for pages that are pushed modally / on the nav stack.
            // These pages do not appear in the Shell flyout / tab bar; they are only
            // reachable via Shell.Current.GoToAsync() from DashboardPage.
            Routing.RegisterRoute("inspections",
                typeof(Views.InspectionListPage));

            Routing.RegisterRoute("profile",
                typeof(Views.InspectorProfilePage));
        }
    }
}
