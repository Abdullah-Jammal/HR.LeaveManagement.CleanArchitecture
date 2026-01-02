using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
        var leaveTypes = await mediator.Send(new GetAllLeaveTypesQuery());
        return leaveTypes;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveTypes = await mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return Ok(leaveTypes);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Post(
        [FromBody] CreateLeaveType createLeaveType)
    {
        var id = await mediator.Send(createLeaveType);
        return CreatedAtAction(nameof(Post), new { id }, id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Put([FromBody] UpdateLeaveTypeCommand updateLeaveType)
    {
        var id = await mediator.Send(updateLeaveType);
        return Ok(id);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteLeaveTypeCommand { Id = id });
        return NoContent();
    }
}
