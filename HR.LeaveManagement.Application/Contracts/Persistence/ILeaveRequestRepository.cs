using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository
{
    Task<List<LeaveRequest>> GetAllAsync();
    Task<LeaveRequest?> GetByIdAsync(int id);
    Task AddAsync(LeaveRequest request);
    Task UpdateAsync(LeaveRequest request);
    Task DeleteAsync(LeaveRequest request);
}
