using MediatR;

namespace JSM.Application.Core
{
    public class Notification(string key, string message) : INotification
    {
        public string Key { get; } = key;
        public string Message { get; } = message;
    }

    public static class NotificationKey
    {
        public static readonly string Request = "REQUEST_NOTIFICATION";
        public static readonly string RequestHandler = "REQUEST_HANDLER_NOTIFICATION";
        public static readonly string Exception = "EXCEPTION";
    }
}
