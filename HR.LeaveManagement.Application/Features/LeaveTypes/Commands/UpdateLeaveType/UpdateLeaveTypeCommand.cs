using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<int>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int DefaultDays { get; init; }
}
