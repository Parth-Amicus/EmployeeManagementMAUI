namespace EmployeeManagementMAUI.Controls;

public partial class StatusBadge : ContentView
{
    // BindableProperty so the Status value can be set from XAML bindings in
    // DataTemplates and still trigger the converter-driven colour updates inside
    // the control's own visual tree via x:Reference self.
    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(
            propertyName: nameof(Status),
            returnType: typeof(string),
            declaringType: typeof(StatusBadge),
            defaultValue: string.Empty);

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public StatusBadge()
    {
        InitializeComponent();
    }
}
