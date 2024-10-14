using MediatR;

namespace Domain.Primitives;

public class DomainEvent(Guid Id) : INotification;