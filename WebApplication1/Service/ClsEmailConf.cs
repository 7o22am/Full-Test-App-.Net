using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class ClsEmailConf : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var fromEmail = "7o22am@gmail.com";
        var fromPassword = "h022@m&..//";

        var message = new MailMessage();
        message.From = new MailAddress(fromEmail);
        message.Subject = subject;
        message.To.Add(email);
        message.Body = $"<html><body>{htmlMessage}</body></html>";
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(fromEmail, "hzwv qqub oibv crby")
        };
        smtpClient.UseDefaultCredentials = false;
        await smtpClient.SendMailAsync(message);
    }
}