using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assignment_no_4.Services
{
    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Category { get; set; } = "Info"; // Success, Info, Warning, Alert
    }

    public class NotificationService
    {
        private readonly NotificationConfig _config;

        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }

        public Task<List<NotificationItem>> GetNotificationsAsync(int? numberOfNotifications = null)
        {
            int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;
            if (count < 0) count = 0;

            var notifications = new List<NotificationItem>();
            var categories = new[] { "Info", "Success", "Warning", "Alert" };
            var titles = new[]
            {
                "System Update",
                "New Direct Message",
                "Database Synced",
                "Security Warning",
                "Task Completed",
                "Session Started",
                "Configuration Changed",
                "Server Status OK"
            };
            var messages = new[]
            {
                "The application was successfully updated with glassmorphism dashboard views.",
                "You received a message from Mr. Qaiser Ali regarding Assignment 4.",
                "All tasks were successfully synchronized with the local MSSQLLocalDB instance.",
                "A login attempt was made using the singleton AuthenticationStateService.",
                "You checked off a task in your interactive database to-do list.",
                "State management session has been initialized for the current client connection.",
                "Notification parameters were updated and applied using Dependency Injection.",
                "All components and database contexts are fully initialized and responsive."
            };

            for (int i = 0; i < count; i++)
            {
                int idx = i % titles.Length;
                notifications.Add(new NotificationItem
                {
                    Id = i + 1,
                    Title = titles[idx],
                    Message = messages[idx],
                    Timestamp = DateTime.Now.AddMinutes(-12 * i),
                    Category = categories[i % categories.Length]
                });
            }

            return Task.FromResult(notifications);
        }
    }
}
