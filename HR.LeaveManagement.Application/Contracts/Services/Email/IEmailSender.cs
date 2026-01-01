
namespace HR.LeaveManagement.Application.Contracts.Services.Email;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(string to, string subject, string body);
}
