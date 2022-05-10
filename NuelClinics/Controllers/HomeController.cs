using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using NuelClinics.Helpers;
using NuelClinics.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NuelClinics.Controllers
{
    public class HomeController : Controller
    {
        private IAppointmentRepository _appRepo;
        private IServiceRepository _serveRepo;

        public HomeController(IAppointmentRepository appRepository, IServiceRepository serveRepository)
        {
            this._appRepo = appRepository;
            this._serveRepo = serveRepository;
        }

        public ActionResult Index()
        {
            AppointmentViewModel model = new AppointmentViewModel();

            model.Appointments = _appRepo.GetAllAppointments;

            model.Services = _serveRepo.GetAllServices;

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var appointment = _appRepo.GetAppointmentById(id);
            return View(appointment);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var services = _serveRepo.GetAllServices;
            var service_list = new List<SelectListItem>();
            foreach (var serve in services)
            {
                service_list.Add(new SelectListItem { Value = serve.ID.ToString(), Text = serve.Name });
            }
            ViewBag.service_list = service_list;

            return View(new Appointment());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Appointment appointment)
        {
            try
            {

                string useremail = "orjiemmanueleni@gmail.com";
                string senderpassword = "evkvtmonpsmemycc";

                var send = new EmailPayload
                {
                    Mailbody = "Thank you for scheduling an appointment on NuelClinics. We are happy to attend to you",
                    Subject = "Appointment Schedule",
                    SenderEmail = useremail,
                    SenderPassword = senderpassword,
                    ReceiverEmail = appointment.Email,
                    SmtpPort = 587,
                    SmtpHost = "smtp.gmail.com"
                };

                var email = new EmailHelper();
                var t = await email.SendEmailAsync(send);

                if (ModelState.IsValid)
                {
                    _appRepo.SaveAppointment(appointment);

                    return RedirectToAction("Index", t);
                }
                
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(appointment);
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
    }
}