using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using HrWebApp.Api.Models;
using HrWebApp.Api.Services;

namespace HrWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpGet("{id}/performance-review")]
    public async Task<ActionResult<PerformanceReview>> GetPerformanceReview(int id)
    {
        try
        {
            var review = await _employeeService.GetPerformanceReviewAsync(id);
            if (review == null)
            {
                return NotFound("No performance review found for this employee.");
            }
            return Ok(review);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/performance-review")]
    public async Task<ActionResult<PerformanceReview>> CreatePerformanceReview(int id, [FromBody] PerformanceReview review)
    {
        try
        {
            review.EmployeeId = id;
            var createdReview = await _employeeService.CreatePerformanceReviewAsync(review);
            return CreatedAtAction(nameof(GetPerformanceReview), new { id }, createdReview);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}