
using System.Net.Mail;
using System.Diagnostics;

using EmployeeManagementMAUI.ViewModels.Commands;

namespace EmployeeManagementMAUI.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _emailError = string.Empty;
    private string _passwordError = string.Empty;
    private string _loginMessage = string.Empty;

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                ValidateEmail();
                OnPropertyChanged(nameof(IsLoginEnabled)); // whenever email changes we notify the ui to recalculate isLoginEnabled
                LoginCommand.NotifyCanExecuteChanged();
                LoginMessage = string.Empty;
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                ValidatePassword();
                OnPropertyChanged(nameof(IsLoginEnabled));
                LoginCommand.NotifyCanExecuteChanged();
                LoginMessage = string.Empty;
            }
        }
    }

    public string EmailError
    {
        get => _emailError;
        set => SetProperty(ref _emailError, value);
    }

    public string PasswordError
    {
        get => _passwordError;
        set => SetProperty(ref _passwordError, value);
    }

    public string LoginMessage
    {
        get => _loginMessage;
        set => SetProperty(ref _loginMessage, value);
    }

    // Login is enabled only when both fields contain valid values
    public bool IsLoginEnabled =>
        !string.IsNullOrWhiteSpace(Email) &&
        !string.IsNullOrWhiteSpace(Password) &&
        string.IsNullOrEmpty(EmailError) &&
        string.IsNullOrEmpty(PasswordError);

    public AsyncRelayCommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new AsyncRelayCommand(
            LoginAsync,
            () => IsLoginEnabled,
            ex => LoginMessage = $"Login failed: {ex.Message}");
    }

    private void ValidateEmail()
    {
        if (string.IsNullOrWhiteSpace(Email))
            EmailError = "Email is required";
        else if (!MailAddress.TryCreate(Email, out _))
            EmailError = "Please enter a valid email address";
        else
            EmailError = string.Empty;
    }

    private void ValidatePassword()
    {
        if (string.IsNullOrWhiteSpace(Password))
            PasswordError = "Password is required";
        else if (Password.Length < 8)
            PasswordError = "Password must be at least 8 characters";
        else
            PasswordError = string.Empty;
    }

    private async Task LoginAsync()
    {
        if (Email == "admin@abc.com" &&
            Password == "Password123")
        {
            LoginMessage = "Login successful!";
            try
            {
                // Navigate to Dashboard after successful login
                if (Shell.Current is null)
                {
                    LoginMessage = "Navigation unavailable right now. Please try again.";
                    return;
                }

                await Shell.Current.GoToAsync("//dashboard");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Login] Navigation failed: {ex}");
                LoginMessage = "Login succeeded, but navigation failed.";
            }
        }
        else
        {
            LoginMessage = "Invalid email or password";
        }
    }
}
