using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository
{
    Task<List<LeaveTypeDto>> GetAllAsync();
    Task<LeaveTypeDetailsDto?> GetByIdAsync(int id);
    Task AddAsync(LeaveType leaveType);
    Task UpdateAsync(LeaveType leaveType);
    Task DeleteAsync(LeaveType leaveType);
}
