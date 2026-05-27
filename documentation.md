# Assignment Number 4 - Blazor Server Application Dashboard

**Student Name:** Awaab  
**Email:** 247371@students.au.edu.pk  
**Instructor:** Mr. Qaiser Ali  
**Department Chair:** Dr. Abdul Hameed  
**Repository Link:** [https://github.com/Awaab21/assignment4](https://github.com/Awaab21/assignment4)

---

## Table of Contents
1. [Application 01: Data Binding (One-Way vs. Two-Way)](#application-01-data-binding-one-way-vs-two-way)
2. [Application 02: Form Validation with Data Annotations](#application-02-form-validation-with-data-annotations)
3. [Application 03 & 08: Database-Backed To-Do List](#application-03--08-database-backed-to-do-list)
4. [Application 04: Click Counter with Manual Adjustment](#application-04-click-counter-with-manual-adjustment)
5. [Application 05: Singleton State Management Service](#application-05-singleton-state-management-service)
6. [Application 06: Dependency Injection & Configuration](#application-06-dependency-injection--configuration)
7. [Application 07: Theme Switcher (Light/Dark Mode) with LocalStorage](#application-07-theme-switcher-lightdark-mode-with-localstorage)
8. [Database Schema & Tables (App 08)](#database-schema--tables-app-08)

---

## Application 01: Data Binding (One-Way vs. Two-Way)
- **Goal:** Create a component that accepts a user’s name as input and displays a greeting message using both one-way and two-way data binding.
- **GitHub Link:** [App1_DataBinding.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/App1_DataBinding.razor)

### Implementation Explanation
- **Two-Way Data Binding:** Applied to the input field using `@bind="userName"`. Any characters typed in the text box update the backing C# property, and any changes in C# are pushed back to update the text box.
- **One-Way Data Binding:** Used to display the greeting message using `@userName`. This is a uni-directional flow from C# to HTML, rendering the value of the property in real-time.

### Razor Code
```razor
@page "/databinding"
@rendermode InteractiveServer

<div class="glass-card animate-fade-in">
    <h2>🔗 Application 01: Data Binding Demonstration</h2>
    <p class="text-secondary">Explore the differences between one-way and two-way data binding in Blazor.</p>
    
    <div class="form-group mt-4">
        <label for="nameInput" class="form-label">Enter your name (Two-Way Bound):</label>
        <input id="nameInput" type="text" class="form-control" @bind="userName" placeholder="Type a name here..." />
    </div>

    <div class="alert-premium alert-info mt-4">
        <span>👋</span>
        <div>
            <strong>Greeting (One-Way Bound):</strong> 
            @if (string.IsNullOrWhiteSpace(userName))
            {
                <span>Hello, Guest! Please enter your name above.</span>
            }
            else
            {
                <span>Hello, @userName! Welcome to our premium Blazor dashboard.</span>
            }
        </div>
    </div>
</div>

@code {
    private string userName { get; set; } = string.Empty;
}
```

---

## Application 02: Form Validation with Data Annotations
- **Goal:** Design a Blazor form with fields for first name, last name, and email. Ensure first/last names are required and email is validly formatted. Display validation messages.
- **GitHub Link:** [App2_FormValidation.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/App2_FormValidation.razor)

### Implementation Explanation
- **`<EditForm>` & `<DataAnnotationsValidator>`:** Blazor controls that wrap form fields and intercept validations.
- ** C# Model:** Utilizes data annotation attributes `[Required]` and `[EmailAddress]` on the fields.
- **`<ValidationMessage>`:** Dynamically displays the model validation error in red beneath input boxes.
- **Form Submission:** Blocks form execution if validation checks fail, executing the submit code only when valid.

### Razor Code
```razor
@page "/formvalidation"
@rendermode InteractiveServer
@using System.ComponentModel.DataAnnotations

<div class="glass-card animate-fade-in">
    <h2>📝 Application 02: Form & Data Annotations Validation</h2>
    <p class="text-secondary">A styled user registration form validating required inputs and email formatting rules.</p>

    @if (formSubmittedSuccessfully)
    {
        <div class="alert-premium alert-success animate-fade-in">
            <span>🎉</span>
            <div>
                <strong>Form Submission Success!</strong><br />
                The user account for <strong>@lastSubmittedModel.FirstName @lastSubmittedModel.LastName</strong> (@lastSubmittedModel.Email) has been successfully created.
            </div>
        </div>
    }

    <EditForm Model="@userModel" OnValidSubmit="HandleValidSubmit" FormName="UserRegistrationForm">
        <DataAnnotationsValidator />

        <div class="form-group">
            <label for="firstName" class="form-label">First Name *</label>
            <InputText id="firstName" class="form-control" @bind-Value="userModel.FirstName" placeholder="Enter first name" />
            <ValidationMessage For="@(() => userModel.FirstName)" class="validation-message" />
        </div>

        <div class="form-group">
            <label for="lastName" class="form-label">Last Name *</label>
            <InputText id="lastName" class="form-control" @bind-Value="userModel.LastName" placeholder="Enter last name" />
            <ValidationMessage For="@(() => userModel.LastName)" class="validation-message" />
        </div>

        <div class="form-group">
            <label for="email" class="form-label">Email Address *</label>
            <InputText id="email" class="form-control" @bind-Value="userModel.Email" placeholder="name@domain.com" />
            <ValidationMessage For="@(() => userModel.Email)" class="validation-message" />
        </div>

        <button type="submit" class="btn-premium mt-3">Submit Registration</button>
    </EditForm>
</div>

@code {
    private UserProfileModel userModel = new();
    private UserProfileModel lastSubmittedModel = new();
    private bool formSubmittedSuccessfully = false;

    private void HandleValidSubmit()
    {
        lastSubmittedModel = new UserProfileModel
        {
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            Email = userModel.Email
        };
        formSubmittedSuccessfully = true;
    }

    public class UserProfileModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address format (e.g. user@example.com)")]
        public string Email { get; set; } = string.Empty;
    }
}
```

---

## Application 03 & 08: Database-Backed To-Do List
- **Goal:** Create a component where users can add items to a to-do list. The input field uses two-way binding. Display items using one-way binding. Support clearing all items. Integrate with SQL Server LocalDB database using Entity Framework Core.
- **GitHub Link:** [App3_8_TodoList.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/App3_8_TodoList.razor)

### Implementation Explanation
- **CRUD Operations:** Adds, toggles status, deletes, and clears items by updating the `TodoTasks` DbSet inside `TodoDbContext` and invoking `SaveChangesAsync()`.
- **Startup Migration:** On application startup, `context.Database.EnsureCreated()` is executed, ensuring that the database file is registered and the table is structured.
- **Bindings:** Uses two-way binding for typing in tasks, and one-way binding to render rows of tasks.

### Razor Code
```razor
@page "/todolist"
@rendermode InteractiveServer
@inject TodoDbContext DbContext
@using Microsoft.EntityFrameworkCore

<div class="glass-card animate-fade-in">
    <h2>✅ Application 03 & 08: Database-Backed To-Do List</h2>
    <p class="text-secondary">Manage tasks with live synchronization to MS SQL Server LocalDB via Entity Framework Core.</p>

    <div class="form-group d-flex gap-2 mt-4">
        <input type="text" class="form-control" @bind="newTaskTitle" placeholder="Enter a new task here..." />
        <button class="btn-premium" @onclick="AddTask" disabled="@string.IsNullOrWhiteSpace(newTaskTitle)">Add Task</button>
    </div>

    <div class="mt-4">
        <h4>Task List (One-Way Bound Display)</h4>
        <hr class="my-2" style="border-color: var(--border-color);" />

        @if (tasks == null)
        {
            <p class="text-muted">Loading tasks from local database...</p>
        }
        else if (tasks.Count == 0)
        {
            <div class="alert-premium alert-info">No tasks found.</div>
        }
        else
        {
            <div class="task-list">
                @foreach (var task in tasks)
                {
                    <div class="task-item @(task.IsCompleted ? "completed" : "")">
                        <div class="d-flex align-items-center gap-3">
                            <input type="checkbox" checked="@task.IsCompleted" @onchange="() => ToggleTask(task)" class="todo-checkbox" />
                            <span class="task-title">@task.Title</span>
                        </div>
                        <button class="btn btn-sm btn-outline-danger" @onclick="() => DeleteTask(task)">🗑️</button>
                    </div>
                }
            </div>
            <button class="btn-danger-premium mt-3" @onclick="ClearAllTasks">⚠️ Clear All</button>
        }
    </div>
</div>

@code {
    private List<TodoTask>? tasks;
    private string newTaskTitle = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadTasks();
    }

    private async Task LoadTasks() => tasks = await DbContext.TodoTasks.OrderByDescending(t => t.CreatedAt).ToListAsync();

    private async Task AddTask()
    {
        if (!string.IsNullOrWhiteSpace(newTaskTitle))
        {
            DbContext.TodoTasks.Add(new TodoTask { Title = newTaskTitle.Trim(), IsCompleted = false, CreatedAt = DateTime.UtcNow });
            await DbContext.SaveChangesAsync();
            newTaskTitle = string.Empty;
            await LoadTasks();
        }
    }

    private async Task ToggleTask(TodoTask task)
    {
        task.IsCompleted = !task.IsCompleted;
        DbContext.TodoTasks.Update(task);
        await DbContext.SaveChangesAsync();
        await LoadTasks();
    }

    private async Task DeleteTask(TodoTask task)
    {
        DbContext.TodoTasks.Remove(task);
        await DbContext.SaveChangesAsync();
        await LoadTasks();
    }

    private async Task ClearAllTasks()
    {
        DbContext.TodoTasks.RemoveRange(await DbContext.TodoTasks.ToListAsync());
        await DbContext.SaveChangesAsync();
        await LoadTasks();
    }
}
```

---

## Application 04: Click Counter with Manual Adjustment
- **Goal:** Track click counts, increment values using button events, display count via one-way data binding, and manual adjustments via two-way data binding.
- **GitHub Link:** [App4_Counter.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/App4_Counter.razor)

### Implementation Explanation
- **Click Event:** Clicking the increment button runs `IncrementCount()`, increasing `count`.
- **One-Way Binding:** Instantly pushes count mutations to render inside the dashboard badge.
- **Two-Way Binding:** Inputs of type number bind bidirectionally via `@bind="count"`. Changing this input box updates the count variable, adjusting the display.

### Razor Code
```razor
@page "/clickcounter"
@rendermode InteractiveServer

<div class="glass-card animate-fade-in">
    <h2>🔢 Application 04: Click Counter & Manual Adjuster</h2>
    <p class="text-secondary">Tracks button clicks with options to manually set values using data bindings.</p>

    <div class="text-center py-4 my-3 bg-light rounded-3" style="background: rgba(99, 102, 241, 0.05);">
        <span>Current Count (One-Way Bound):</span>
        <h1 class="display-3 font-weight-800 my-2">@count</h1>
        <button class="btn-premium" @onclick="IncrementCount">➕ Click to Increment</button>
    </div>

    <div class="form-group mt-4">
        <label for="manualCount" class="form-label">Manually adjust count (Two-Way Bound):</label>
        <input id="manualCount" type="number" class="form-control" @bind="count" />
    </div>
</div>

@code {
    private int count = 0;
    private void IncrementCount() => count++;
}
```

---

## Application 05: Singleton State Management Service
- **Goal:** Implement a shared State Management Service to keep track of a user's authentication state across independent components.
- **Service Link:** [AuthenticationStateService.cs](https://github.com/Awaab21/assignment4/blob/main/Services/AuthenticationStateService.cs)
- **Login Component:** [Login.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/Login.razor)
- **UserProfile Component:** [UserProfile.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/UserProfile.razor)
- **Parent Page:** [App5_Authentication.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/App5_Authentication.razor)

### Implementation Explanation
- **Singleton Registration:** Registered as a singleton in `Program.cs` (`builder.Services.AddSingleton<AuthenticationStateService>()`), ensuring a single instance holds the `IsAuthenticated` state.
- **Event-Driven UI Update:** Defines an `event Action? OnChange` event. When methods `LogIn()` or `LogOut()` run, the event is invoked.
- **Memory Safety:** Interactive sub-components subscribe to the state change on `OnInitialized` and unsubscribe on `Dispose` using the `IDisposable` implementation.

### Service & Component Code
#### 1. AuthenticationStateService.cs
```csharp
using System;

namespace assignment_no_4.Services
{
    public class AuthenticationStateService
    {
        public bool IsAuthenticated { get; private set; }
        public event Action? OnChange;

        public void LogIn()
        {
            IsAuthenticated = true;
            NotifyStateChanged();
        }

        public void LogOut()
        {
            IsAuthenticated = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
```

---

## Application 06: Dependency Injection & Configuration
- **Goal:** Implement a Configurable Notification Service with settings registered as a singleton and injected into a notifications fetcher.
- **Notification Service Link:** [NotificationService.cs](https://github.com/Awaab21/assignment4/blob/main/Services/NotificationService.cs)
- **Notification Config Link:** [NotificationConfig.cs](https://github.com/Awaab21/assignment4/blob/main/Services/NotificationConfig.cs)
- **Display Component:** [NotificationDisplay.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/NotificationDisplay.razor)
- **Settings Component:** [NotificationSettings.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Pages/NotificationSettings.razor)

### Implementation Explanation
- **DI Structure:** `NotificationConfig` is registered as a singleton. `NotificationService` is registered as scoped and takes a constructor dependency on `NotificationConfig`.
- **Dynamic View Layout:** Settings modifications fire the `OnConfigChanged` event, prompting `NotificationDisplay.razor` to dynamically request fresh updates and toggle its display mode between "Compact" list items and "Detailed" dashboard cards.

---

## Application 07: Theme Switcher (Light/Dark Mode) with LocalStorage
- **Goal:** Toggle light and dark mode body themes, saving and reloading selections using browser local storage.
- **MainLayout Link:** [MainLayout.razor](https://github.com/Awaab21/assignment4/blob/main/Components/Layout/MainLayout.razor)
- **CSS Styles Link:** [app.css](https://github.com/Awaab21/assignment4/blob/main/wwwroot/app.css)
- **Theme Script Link:** [theme.js](https://github.com/Awaab21/assignment4/blob/main/wwwroot/js/theme.js)

### Implementation Explanation
- **CSS Variables:** Both light and dark theme colors are structured inside `app.css` under `:root` and `body.dark-theme`.
- **Prevention of FOUC:** An inline script is placed at the top of `App.razor` body. This script runs synchronously before rendering, immediately applying the class from local storage.
- **JS Interop Sync:** `MainLayout.razor` calls JS functions on toggle, adding or removing classes.

---

## Database Schema & Tables (App 08)
The database connection string points to `(localdb)\MSSQLLocalDB`, mapping data objects inside the catalog `Assignment4TodoDb`.

### Table Schema: `TodoTasks`
| Column Name | SQL Data Type | Attributes | Description |
| :--- | :--- | :--- | :--- |
| **Id** | `INT` | Primary Key, Identity(1,1) | Auto-incremented unique identifier for each task record. |
| **Title** | `NVARCHAR(100)` | Required, Not Null | The title text of the task. |
| **IsCompleted** | `BIT` | Not Null | Boolean status flag where `0` is pending and `1` is completed. |
| **CreatedAt** | `DATETIME2` | Not Null | Date and time stamp when the task was created. |

### Entity Model Class: `TodoTask.cs`
- **GitHub Link:** [TodoTask.cs](https://github.com/Awaab21/assignment4/blob/main/Services/TodoTask.cs)
```csharp
using System.ComponentModel.DataAnnotations;

namespace assignment_no_4.Services
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task title is required")]
        [StringLength(100, ErrorMessage = "Task title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
```

### Database Context: `TodoDbContext.cs`
- **GitHub Link:** [TodoDbContext.cs](https://github.com/Awaab21/assignment4/blob/main/Services/TodoDbContext.cs)
```csharp
using Microsoft.EntityFrameworkCore;

namespace assignment_no_4.Services
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
```
