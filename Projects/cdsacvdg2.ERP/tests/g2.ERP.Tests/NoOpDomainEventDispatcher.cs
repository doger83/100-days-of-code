using g2.ERP.Core.Interfaces;
using g2.ERP.Core.SharedKernel;

namespace g2.ERP.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
