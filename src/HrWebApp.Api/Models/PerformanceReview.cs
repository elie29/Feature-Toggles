namespace HrWebApp.Api.Models;

public class PerformanceReview
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime ReviewDate { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
    public string Comments { get; set; } = string.Empty;
}