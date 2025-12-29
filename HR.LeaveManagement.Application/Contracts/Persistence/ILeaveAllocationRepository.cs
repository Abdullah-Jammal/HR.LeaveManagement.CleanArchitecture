using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository
{
    Task<LeaveAllocation?> GetAllocationAsync(
    int employeeId,
    int leaveTypeId,
    int year
);

    Task AddAsync(LeaveAllocation allocation);
    Task UpdateAsync(LeaveAllocation allocation);
}
