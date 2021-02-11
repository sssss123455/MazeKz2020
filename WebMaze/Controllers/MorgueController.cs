using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebMaze.Controllers.CustomAttribute;
using WebMaze.DbStuff.Model.Morgue;
using WebMaze.DbStuff.Repository;
using WebMaze.DbStuff.Repository.Morgue;
using WebMaze.Models.Morgue;
using WebMaze.Services;

namespace WebMaze.Controllers
{

    public class MorgueController : Controller
    {
        private IMapper mapper;
        private RegisterCardForMorgueRepository registerCardForMorgueRepository;
        private ForensicReportRepository forensicReportRepository;
        private BodyIdentificationReportRepository bodyIdentificationReportRepository;
        private CitizenUserRepository citizenUserRepository;
        private UserService userService;
        private RitualServiceRepository ritualServiceRepository;
        private IWebHostEnvironment hostEnvironment;
        private FuneralRepository funeralRepository;
        private ContentForMorgueRepository contentForMorgueRepository;
        public MorgueController(IMapper mapper, RegisterCardForMorgueRepository registerCardForMorgueRepository,
            ForensicReportRepository forensicReportRepository, BodyIdentificationReportRepository bodyIdentificationReportRepository,
            CitizenUserRepository citizenUserRepository, UserService userService, 
            RitualServiceRepository ritualServiceRepository, IWebHostEnvironment hostEnvironment,
            FuneralRepository funeralRepository, ContentForMorgueRepository contentForMorgueRepository)
        {
            this.registerCardForMorgueRepository = registerCardForMorgueRepository;
            this.mapper = mapper;
            this.forensicReportRepository = forensicReportRepository;
            this.bodyIdentificationReportRepository = bodyIdentificationReportRepository;
            this.citizenUserRepository = citizenUserRepository;
            this.userService = userService;
            this.ritualServiceRepository = ritualServiceRepository;
            this.hostEnvironment = hostEnvironment;
            this.funeralRepository = funeralRepository;
            this.contentForMorgueRepository = contentForMorgueRepository;
        }
        public IActionResult Index()
        {
            var viewModel = new ContentForMorgueViewModel();
            var content = contentForMorgueRepository.GetContent();
            viewModel = mapper.Map<ContentForMorgueViewModel>(content);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpGet]
        public IActionResult EditContent()
        {
            var viewModel = new ContentForMorgueViewModel();
            var content = contentForMorgueRepository.GetContent();
            viewModel = mapper.Map<ContentForMorgueViewModel>(content);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public async Task<IActionResult> EditContent(ContentForMorgueViewModel viewModel)
        {
           
             var content = mapper.Map<ContentForMorgue>(viewModel);
            if (viewModel.Photo!=null)
            {
                var fileName = viewModel.Photo.FileName;
                var wwwrootPath = hostEnvironment.WebRootPath;
                var path = @$"{wwwrootPath}\image\Morgue\{fileName}";
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.Photo.CopyToAsync(fileStream);
                }
                content.UrlPhoto = $"/image/Morgue/{fileName}";
            }
            contentForMorgueRepository.Save(content);
            return RedirectToAction("Index","Morgue");
        }
        [IsMorgue]
        public IActionResult ShowCorpse()
        {
            var listCorpse = registerCardForMorgueRepository.GetAll();
            var viewModel = mapper.Map<List<RegisterCardForMorgueViewModel>>(listCorpse);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpGet]
        public IActionResult WriteReport(long corpseId)
        {
            var viewModel = new ForensicReportViewModel();
            viewModel.CorpseId = corpseId;
            var pathologist = mapper.Map<CitizenUserViewModel>(userService.GetCurrentUser());
            viewModel.Pathologist = pathologist;
            viewModel.DateOfForensic = DateTime.Now;
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public IActionResult WriteReport(ForensicReportViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.IsReportRecorded = true;
            var expert = userService.GetCurrentUser();
            var user = citizenUserRepository.Get(expert.Id);
            viewModel.Pathologist = mapper.Map<CitizenUserViewModel>(user);
            var report = mapper.Map<ForensicReport>(viewModel);
            forensicReportRepository.Save(report);
            return RedirectToAction("ShowReport", "Morgue", new { corpseId = viewModel.CorpseId });
        }
        [IsMorgue]
        public IActionResult ShowReport(long corpseId)
        {
            var corpse = registerCardForMorgueRepository.Get(corpseId);
            var viewModel = new DataForShowReportViewModel();
            viewModel.Corpse = mapper.Map<RegisterCardForMorgueViewModel>(corpse);
            viewModel.Report = mapper.Map<ForensicReportViewModel>(corpse.ForensicReport);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpGet]
        public IActionResult SetIdentificationDate(long corpseId)
        {
            var viewModel = new IdentificationDateViewModel();
            viewModel.CorpseId = corpseId;
            viewModel.DateOfIdentification = DateTime.Now;
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public IActionResult SetIdentificationDate(IdentificationDateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.IsDateSet = true;
            var date = mapper.Map<BodyIdentificationReport>(viewModel);
            bodyIdentificationReportRepository.Save(date);
            return RedirectToAction("ShowCorpse", "Morgue");
        }
        [IsMorgue]
        [HttpGet]
        public IActionResult IndentificationCorpse(long corpseId)
        {
            var viewModel = mapper.Map<BodyIdentificationReportViewModel>(registerCardForMorgueRepository.Get(corpseId).BodyIdentificationReport);
            if (registerCardForMorgueRepository.Get(corpseId).Corpse != null)
            {
                viewModel.UserId = registerCardForMorgueRepository.Get(corpseId).Corpse.Id;
            }
            viewModel.DateOfIdentification = DateTime.Now;
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public IActionResult IndentificationCorpse(BodyIdentificationReportViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else if (viewModel.IsIdentified)
            {

                viewModel.IsDateSet = true;
                var data = mapper.Map<BodyIdentificationReport>(viewModel);
                data.PoliceOfficer = citizenUserRepository.Get(viewModel.PoliceOfficerId);
                data.IdentifyingPerson = citizenUserRepository.Get(viewModel.IdentifyingPersonId);
                var card = registerCardForMorgueRepository.Get(viewModel.CorpseId);
                var user = citizenUserRepository.Get(viewModel.UserId);
                card.Corpse = user;
                user.IsDead = true;
                citizenUserRepository.Save(user);
                registerCardForMorgueRepository.Save(card);
                bodyIdentificationReportRepository.Save(data);
                return RedirectToAction("ShowDataByCorpse", "Morgue", new { corpseId = viewModel.CorpseId });
            }
            else
            {
                var report = bodyIdentificationReportRepository.GetReport(viewModel.CorpseId);
                bodyIdentificationReportRepository.Delete(report.Id);
                return RedirectToAction("ShowCorpse", "Morgue");
            }

        }
        [IsMorgue]
        public IActionResult ShowDataByCorpse(long corpseId)
        {
            var corpse = registerCardForMorgueRepository.Get(corpseId);
            var viewModel = new DataByCorpseViewModel();
            viewModel.Corpse = mapper.Map<RegisterCardForMorgueViewModel>(corpse);
            viewModel.Report = mapper.Map<ForensicReportViewModel>(corpse.ForensicReport);
            viewModel.Identification = mapper.Map<BodyIdentificationReportViewModel>(corpse.BodyIdentificationReport);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpGet]
        public IActionResult EditRitualService(long serviceId)
        {
            var service = ritualServiceRepository.Get(serviceId);
            var viewModel = mapper.Map<RitualServiceViewModel>(service);
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public async Task<IActionResult> EditRitualService(RitualServiceViewModel viewModel)
        {
            var service = mapper.Map<RitualService>(viewModel);
            if (viewModel.Photo!=null)
            {
                var fileName = viewModel.Photo.FileName;
                var wwwrootPath = hostEnvironment.WebRootPath;
                var path = @$"{wwwrootPath}\image\Morgue\{fileName}";
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.Photo.CopyToAsync(fileStream);
                }
                service.UrlPhoto = $"/image/Morgue/{fileName}";
            }
            
            ritualServiceRepository.Save(service);
            return RedirectToAction("ShowRitualService", "Morgue");
        }
        [HttpGet]
        [IsMorgue]
        public IActionResult AddRitualService()
        {
            var viewModel = new RitualServiceViewModel();
            return View(viewModel);
        }
        [IsMorgue]
        [HttpPost]
        public async Task<IActionResult> AddRitualService(RitualServiceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var fileName = viewModel.Photo.FileName;
            var wwwrootPath = hostEnvironment.WebRootPath;
            var path = @$"{wwwrootPath}\image\Morgue\{fileName}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await viewModel.Photo.CopyToAsync(fileStream);
            }
            var service = mapper.Map<RitualService>(viewModel);
            service.UrlPhoto = $"/image/Morgue/{fileName}";
            ritualServiceRepository.Save(service);
            return RedirectToAction("ShowRitualService","Morgue");
        }
        public IActionResult ShowRitualService()
        {
            var services = ritualServiceRepository.GetAll();
            var viewModel = mapper.Map<List<RitualServiceViewModel>>(services);
            var user = userService.GetCurrentUser();
            return View(viewModel);
        }
        [Authorize]
        public IActionResult Home()
        {
            var user = userService.GetCurrentUser();
            var allCorpses=registerCardForMorgueRepository.GetListOfAllCorpsesOfIdentifier(user.Id);
            var viewModel = mapper.Map<List<YourCorpsesViewModel>>(allCorpses);
            return View(viewModel);
        }
        [Authorize]
        public IActionResult ChooseService(long corpseId)
        {
            var service = ritualServiceRepository.GetAll();
            var viewModel = mapper.Map<List<RitualServiceViewModel>>(service);
            ViewBag.corpseId = corpseId;
            return View(viewModel);
        }
        [Authorize]
        [HttpGet]
        public IActionResult OrderFuneral(long corpseId,long serviceId)
        {
            var viewModel = new FuneralViewModel();
            viewModel.RitualServiceId = serviceId;
            viewModel.CorpseId = corpseId;
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult OrderFuneral(FuneralViewModel viewModel)
        {
            var user = citizenUserRepository.Get(userService.GetCurrentUser().Id);
            var service = ritualServiceRepository.Get(viewModel.RitualServiceId);
            user.Balance -= service.Price;
            citizenUserRepository.Save(user);
            var funeral = mapper.Map<Funeral>(viewModel);
            funeral.RitualService = service;
            funeralRepository.Save(funeral);
            return RedirectToAction("Index", "Morgue");
        }
        [IsMorgue]
        public IActionResult ShowFuneral()
        {
            var corpse = registerCardForMorgueRepository.GetListForFuneral();
            var viewModel = new List<ListOfFuneralViewModel>();
            foreach (var item in corpse)
            {
                viewModel.Add(new ListOfFuneralViewModel
                {
                    NameCorpse = item.Corpse.FirstName,
                    SurnameCorpse = item.Corpse.LastName,
                    DateOfBirth = item.Corpse.BirthDate,
                    DateOfDeath = item.DateOfDeath,
                    Funeral=mapper.Map<FuneralViewModel>(item.Funeral),
                    Service=mapper.Map<RitualServiceViewModel>(ritualServiceRepository.Get(item.Funeral.RitualService.Id))
                });
            }
            return View(viewModel);
        }
        [IsPolice]
        public IActionResult ShowListCorpsAutopsy()
        {
            var corpses = registerCardForMorgueRepository.GetListCorpsAutopsy();
            var viewModel = mapper.Map<List<RegisterCardForMorgueViewModel>>(corpses);
            return View(viewModel);
        }
        [IsPolice]
        public IActionResult ShowReportAutopsy(long corpseId)
        {
            var corpse = registerCardForMorgueRepository.Get(corpseId);
            var viewModel = new DateByAutopsyViewModel();
            viewModel.Corpse = mapper.Map<RegisterCardForMorgueViewModel>(corpse);
            viewModel.Report = mapper.Map<ForensicReportViewModel>(corpse.ForensicReport);
            return View(viewModel);
        }
    }
}
