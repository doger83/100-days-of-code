using Ardalis.GuardClauses;
using g2.ERP.Core.Events;
using g2.ERP.Core.Interfaces;

namespace g2.ERP.Core.Services
{
    public class ItemCompletedEmailNotificationHandler : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
        }
    }
}
