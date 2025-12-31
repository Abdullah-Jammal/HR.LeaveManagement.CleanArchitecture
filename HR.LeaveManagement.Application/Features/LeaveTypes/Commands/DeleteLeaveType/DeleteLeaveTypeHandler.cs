using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;

public class DeleteLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }
        await leaveTypeRepository.DeleteAsync(leaveType);
        return Unit.Value;
    }
}
