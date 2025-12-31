using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsHandler(ILeaveTypeRepository leaveTypeRepository) :
    IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }
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
