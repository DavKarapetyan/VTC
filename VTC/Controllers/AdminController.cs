﻿using Microsoft.AspNetCore.Mvc;
using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using VTC.DataAccess.Data;
using VTC.DataAccess.Entities;

namespace VTC.Controllers
{
    public class AdminController : Controller
    {
        private readonly VTCContext _context;
        private readonly IMainService _mainService;
        private readonly IEventService _eventService;
        private readonly IServiceService _serviceService;
        private readonly INewsService _newsService;
        private readonly ITrainingService _trainingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IMainService mainService,
            IEventService eventService,
            IServiceService serviceService,
            INewsService newsService,
            ITrainingService trainingService,
            IWebHostEnvironment webHostEnvironment,
            VTCContext context
            )
        {
            _mainService = mainService;
            _serviceService = serviceService;
            _newsService = newsService;
            _eventService = eventService;
            _trainingService = trainingService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            var aboutUs = _mainService.GetAboutUs();
            return View(aboutUs);
        }

        [HttpPost]
        public async Task<IActionResult> AboutUs(AboutUsViewModel model)
        {
            await _mainService.AboutUsEdit(model);

            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            var contactUs = _mainService.GetConactUs();
            return View(contactUs);
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsViewModel model)
        {
            await _mainService.ContactUsEdit(model);

            return View();
        }
        

        public IActionResult AddGalleryImage() {
            return View(_context.GalleryImages.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddGalleryImage(IFormFile uploadedFile) {
            if (uploadedFile != null) {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create)) {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                GalleryImage file = new GalleryImage() { Name = uploadedFile.FileName, Path = path };
                _context.GalleryImages.Add(file);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        #region Event

        [HttpGet]
        public async Task<IActionResult> Events()
        {
            var events = await _eventService.GetAll();

            return View(events);
        }

        public async Task<IActionResult> ManageEvent(int? id)
        {
            if (id.HasValue)
            {
                var events = await _eventService.GetById(id.Value);
                return PartialView("_ManageEvent", events);
            }

            return PartialView("_ManageEvent");
        }

        [HttpPost]
        public async Task<IActionResult> ManageEvent(EventViewModel model)
        {
            if (model.Id == 0)
            {
                await _eventService.Add(model);
            }
            else
            {
                await _eventService.Edit(model);
            }

            return RedirectToAction("Events");
        }

        public async Task<IActionResult> DeleteEvent()
        {
            return PartialView("_DeleteEvent");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.Remove(id);

            return RedirectToAction("Events");
        }
        #endregion

        #region Service 

        [HttpGet]
        public async Task<IActionResult> Services()
        {
            var service = await _serviceService.GetAll();

            return View(service);
        }

        public async Task<IActionResult> ManageService(int? id)
        {
            if (id.HasValue)
            {
                var service = await _serviceService.GetById(id.Value);
                return PartialView("_ManageService", service);
            }

            return PartialView("_ManageService");
        }

        [HttpPost]
        public async Task<IActionResult> ManageService(ServiceViewModel model)
        {
            if (model.Id == 0)
            {
                await _serviceService.Add(model);
            }
            else
            {
                await _serviceService.Edit(model);
            }

            return RedirectToAction("Services");
        }

        public async Task<IActionResult> DeleteService()
        {
            return PartialView("_DeleteService");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.Remove(id);

            return RedirectToAction("Services");
        }

        #endregion

        #region TrainingParticipant
        [HttpGet]
        public IActionResult TrainingParticipant() {
            var trainingParticipants = _trainingService.trainingParticipants();
            return View(trainingParticipants);
        }

        #endregion

        #region Training
        
        public IActionResult Trainings() {
            var trainings = _trainingService.GetAll(1);
            return View(trainings);
        }
        public IActionResult TrainingsStudent()
        {
            var trainings = _trainingService.GetAll(2);
            return View(trainings);
        }
        public IActionResult TrainingsUSAID()
        {
            var trainings = _trainingService.GetAll(3);
            return View(trainings);
        }
        #endregion

        #region News 

        [HttpGet]
        public async Task<IActionResult> News()
        {
            var news = await _newsService.GetAll();

            return View(news);
        }

        public async Task<IActionResult> ManageNews(int? id)
        {
            if (id.HasValue)
            {
                var news = await _newsService.GetById(id.Value);
                return PartialView("_ManageNews", news);
            }

            return PartialView("_ManageNews");
        }

        [HttpPost]
        public async Task<IActionResult> ManageNews(NewsViewModel model)
        {
            if (model.Id == 0)
            {
                await _newsService.Add(model);
            }
            else
            {
                await _newsService.Edit(model);
            }

            return RedirectToAction("News");
        }

        public async Task<IActionResult> DeleteNews()
        {
            return PartialView("_DeleteNews");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNews(int id)
        {
            await _newsService.Remove(id);

            return RedirectToAction("News");
        }

        #endregion
    }
}
