using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{   
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
       _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Customer customer) => _context.Customers.Add(customer);

    public async Task<Customer?> GetByIdAsync(CustomerId id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
}