# EmployeeManagementMAUI

A cross-platform employee management application built with .NET MAUI following the **Model-View-ViewModel (MVVM)** architectural pattern.

---

## Project Structure

The project follows an MVVM-oriented folder structure to ensure clean separation of concerns and maintainability:

```text
EmployeeManagementMAUI/
│
├── Models/                 # Application data models
├── ViewModels/             # UI state, properties, and commands
├── Views/                  # XAML pages and their code-behind files
├── Controls/               # Reusable UI components
├── Services/               # Reusable application services
│
├── Resources/              # App assets and styling
│   ├── AppIcon/
│   ├── Fonts/
│   ├── Images/
│   ├── Raw/
│   └── Splash/
│
├── Platforms/              # Platform-specific code and configurations
│   ├── Android/
│   ├── iOS/
│   ├── MacCatalyst/
│   └── Windows/
│
├── App.xaml                # Application-wide resources and styles
├── App.xaml.cs             # Initializes the application and creates its window
├── AppShell.xaml           # Defines the application's navigation structure
├── AppShell.xaml.cs        # Code-behind for AppShell
├── MauiProgram.cs          # Configures the MAUI application, fonts, and services
├── MainPage.xaml           # Main application landing page
├── MainPage.xaml.cs        # Code-behind for MainPage
└── EmployeeManagementMAUI.csproj
```

---

## MVVM Architecture

The application implements the **Model-View-ViewModel (MVVM)** pattern to decouple UI code from business and presentation logic:

* **Model:** Represents the application's core data structures and business entities.
* **View:** Represents the user interface, developed using XAML (`Views/`).
* **ViewModel:** Contains the presentation logic, commands, and UI state (`ViewModels/`).

### How MVVM Works in This App
1. The user interacts with a control in the **View**.
2. The **View** invokes a command or updates a data-bound property.
3. The **ViewModel** processes the interaction and executes necessary business logic.
4. The **ViewModel** updates its observable properties.
5. **Data binding** automatically reflects those changes in the UI.

### Key Entry & Configuration Files
* **`MauiProgram.cs`**: Configures the MAUI application builder, dependency injection, fonts, and services.
* **`App.xaml.cs`**: Initializes the application instance and creates the main application `Window`.
* **`AppShell.xaml`**: Defines the visual hierarchy and URI-based navigation structure of the app.

---

## Application Lifecycle Observation

Below are the observed window lifecycle events during testing and their practical real-world use cases in .NET MAUI:

### Observed Event Flows
1. **Application Launch:** `Created` ➔ `Activated`
2. **Pressing Home (Backgrounding):** `Deactivated` ➔ `Stopped`
3. **Returning to Application:** `Resumed` ➔ `Activated`
4. **Application Termination:** `[Update after testing]` *(e.g., `Stopped` ➔ `Destroying`)*

> **Note:** Actual event ordering and termination behavior can vary depending on the target platform and operating system resource management.

### Real-World Lifecycle Use Cases

| Lifecycle Event | Practical Use Case |
| :--- | :--- |
| **`Created`** | Initialize window-specific resources and initial state. |
| **`Activated`** | Refresh important information when the user brings the app into focus. |
| **`Deactivated`** | Pause UI animations, media, or sensitive operations. |
| **`Stopped`** | Save important application state and pause background work. |
| **`Resumed`** | Refresh visible data and restart necessary operations. |
| **`Destroying`** | Release window-specific resources and unsubscribe from events. |


### Safe Area Handling

* **Requirement:** Ensure that application content is not hidden behind device-specific screen areas such as notches, status bars, navigation bars, or home indicators.
* **Why It Is Needed:** Modern smartphones feature diverse screen designs—including notches, camera cutouts, status bars, and home indicators. Without proper safe area handling, UI elements can overlap these system areas, making them difficult to read or interact with.

#### Implementation
* Applied the `SafeAreaEdges` property on `InspectorProfilePage`.
* Set `SafeAreaEdges="All"` to respect all safe area insets, keeping profile content within the visible screen area and accounting for the on-screen software keyboard.
* Wrapped the layout in a `ScrollView` so profile content remains accessible and scrollable on smaller screens.

#### Testing & Verification
* Verified `InspectorProfilePage` on the Android emulator for proper system bar spacing, content visibility, and screen orientation changes.

---