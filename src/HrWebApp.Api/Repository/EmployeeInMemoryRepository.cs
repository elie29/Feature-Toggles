using HrWebApp.Api.Models;

namespace HrWebApp.Api.Repository;

public class EmployeeInMemoryRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees;
    private readonly List<PerformanceReview> _reviews;

    public EmployeeInMemoryRepository()
    {
        _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@company.com", Department = "IT", HireDate = new DateTime(2020, 1, 1), Salary = 75000 },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@company.com", Department = "HR", HireDate = new DateTime(2019, 6, 15), Salary = 65000 }
        };
        _reviews = new List<PerformanceReview>();
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        return Task.FromResult(_employees.AsEnumerable());
    }

    public Task<Employee?> GetByIdAsync(int id)
    {
        return Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
    }

    public Task<PerformanceReview?> GetPerformanceReviewAsync(int employeeId)
    {
        return Task.FromResult(_reviews.FindAll(r => r.EmployeeId == employeeId).MaxBy(r => r.Id));
    }

    public Task<PerformanceReview> CreatePerformanceReviewAsync(PerformanceReview review)
    {
        review.Id = _reviews.Count + 1;
        _reviews.Add(review);
        return Task.FromResult(review);
    }
}