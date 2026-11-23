
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

    // ── Navigation handlers ──────────────────────────────────────────────────

    /// <summary>
    /// Pushes InspectorProfilePage onto the Shell navigation stack.
    /// Triggered by tapping the circular profile icon in the header row.
    /// Shell shows a back-arrow automatically; no extra plumbing needed.
    /// </summary>
    private async void OnProfileIconTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }

    /// <summary>
    /// Pushes InspectionListPage onto the Shell navigation stack.
    /// Triggered by tapping the "View All" button next to the section heading.
    /// </summary>
    private async void OnViewAllTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("inspections");
    }

    private async void OnTodayInspectionTapped(object? sender, TappedEventArgs e)
    {
        // This behavior is event-based (instead of command-based) because it needs
        // direct access to the tapped view instance for a transient UI animation.
        if (sender is not VisualElement card)
        {
            return;
        }

        await card.ScaleTo(0.98, 70);
        await card.ScaleTo(1.0, 90);
    }
}
