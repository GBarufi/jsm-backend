using JSM.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JSM.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApiControllerBase(INotificationHandler<Notification> notifications) : ControllerBase
    {
        public readonly NotificationHandler _notifications = (NotificationHandler)notifications;

        protected ActionResult ProcessResponse()
        {
            if (!_notifications.HasNotifications())
                return Ok();

            return BadRequest(_notifications.GetNotifications());
        }

        protected ActionResult ProcessResponse(object result)
        {
            if (!_notifications.HasNotifications())
                return Ok(result);

            return BadRequest(_notifications.GetNotifications());
        }
    }
}
