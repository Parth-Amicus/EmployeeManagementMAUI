using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Runtime.InteropServices;
// application initialization and lifecycle 
namespace EmployeeManagementMAUI
{
    public partial class App : Application // App class inherited from the MAUI Application Class
    {
        public App()
        {
            InitializeComponent(); // loads the xaml resources associated with app.xaml
        }

        protected override Window CreateWindow(IActivationState? activationState) // creates app window 
        {
            var window = new Window(new AppShell()); //a window whose content is our navigation shell 

            window.Created += (sender, args) => //+= subscribe to event
            {
                Debug.WriteLine("[Lifecycle] Window Created");
            };

            window.Activated += (sender, args) =>
            {
                Debug.WriteLine("[Lifecycle] Window Activated");
            };

            window.Deactivated += (sender, args) =>
            {
                Debug.WriteLine("[Lifecycle] Window Deactivated");
            };
            window.Stopped += (sender, args) =>
            {
                Debug.WriteLine("[Lifecycle] Window Stopped");
            };
            window.Resumed += (sender, args) =>
            {
                Debug.WriteLine("[Lifecycle] Window Resumed");
            };
            window.Destroying += (sender, args) =>
            {
                Debug.WriteLine("[Lifecycle] Window Destroying");
            };
            return window;


        }
    }
}

