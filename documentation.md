# Assignment Number 4 - 8 Standalone Blazor Projects Suite

**Student Name:** Awaab  
**Email:** 247371@students.au.edu.pk  
**Instructor:** Mr. Qaiser Ali  
**Department Chair:** Dr. Abdul Hameed  
**Repository Link:** [https://github.com/Awaab21/assignment4](https://github.com/Awaab21/assignment4)

This workspace contains **8 separate, standalone Blazor Web App projects** compiling and running independently. Each project implements a specific assignment application with premium styling, modern typography, glassmorphism card containers, and unified suite navigation linking all projects.

---

## Workspace Directory Structure
```
c:\Users\ac\Desktop\assignment no 4\
  ├── Application01/     (App 1: Data Binding Demo)
  ├── Application02/     (App 2: Form Validation)
  ├── Application03/     (App 3: Local To-Do List)
  ├── Application04/     (App 4: Button Click Counter)
  ├── Application05/     (App 5: Auth State Manager)
  ├── Application06/     (App 6: DI Notifications)
  ├── Application07/     (App 7: Theme Switcher App)
  ├── Application08/     (App 8: Database To-Do List)
  ├── .gitignore
  └── documentation.md
```

---

## 🔗 Port Mappings & Navigation Suite
All projects are configured in their `launchSettings.json` profiles to listen on designated local ports. They include a cross-linked navigation menu allowing quick hopping between applications:
- **Application01**: Port `5001` (HTTPS `7001`)
- **Application02**: Port `5002` (HTTPS `7002`)
- **Application03**: Port `5003` (HTTPS `7003`)
- **Application04**: Port `5004` (HTTPS `7004`)
- **Application05**: Port `5005` (HTTPS `7005`)
- **Application06**: Port `5006` (HTTPS `7006`)
- **Application07**: Port `5007` (HTTPS `7007`)
- **Application08**: Port `5008` (HTTPS `7008`)

---

## Application 01: Data Binding (One-Way vs. Two-Way)
- **Goal:** Create a component that accepts a user’s name as input and displays a greeting message using both one-way and two-way data binding. Describe the differences in your solution.
- **GitHub Link:** [Application01/Components/Pages/Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application01/Components/Pages/Home.razor)

### Concepts Explained
- **Two-Way Binding:** Implemented on the text input box using `@bind="userName"`. Any changes in the input instantly update the C# variable, and C# edits are reflected in the input.
- **One-Way Binding:** Displays the greeting message using `@userName`. Pulls the C# variable value and renders it in the HTML markup.

---

## Application 02: Form Validation with Data Annotations
- **Goal:** Design a Blazor form with fields for first name, last name, and email. Use Blazor’s form validation features to validate fields and output a success message on submission.
- **GitHub Link:** [Application02/Components/Pages/Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application02/Components/Pages/Home.razor)

### Concepts Explained
- **DataAnnotationsValidator:** Hooked inside `<EditForm>` to read annotations on model properties.
- **Attributes:** Validates input parameters using C# attributes: `[Required]` for names, and `[EmailAddress]` for emails.
- **ValidationMessage:** Dynamically renders red validation messages. Blocks submissions if verification fails.

---

## Application 03: In-Memory To-Do List
- **Goal:** Create a component where users can add items to a to-do list. The input field uses two-way data binding, and tasks display dynamically below. Includes a clear all button.
- **GitHub Link:** [Application03/Components/Pages/Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application03/Components/Pages/Home.razor)

### Concepts Explained
- **Two-Way Input Binding:** Binds `newTaskTitle` to capture input.
- **One-Way Display Binding:** Renders list rows using a `@foreach` loop over the backing list array.
- **Clear List:** Executes the `.Clear()` list operation to remove all entries, refreshing the DOM.

---

## Application 04: Click Counter with Manual Adjustment
- **Goal:** Track click counts, increment values using button events, display count via one-way data binding, and manual adjustments via two-way data binding.
- **GitHub Link:** [Application04/Components/Pages/Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application04/Components/Pages/Home.razor)

### Concepts Explained
- **Event Handling:** Increments the counter via an `@onclick` listener invoking C# logic.
- **Two-Way Input Binding:** Links a number input field bidirectionally, updating the click counter manually.

---

## Application 05: Singleton State Management Service
- **Goal:** Implement a shared State Management Service to keep track of a user's authentication state across independent components.
- **Services:** [AuthenticationStateService.cs](https://github.com/Awaab21/assignment4/blob/main/Application05/Services/AuthenticationStateService.cs)
- **Login Component:** [Login.razor](https://github.com/Awaab21/assignment4/blob/main/Application05/Components/Pages/Login.razor)
- **UserProfile Component:** [UserProfile.razor](https://github.com/Awaab21/assignment4/blob/main/Application05/Components/Pages/UserProfile.razor)
- **Parent Page:** [Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application05/Components/Pages/Home.razor)

### Concepts Explained
- **Singleton Lifetime:** Registered as a singleton in `Program.cs`, sharing state across components.
- **Subscription Model:** Sub-components subscribe to the service's `OnChange` action event and run `StateHasChanged()` on state transitions, unsubscribing in `Dispose()` to avoid memory leaks.

---

## Application 06: Dependency Injection & Configuration
- **Goal:** Implement a Configurable Notification Service with settings registered as a singleton and injected into a notifications service.
- **Notification Service Link:** [NotificationService.cs](https://github.com/Awaab21/assignment4/blob/main/Application06/Services/NotificationService.cs)
- **Notification Config Link:** [NotificationConfig.cs](https://github.com/Awaab21/assignment4/blob/main/Application06/Services/NotificationConfig.cs)
- **Display Component:** [NotificationDisplay.razor](https://github.com/Awaab21/assignment4/blob/main/Application06/Components/Pages/NotificationDisplay.razor)
- **Settings Component:** [NotificationSettings.razor](https://github.com/Awaab21/assignment4/blob/main/Application06/Components/Pages/NotificationSettings.razor)
- **Parent Page:** [Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application06/Components/Pages/Home.razor)

### Concepts Explained
- **Configuration Injection:** `NotificationConfig` (Singleton) stores settings. It is injected into `NotificationService` (Scoped) to configure default counts and styling.
- **Dynamic Render Switching:** Display component reads config style properties and dynamically flips between compact dot lists and full details cards.

---

## Application 07: Theme Switcher (Light/Dark Mode) with LocalStorage
- **Goal:** Toggle light and dark mode body themes, saving and reloading selections using browser local storage.
- **MainLayout Link:** [MainLayout.razor](https://github.com/Awaab21/assignment4/blob/main/Application07/Components/Layout/MainLayout.razor)
- **CSS Styles Link:** [app.css](https://github.com/Awaab21/assignment4/blob/main/Application07/wwwroot/app.css)
- **Theme Script Link:** [theme.js](https://github.com/Awaab21/assignment4/blob/main/Application07/wwwroot/js/theme.js)

### Concepts Explained
- **CSS Color Variables:** Defines styles under `:root` and `body.dark-theme` for background gradients, text tones, cards, and borders.
- **Flicker-Free Load:** Top-level App body script loads cache before render, applying active classes immediately to avoid white flash.

---

## Application 08: Database-Backed To-Do List
- **Goal:** Connect the To-Do list application to a database (MSSQLLocalDB). Synchronize creates, updates, deletes, and clears locally.
- **Db Context Link:** [TodoDbContext.cs](https://github.com/Awaab21/assignment4/blob/main/Application08/Services/TodoDbContext.cs)
- **Task Entity Link:** [TodoTask.cs](https://github.com/Awaab21/assignment4/blob/main/Application08/Services/TodoTask.cs)
- **Main Page:** [Home.razor](https://github.com/Awaab21/assignment4/blob/main/Application08/Components/Pages/Home.razor)

### Implementation Explanation
- **Automatic Setup:** Installs SQL Server EF Core providers. Invokes `context.Database.EnsureCreated()` on app startup to create the catalog `Assignment4TodoDb` and tables automatically.
- **Data Operations:** All task creations, status checkboxes toggling, individual row removals, and list empty actions run database SQL queries and save operations.

### Table Schema: `TodoTasks`
| Column Name | SQL Data Type | Attributes | Description |
| :--- | :--- | :--- | :--- |
| **Id** | `INT` | Primary Key, Identity(1,1) | Unique identifier for each task record. |
| **Title** | `NVARCHAR(100)` | Required, Not Null | The title text of the task. |
| **IsCompleted** | `BIT` | Not Null | Boolean completion status. |
| **CreatedAt** | `DATETIME2` | Not Null | Time when the task was logged. |
