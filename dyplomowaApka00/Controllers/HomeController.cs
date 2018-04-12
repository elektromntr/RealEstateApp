using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dyplomowaApka00.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace dyplomowaApka00.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmailForm()
        {
            var model = new EmailFormModel();
            return PartialView("_Kontakt", model);
        }

        //email form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Zadzwoń do {1}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("bartosz@ablab.pl"));  // replace with valid value 
                message.From = new MailAddress("sogoSender@outlook.com");  // replace with valid value
                message.Subject = "Kontakt ze strony";
                message.Body = string.Format(body, model.FromName, model.FromPhone, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sogoSender@outlook.com",  // replace with valid value
                        Password = "****"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
