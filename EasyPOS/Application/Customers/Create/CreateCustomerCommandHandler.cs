using Domain.Customers;
using Domain.Primitives;
using System;

namespace Application.Customers.Create;
public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        if (Address.Create(command.Country, command.Line1, command.Line2, command.City, 
                    command.State, command.ZipCode) is not Addres addres)
        {
            throw new ArgumentException(nameof(addres));
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            addres, 
            true
        );

        await _customerRepository.Add(customer);

        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return Unit.Value;
    }
}