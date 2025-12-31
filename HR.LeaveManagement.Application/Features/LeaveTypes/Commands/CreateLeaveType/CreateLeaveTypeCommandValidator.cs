using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator
    : AbstractValidator<CreateLeaveType>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Leave type name cannot be empty.")
            .MaximumLength(50).WithMessage("Leave type name cannot exceed 50 characters.");

        RuleFor(x => x.DefaultDays)
            .InclusiveBetween(1, 99)
            .WithMessage("Default days must be between 1 and 99.");

        RuleFor(x => x)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exists.");
    }

    private async Task<bool> LeaveTypeNameUnique(
        CreateLeaveType command,
        CancellationToken cancellationToken)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
