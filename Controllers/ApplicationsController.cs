using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using WeCount.Data.Services;
using WeCount.Data.ViewModels;
using WeCount.Models;

namespace WeCount.Controllers
{
    [Route("/")]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationsService _applicationsService;
        public ApplicationsController(ApplicationsService applicationsService)
        {
            this._applicationsService = applicationsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("apply")]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpGet("applications")]
        public IActionResult Applications()
        {
            // List<Application> _applications = _applicationsService.GetEntities();

            ViewBag.Applications = _applicationsService.GetEntities();
            return View();
        }

        [HttpPost("apply")]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([Bind("FirstName, LastName, Mail, Phone, StudyLevel, YearsOfExperinces, LastJob")]Application application)
        {
            if (ModelState.IsValid)
            {
                Application _application = _applicationsService.InsertEntity(application);

                string slag = _application.Slag;
                return Redirect($"/apply/resume/{slag}");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("apply/resume/{slag}")]
        public IActionResult ApplyResume(string slag)
        {
            return View();
        }

        [HttpPost("apply/resume/{slag}")]
        [ValidateAntiForgeryToken]
        public IActionResult ApplyResume([Bind("ResumeFile")]ResumeVM resumeVM, string slag, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(resumeVM, slag, webHostEnvironment);
                _applicationsService.InsertResume(slag, uniqueFileName);
                return Redirect($"/application/details/{slag}");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("display/application/{slag}")]
        public IActionResult DisplayApplication(string slag)
        {
            Application _application = _applicationsService.GetEntity(slag);
            return View(_application);
        }

        [HttpGet("application/details/{slag}")]
        public IActionResult ApplicationDetails(string slag)
        {
            Application _application = _applicationsService.GetEntity(slag);
            return View(_application);
        }

        private string UploadedFile(ResumeVM resumeVM, string slag, IWebHostEnvironment webHostEnvironment)
        {
            string relativePath = "";
            if (resumeVM.ResumeFile != null)
            {
                var _uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, $"Resumes\\{slag}");
                if (!Directory.Exists(_uploadsFolder))
                {
                    Directory.CreateDirectory(_uploadsFolder);
                }

                string filePath = Path.Combine(_uploadsFolder, resumeVM.ResumeFile.FileName);
                relativePath = Path.Combine($"Resumes\\{slag}", resumeVM.ResumeFile.FileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    resumeVM.ResumeFile.CopyTo(fileStream);
                }
            }

            return relativePath;
        }

        [HttpPost("application/delete/{slag}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteApplication(string slag)
        {
            _applicationsService.DeleteEntity(slag);
            return Redirect("/applications");
        }

        [HttpPost("application/search")]
        [ValidateAntiForgeryToken]
        public IActionResult SearchApplications(SearchVM searchVM)
        {
            if (ModelState.IsValid)
                ViewBag.Applications = _applicationsService.SearchEntity(searchVM.SearchText);
            else
                ViewBag.Applications = _applicationsService.GetEntities();

            return View("~/Views/Applications/Applications.cshtml");
        }
    }
}
