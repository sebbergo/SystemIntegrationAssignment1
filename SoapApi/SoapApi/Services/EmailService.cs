using SoapApi.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SoapApi.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailInvitation(InvitationDto invitation);
    }
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailInvitation(InvitationDto invitation)
        {
            bool isSucces = false;

            // Create the SmtpClient
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "dbassignmenttwopostgres@gmail.com",
                    Password = "ddujswjsnyfrvzrg"
                }
            };

            MailAddress FromEmail = new MailAddress("dbassignmenttwopostgres@gmail.com", "InvitationAssignmentDemo");
            MailAddress ToEmail = new MailAddress(invitation.Mail, "Invitation Assignment");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Invitation",
                Body = invitation.InvitationMessage
            };

            Message.To.Add(ToEmail);

            try
            {
                await Client.SendMailAsync(Message);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            return isSucces;
        }
    }
}