using g2.ERP.Core.SharedKernel;

namespace g2.ERP.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}