using System.Windows.Input;
using System.Diagnostics;

namespace EmployeeManagementMAUI.ViewModels.Commands;

public sealed class AsyncRelayCommand : ICommand // sealed means other class can not inherit from this 
{
    private readonly Func<Task> _executeAsync; // stores reference 
    private readonly Func<bool>? _canExecute;
    private readonly Action<Exception>? _onException; 
    private bool _isExecuting; // to track currently running command

    public event EventHandler? CanExecuteChanged;// event // informs ui about availability

    public AsyncRelayCommand(
        Func<Task> executeAsync,
        Func<bool>? canExecute = null,
        Action<Exception>? onException = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
        _onException = onException;
    }

    public bool IsExecuting => _isExecuting; // used internally for command execution control

    public bool CanExecute(object? parameter)
        => !_isExecuting && (_canExecute?.Invoke() ?? true); // also checks optional canExecute if not provided it is true

    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        _isExecuting = true;
        NotifyCanExecuteChanged();// ui is notified that command is available 

        try
        {
            await _executeAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[AsyncRelayCommand] Unhandled command exception: {ex}");
            _onException?.Invoke(ex);
        }
        finally
        {
            _isExecuting = false;
            NotifyCanExecuteChanged();
        }
    }

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty); // calls the event
}
