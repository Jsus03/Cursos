using Application.Customers.Create;
using Domain.Customers;
using Domain.Primitives;
using Domain.DomainErrors;

namespace Application.Customers.UnitTests.Create;

public class CreateCustomerCommandHandlerUnitTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerCommandHandlerUnitTests()
    {
        _mockCustomerRepository = new Mock<ICustomerRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
    {
        //Arrange
        CreateCustomerCommand command = new CreateCustomerCommand(
            "Jesus", "Calderon", "jc@gmail.com", "184984984", "", "", "","","","");

        //Act
        var result = await _handler.Handle(command, default);
        
        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Code.Should().Be(Errors.Customer.PhoneNumberWithBadFormat.Code);
        result.FirstError.Description.Should().Be(Errors.Customer.PhoneNumberWithBadFormat.Description);
    }
}