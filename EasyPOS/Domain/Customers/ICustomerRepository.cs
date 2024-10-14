namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id);
    void Add(Customer customer);
}