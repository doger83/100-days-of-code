using g2.ERP.Core.Entities;
using g2.ERP.Core.Events;
using g2.ERP.Core.Services;
using System;
using Xunit;

namespace g2.ERP.UnitTests.Core.Entities
{
    public class ItemCompletedEmailNotificationHandlerHandle
    {
        [Fact]
        public void ThrowsExceptionGivenNullEventArgument()
        {
            var handler = new ItemCompletedEmailNotificationHandler();

            Exception ex = Assert.Throws<ArgumentNullException>(() => handler.Handle(null));
        }

        [Fact]
        public void DoesNothingGivenEventInstance()
        {
            var handler = new ItemCompletedEmailNotificationHandler();

            handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()));
        }
    }
}
