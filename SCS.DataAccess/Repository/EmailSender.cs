using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SCS.Repository.IRepository;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SCS.Utility

{
    public class EmailSender : IEmailSender
    {
        private readonly IUnitOfWork _unitOfWork;
        public string SendGridSecret { get; set; } 

        public EmailSender(IConfiguration _config, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Needs to change here to set the App email sender - PM
            var admin = _unitOfWork.AppUser.Get(x => x.Email == SD.AdminEmail);

            //logic to send email
            var client = new SendGridClient(SendGridSecret);
            //var from = new EmailAddress(SD.AdminEmail, "SCS Test Email");
            var from = new EmailAddress(admin.Email, "SCS Test Email");
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            return client.SendEmailAsync(message);
        }
    }
}
