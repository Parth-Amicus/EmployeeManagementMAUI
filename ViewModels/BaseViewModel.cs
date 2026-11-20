
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeManagementMAUI.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    // Event raised whenever a property value changes
    public event PropertyChangedEventHandler? PropertyChanged;

    // Notifies the UI that a particular property has changed
    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }

    // Updates a property and notifies the UI only when its value changes
    protected bool SetProperty<T>( //SetProperty to avoid using multiple get set
        ref T backingStore,
        T value,
        [CallerMemberName] string? propertyName = null)
    {
        // Avoid unnecessary notifications if the value is unchanged
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;

        OnPropertyChanged(propertyName);

        return true;
    }
}
