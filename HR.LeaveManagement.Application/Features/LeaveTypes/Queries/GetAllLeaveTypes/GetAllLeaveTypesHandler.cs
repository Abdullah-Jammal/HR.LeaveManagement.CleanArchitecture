using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesHandler(ILeaveTypeRepository leaveTypeRepository) :
    IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>
{
    public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request,
        CancellationToken cancellationToken)
    {
        var leaveTypes = await leaveTypeRepository.GetAllAsync();
        var leaveTypeDtos = leaveTypes.Select(lt => new LeaveTypeDto
        {
            Id = lt.Id,
            Name = lt.Name,
            DefaultDays = lt.DefaultDays
        }).ToList();
        return leaveTypeDtos;
    }
}
