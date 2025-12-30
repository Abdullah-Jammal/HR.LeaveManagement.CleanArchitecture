using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;

public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
