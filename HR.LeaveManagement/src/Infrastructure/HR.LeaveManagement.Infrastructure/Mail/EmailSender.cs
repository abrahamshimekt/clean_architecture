using System;
using System.Threading.Tasks;
namespace HR.LeaveManagement.Infrastructure.Mail;
public class EmailSender :IEmailSender
{	
	private EmailSettings _emailSettings{get;}
	public EmailSender(IOptions<EmailSettings> emailSettings){
		_emailSettings = emailSettings;

	}
		public async Task<bool> SendEmail(Email email)
	{
		var client = new SendGridClient(_emailSettings.ApiKey);
		var to = new EmailAddress(email.To);
		var from = new EmailAddress{
			Email = _emailSettings.FromAddress,
			name = _emailSettings.FromName
		};
		var message = MailHelper.CreateSingleEmail(from,to,email.Subject,email.body,email.body);
		var response = await client.SendEmailAsync(message);

		return response.StatusCode == System.Net.HttpStatusCode.Ok || response.Net.HttpStatusCode.Accepted;
	}
}
