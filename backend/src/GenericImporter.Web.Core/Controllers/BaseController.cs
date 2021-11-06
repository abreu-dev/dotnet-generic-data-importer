using GenericImporter.Domain.Core.Notifications;
using GenericImporter.Web.Core.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GenericImporter.Web.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase 
    {
        private readonly DomainNotificationHandler _notifications;

        protected BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        private IEnumerable<string> GetValidationErrors()
        {
            return _notifications.GetNotifications().Select(c => c.Value);
        }

        private bool ValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response()
        {
            if (ValidOperation())
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity(new UnprocessableEntityResponse()
                {
                    Errors = GetValidationErrors()
                });
            }
        }
    }
}
