﻿
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace Intelligent_Career_Advisor.Services;
public class EmailService(IOptions<MailSettings> mailSettings) : IEmailSender
{
    private readonly MailSettings _mailSettings = mailSettings.Value;
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_mailSettings.Mail),
            Subject = subject,
        };

        message.To.Add(MailboxAddress.Parse(email));

        var builder = new BodyBuilder
        {
            HtmlBody = htmlMessage,
        };

        message.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        //_logger.LogInformation("Sending email to {email}", email);

        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(message);
        smtp.Disconnect(true);
    }

}
