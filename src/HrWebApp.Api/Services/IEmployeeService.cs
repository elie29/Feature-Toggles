using HrWebApp.Api.Models;

namespace HrWebApp.Api.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<PerformanceReview?> GetPerformanceReviewAsync(int employeeId);
    Task<PerformanceReview> CreatePerformanceReviewAsync(PerformanceReview review);
}