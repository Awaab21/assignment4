using System;

namespace assignment_no_4.Services
{
    public class NotificationConfig
    {
        private int _defaultNumberOfNotifications = 3;
        private string _notificationStyle = "Compact"; // "Compact" or "Detailed"

        public int DefaultNumberOfNotifications
        {
            get => _defaultNumberOfNotifications;
            set
            {
                if (_defaultNumberOfNotifications != value)
                {
                    _defaultNumberOfNotifications = value;
                    NotifyChanged();
                }
            }
        }

        public string NotificationStyle
        {
            get => _notificationStyle;
            set
            {
                if (_notificationStyle != value)
                {
                    _notificationStyle = value;
                    NotifyChanged();
                }
            }
        }

        public event Action? OnConfigChanged;

        private void NotifyChanged() => OnConfigChanged?.Invoke();
    }
}
