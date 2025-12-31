using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;

public record DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; init; }
}
