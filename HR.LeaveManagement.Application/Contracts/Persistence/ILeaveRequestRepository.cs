using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository
{
    Task AddAsync(LeaveRequest request);
    Task<LeaveRequest?> GetByIdAsync(int id);
    Task<List<LeaveRequest>> GetByEmployeeIdAsync(int employeeId);
}
