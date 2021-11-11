namespace AutoHub.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoHub.Services.Messaging;
    using AutoHub.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

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
            return this.Json(model);
        }
    }
}
