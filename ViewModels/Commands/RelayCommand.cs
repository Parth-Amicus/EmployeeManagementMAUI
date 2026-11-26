using System.Windows.Input;

namespace EmployeeManagementMAUI.ViewModels.Commands;

public sealed class RelayCommand : ICommand
{
    private readonly Action _execute; // Action is a c# delegate unlike func it newvwe return a value, used for void 
    private readonly Func<bool>? _canExecute;

    public event EventHandler? CanExecuteChanged; // tells the availability of command

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true; // Invoke raises the event only if somethinf is subscribed to it

    public void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        _execute();
    }

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
