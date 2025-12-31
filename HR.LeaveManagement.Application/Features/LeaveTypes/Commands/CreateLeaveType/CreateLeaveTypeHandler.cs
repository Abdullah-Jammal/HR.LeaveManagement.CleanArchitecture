using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<CreateLeaveType, int>
{
    public async Task<int> Handle(CreateLeaveType request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeCommandValidator(leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid Leave Type", validationResult);
        }
        var leaveType = new LeaveType
        {
            Name = request.Name,
            DefaultDays = request.DefaultDays
        };
        await leaveTypeRepository.AddAsync(leaveType);
        return leaveType.Id;
    }
}
