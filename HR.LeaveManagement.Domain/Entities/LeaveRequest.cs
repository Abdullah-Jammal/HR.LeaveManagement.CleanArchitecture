using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; } = new LeaveType();
    public string RequestComments { get; set; } = string.Empty;
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;
}
