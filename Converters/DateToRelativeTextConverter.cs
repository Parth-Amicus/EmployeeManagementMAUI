using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EmployeeManagementMAUI.Converters
{
    internal class DateToRelativeTextConverter : IValueConverter
    {
        public object Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            if (value is not DateTime date)
                return string.Empty;
            DateTime today = DateTime.Today;
            int daysDifference = (today - date.Date).Days;

            if (daysDifference == 0)
                return "Today";
            if (daysDifference == 1)
                return "Yesterday";
            if (daysDifference > 1)
                return $"{daysDifference} days ago";
            if (daysDifference == -1)
                return "Tomorrow";
            return $"In {Math.Abs(daysDifference)} days";
                
        }
        public object ConvertBack(
            object?value,
            Type targetType,
            object? parameter,
            CultureInfo culture
            )
        {
            throw new NotImplementedException();
        }
    }
}
