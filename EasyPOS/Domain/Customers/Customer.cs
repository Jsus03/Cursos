using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string fullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
}