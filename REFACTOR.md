# MAUI XAML Refactoring Documentation

## Overview

During the UI refactoring of the Employee Management MAUI application, duplicated XAML code was reduced by introducing reusable resources, custom controls, and control templates.

The main objective was to improve code maintainability, consistency, and reusability without changing the existing application functionality or UI design.

## 1. Centralized Colors, Font Sizes, and Spacing

**Problem:**

Colors, font sizes, and spacing values were repeated across multiple XAML pages. For example, the same background color and text color were manually specified in different Labels and Borders.

**Before:**

```xml
<Label Text="Inspections"
       FontSize="26"
       FontAttributes="Bold"
       TextColor="#0F172A" />
```

**After:**

```xml
<Label Text="Inspections"
       Style="{StaticResource PageTitleLabelStyle}" />
```

**Refactoring performed:**

- Centralized colors in `App.xaml`.
- Created reusable font-size and spacing resources.
- Created reusable Label styles such as `PageTitleLabelStyle` and `InspectionTitleLabelStyle`.
- Replaced repeated hardcoded values with `StaticResource` references.

**Benefit:**

Changing a shared color, font size, or style in one location updates its appearance throughout the application.

## 2. Created a Reusable StatusBadge Custom Control

**Problem:**

Inspection statuses were displayed using individual Labels across the Dashboard, CollectionView, and ListView pages. Their font sizes and text colors were repeated.

**Before:**

```xml
<Label Text="{Binding Status}"
       FontSize="12"
       FontAttributes="Bold"
       TextColor="#2563EB" />
```

**After:**

```xml
<controls:StatusBadge
    Status="{Binding Status}" />
```

**Refactoring performed:**

- Created `StatusBadge.xaml` as a reusable `ContentView`.
- Added a bindable `Status` property in `StatusBadge.xaml.cs`.
- Implemented status-based appearance:
  - Pending: amber.
  - In Progress: purple.
  - Completed: green.
- Reused the control in the Dashboard and inspection list pages.

**Benefit:**

Status appearance is managed in one place. Any future design changes can be made inside the custom control instead of updating multiple pages.

## 3. Created a Reusable CardControlTemplate

**Problem:**

Dashboard summary cards, inspection cards, and the Inspector Profile card repeated similar Border properties, including background color, border color, corner radius, padding, and shadow.

**Before:**

```xml
<Border BackgroundColor="White"
        Stroke="#E2E8F0"
        StrokeShape="RoundRectangle 12"
        Padding="16">

    <VerticalStackLayout>
        <!-- Card content -->
    </VerticalStackLayout>

</Border>
```

**After:**

```xml
<ContentView
    ControlTemplate="{StaticResource CardControlTemplate}"
    Padding="{StaticResource SummaryCardPadding}">

    <VerticalStackLayout>
        <!-- Card content -->
    </VerticalStackLayout>

</ContentView>
```

**Refactoring performed:**

- Created `CardControlTemplate` inside the `App.xaml` ResourceDictionary.
- Used `ContentPresenter` to display the content supplied by each ContentView.
- Used `TemplateBinding Padding` to allow individual cards to control their internal spacing.
- Applied the template to the Dashboard summary cards, Dashboard inspection cards, and Inspector Profile card.

**Benefit:**

The card appearance is defined once and reused across different pages. This improves visual consistency and reduces duplicated XAML.

## 4. Simplified the ListView Item Template

**Problem:**

The ListView item template used the older `ViewCell` wrapper around its card content.

**Before:**

```xml
<ListView.ItemTemplate>
    <DataTemplate>
        <ViewCell>
            <Border>
                <!-- Inspection content -->
            </Border>
        </ViewCell>
    </DataTemplate>
</ListView.ItemTemplate>
```

**After:**

```xml
<ListView.ItemTemplate>
    <DataTemplate>
        <Grid>
            <Border>
                <!-- Inspection content -->
            </Border>
        </Grid>
    </DataTemplate>
</ListView.ItemTemplate>
```

**Refactoring performed:**

- Removed the obsolete `ViewCell` wrapper.
- Used a Grid as the root of the item template.
- Kept the existing inspection information and data bindings.

**Benefit:**

The item template has a simpler structure and avoids relying on the obsolete ViewCell API.

---

## Conclusion

The refactoring improved the overall structure of the Employee Management MAUI application by:

- Reducing duplicated XAML.
- Centralizing application-wide styling.
- Introducing reusable custom controls.
- Reusing ControlTemplates for consistent card designs.
- Simplifying the ListView item template.
- Improving maintainability and making future UI changes easier.

The existing MVVM structure, data bindings, and application functionality were retained during the refactoring.