using HrWebApp.Api.Models;

namespace HrWebApp.Api.Repository;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<PerformanceReview?> GetPerformanceReviewAsync(int employeeId);
    Task<PerformanceReview> CreatePerformanceReviewAsync(PerformanceReview review);
}