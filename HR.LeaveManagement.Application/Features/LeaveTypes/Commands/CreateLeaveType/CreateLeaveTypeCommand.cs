using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public record CreateLeaveType : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public int DefaultDays { get; init; }
}
