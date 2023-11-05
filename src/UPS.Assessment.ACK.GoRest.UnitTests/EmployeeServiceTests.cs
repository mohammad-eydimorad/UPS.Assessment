using Moq;
using UPS.Assessment.ACL.GoRest;
using UPS.Assessment.ApplicationService.DTO;

public class EmployeeServiceTests
{
    [Fact]
    public async Task AddAsync_ShouldCallRestClientPostAsync()
    {
        // Arrange
        var employee = new EmployeeDto();
        var mockRestClient = new Mock<IRestClient<EmployeeDto>>();
        var employeeService = new EmployeeService(mockRestClient.Object);

        // Act
        await employeeService.AddAsync(employee);

        // Assert
        mockRestClient.Verify(r => r.PostAsync(employee), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallRestClientGetListAsync()
    {
        // Arrange
        var name = "John";
        var page = 2;
        var mockRestClient = new Mock<IRestClient<EmployeeDto>>();
        var employeeService = new EmployeeService(mockRestClient.Object);

        // Act
        await employeeService.GetAllAsync(name, page);

        // Assert
        mockRestClient.Verify(r => r.GetListAsync("?page=2&name=John"), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRestClientDeleteAsync()
    {
        // Arrange
        var id = 123;
        var mockRestClient = new Mock<IRestClient<EmployeeDto>>();
        var employeeService = new EmployeeService(mockRestClient.Object);

        // Act
        await employeeService.DeleteAsync(id);

        // Assert
        mockRestClient.Verify(r => r.DeleteAsync(id), Times.Once);
    }
}