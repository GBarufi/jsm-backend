using MediatR;
using Microsoft.Extensions.Logging;

namespace JSM.Application.Core
{
    public class NotificationHandler(ILogger<NotificationHandler> logger) : INotificationHandler<Notification>
    {
        private readonly List<Notification> _notifications = [];
        private readonly ILogger<NotificationHandler> _logger = logger;

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            _logger.LogWarning("Warning! {Key} - {Message}", notification.Key, notification.Message);

            return Task.CompletedTask;
        }

        public List<Notification> GetNotifications() => _notifications;

        public bool HasNotifications() => _notifications.Count > 0;
    }
}
