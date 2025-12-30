using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsHandler(ILeaveTypeRepository leaveTypeRepository) :
    IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id);
        var leaveTypeDetailsDto = new LeaveTypeDetailsDto
        {
            Id = leaveType!.Id,
            Name = leaveType.Name,
            DefaultDays = leaveType.DefaultDays,
            CreatedAt = leaveType.CreatedAt,
            UpdatedAt = leaveType.UpdatedAt
        };
        return leaveTypeDetailsDto;
    }
}
