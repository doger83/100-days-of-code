using g2.ERP.Core.SharedKernel;

namespace g2.ERP.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}