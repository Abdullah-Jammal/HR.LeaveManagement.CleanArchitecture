using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public class UpdateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<UpdateLeaveTypeCommand, int>
{
    public async Task<int> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }
        leaveType.Name = request.Name;
        leaveType.DefaultDays = request.DefaultDays;
        await leaveTypeRepository.UpdateAsync(leaveType);
        return leaveType.Id;
    }
}
