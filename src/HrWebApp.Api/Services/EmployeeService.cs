using Microsoft.FeatureManagement;
using HrWebApp.Api.Models;
using HrWebApp.Api.Repository;

namespace HrWebApp.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IFeatureManager _featureManager;
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IFeatureManager featureManager, IEmployeeRepository repository)
    {
        _featureManager = featureManager;
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<PerformanceReview?> GetPerformanceReviewAsync(int employeeId)
    {
        // Check if the new performance review feature is enabled
        if (!await _featureManager.IsEnabledAsync("NewPerformanceReviewSystem"))
        {
            throw new InvalidOperationException("The new performance review system is not enabled.");
        }

        return await _repository.GetPerformanceReviewAsync(employeeId);
    }

    public async Task<PerformanceReview> CreatePerformanceReviewAsync(PerformanceReview review)
    {
        // Check if the new performance review feature is enabled
        if (!await _featureManager.IsEnabledAsync("NewPerformanceReviewSystem"))
        {
            throw new InvalidOperationException("The new performance review system is not enabled.");
        }
        if (review == null || await _repository.GetByIdAsync(review.EmployeeId) == null)
        {
            throw new InvalidOperationException("Invalid review data with non-existent employee ID.");
        }
        return await _repository.CreatePerformanceReviewAsync(review);
    }
}