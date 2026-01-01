using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Persistence.Repositories;

public class LeaveTypeRepository(HrDatabaseContext context) : ILeaveTypeRepository
{
    public async Task<List<LeaveType>> GetAllAsync()
    {
        return await context.LeaveTypes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<LeaveType?> GetByIdAsync(int id)
        => await context.LeaveTypes.FindAsync(id);

    public async Task AddAsync(LeaveType leaveType)
    {
        context.LeaveTypes.Add(leaveType);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LeaveType leaveType)
    {
        context.LeaveTypes.Update(leaveType);
        context.Entry(leaveType).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(LeaveType leaveType)
    {
        context.LeaveTypes.Remove(leaveType);
        await context.SaveChangesAsync();
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
        => !await context.LeaveTypes.AnyAsync(x => x.Name == name);
}
