namespace EmployeeManagementMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent(); // load the ui strucutre defined inside appshell.xaml

            Routing.RegisterRoute( //registered as route so you can navigate to it 
                nameof(Views.InspectionDetailPage), // returns a string "InspectionDetailPage"
                typeof(Views.InspectionDetailPage)); // provides the actual page type
        }
    }
}
