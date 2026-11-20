using System.Globalization;

namespace EmployeeManagementMAUI.Converters;

/// <summary>
/// Maps an inspection status string to the matching pill text colour.
/// Paired with StatusToBackgroundConverter to produce accessible colour combinations.
/// </summary>
public class StatusToTextColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value as string) switch
        {
            "Pending"     => Color.FromArgb("#B45309"),  // amber-700
            "In Progress" => Color.FromArgb("#6D28D9"),  // violet-700
            "Completed"   => Color.FromArgb("#15803D"),  // green-700
            "High" => Color.FromArgb("#B91C1C"),
            "Medium" => Color.FromArgb("#B45309"),
            "Low" => Color.FromArgb("#15803D"),
            _             => Color.FromArgb("#64748B")   // slate-500 fallback
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
