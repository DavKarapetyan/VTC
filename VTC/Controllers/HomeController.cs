using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Dynamic;
using VTC.BLL.Services.Interfaces;
using VTC.Models;
using VTC.Common.ViewModels;
using VTC.DataAccess.Entities;

namespace VTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService _mainService;
        private readonly IEventService _eventService;
        private readonly INewsService _newsService;
        private readonly IServiceService _seviceService;
        private readonly ITrainingService _trainingService;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IMainService mainService,
            IEventService eventService,
            INewsService newsService,
            IServiceService seviceService,
            ITrainingService trainingService,
            IStringLocalizer<HomeController> localizer)
        {
            _mainService = mainService;
            _eventService = eventService;
            _newsService = newsService;
            _seviceService = seviceService;
            _trainingService = trainingService;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeText = _localizer["Welcome"];

            return View();
        }

        public IActionResult AboutUs()
        {
            var about = _mainService.GetAboutUs();

            return View(about);
        }

        public IActionResult ContactUs()
        {
            var contactUs = _mainService.GetConactUs();

            return View(contactUs);
        }

        public async Task<IActionResult> Events()
        {
            var events = await _eventService.GetAll();

            return View(events);
        }

        public async Task<IActionResult> EventPage(int id)
        {
            var evnt = await _eventService.GetById(id);

            return View(evnt);
        }

        public async Task<IActionResult> Service()
        {
            var services = await _seviceService.GetAll();

            return View(services);
        }


        public async Task<IActionResult> News()
        {
            var news = await _newsService.GetAll();

            return View(news);
        }

        public async Task<IActionResult> NewsPage(int id)
        {
            var news = await _newsService.GetById(id);

            return View(news);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Trainings(int statusId) {
            
            var trainings = _trainingService.GetAll(statusId);
            
            return View(trainings);
        }
        
        public async Task<IActionResult> TrainingPage(int trainingId) {

            TrainingViewModel training = new();
            training = await _trainingService.GetById(trainingId);
            training.Topics = _trainingService.TrainingTopics(trainingId);
            return View(training);
        }

        public async Task<IActionResult> AddTrainingParticipant(int? id)
        {
            if (id.HasValue)
            {
                var trainingPart = await _trainingService.GetById(id.Value);
                return View(trainingPart);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainingParticipant(TrainingParticipantViewModel model)
        {
            

            _trainingService.AddTrainingPart(model);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}