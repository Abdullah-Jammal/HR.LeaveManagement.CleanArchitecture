using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Persistence.Repositories;

public class LeaveRequestRepository(HrDatabaseContext context) : ILeaveRequestRepository
{
    public async Task<List<LeaveRequest>> GetAllAsync()
    {
        return await context.LeaveRequests
            .AsNoTracking()
            .Include(lr => lr.LeaveType)
            .ToListAsync();
    }

    public async Task<LeaveRequest?> GetByIdAsync(int id)
    {
        return await context.LeaveRequests
            .Include(lr => lr.LeaveType)
            .FirstOrDefaultAsync(lr => lr.Id == id);
    }

    public async Task AddAsync(LeaveRequest leaveRequest)
    {
        context.LeaveRequests.Add(leaveRequest);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LeaveRequest leaveRequest)
    {
        context.LeaveRequests.Update(leaveRequest);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(LeaveRequest leaveRequest)
    {
        context.LeaveRequests.Remove(leaveRequest);
        await context.SaveChangesAsync();
    }
}
