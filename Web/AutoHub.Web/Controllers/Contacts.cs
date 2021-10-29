namespace AutoHub.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using AutoHub.Services.Messaging;
    using AutoHub.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class Contacts : Controller
    {
        private readonly IEmailSender emailSender;

        public Contacts(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }


        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }    

            await this.emailSender.SendEmailAsync("windows199@abv.bg", model.Email, "ppenchev19@gmail.com", model.Subject, model.Message);

            //await this.emailSender.SendEmailAsync(model.Email, model.Name, "ppenchev19@gmail.com", model.Subject, model.Message);

            return this.Json(model);

            //var apiKey = "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";
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("ppenchev19@gmail.com", "Example User");
            //var subject = "Sending with SendGrid is Fun";
            //var to = new EmailAddress("windows199@abv.bg", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);

            //var statusCode = response.StatusCode;

            //return this.Json(statusCode);
        }
    }
}
