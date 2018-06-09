using MediatR;
using System.Collections.Generic;

namespace YYY.Microservices.Domain.SeedWork
{
    public interface IEntity
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }
        void ClearDomainEvents();
        void RemoveDomainEvent(INotification eventItem);
        void AddDomainEvent(INotification eventItem);
    }
}
