using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditRepository _auditRepository;
        public AuditController(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public IActionResult AuditSearch()
        {
            var model = new AuditViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AuditSearch(AuditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var report = _auditRepository.GetAuditReport(model).Result;

                ViewBag.Filter = model;
                return View("AuditReport", report);
            }

            return View(model);

        }
    }

}

