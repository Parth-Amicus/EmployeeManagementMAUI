using System.Globalization;

namespace EmployeeManagementMAUI.Converters;

/// <summary>
/// Maps an inspection status string to the matching pill background colour.
/// Used by StatusBadge to colour the badge without code-behind logic.
/// </summary>
public class StatusToBackgroundConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value as string) switch
        {
            "Pending"     => Color.FromArgb("#FEF3C7"),  // amber-100
            "In Progress" => Color.FromArgb("#EDE9FE"),  // violet-100
            "Completed"   => Color.FromArgb("#DCFCE7"),  // green-100
            _             => Color.FromArgb("#F1F5F9")   // slate-100 fallback
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
