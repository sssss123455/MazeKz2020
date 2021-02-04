using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.Controllers.CustomAttribute;
using WebMaze.DbStuff.Model.Morgue;
using WebMaze.DbStuff.Repository;
using WebMaze.DbStuff.Repository.Morgue;
using WebMaze.Models.Morgue;

namespace WebMaze.Controllers
{

    public class MorgueController : Controller
    {
        private IMapper mapper;
        private RegisterCardForMorgueRepository registerCardForMorgueRepository;
        private ForensicReportRepository forensicReportRepository;
        private BodyIdentificationReportRepository bodyIdentificationReportRepository;
        private IHttpContextAccessor httpContextAccessor;
        private CitizenUserRepository citizenUserRepository;
        public MorgueController(IMapper mapper, RegisterCardForMorgueRepository registerCardForMorgueRepository,
            ForensicReportRepository forensicReportRepository, BodyIdentificationReportRepository bodyIdentificationReportRepository,
            IHttpContextAccessor httpContextAccessor, CitizenUserRepository citizenUserRepository)
        {
            this.registerCardForMorgueRepository = registerCardForMorgueRepository;
            this.mapper = mapper;
            this.forensicReportRepository = forensicReportRepository;
            this.bodyIdentificationReportRepository = bodyIdentificationReportRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.citizenUserRepository = citizenUserRepository;
        }
        [IsMorgue]
        [Authorize]
        public IActionResult Index()
        {

            return View();
        }
        [Authorize]
        [IsMorgue]
        public IActionResult ShowCorpse()
        {
            var listCorpse = registerCardForMorgueRepository.GetAll();
            var viewModel = mapper.Map<List<RegisterCardForMorgueViewModel>>(listCorpse);
            return View(viewModel);
        }
        [IsMorgue]
        [Authorize]
        [HttpGet]
        public IActionResult WriteReport(long corpseId)
        {
            var viewModel = new ForensicReportViewModel();
            viewModel.CorpseId = corpseId;
            var idStr = httpContextAccessor.HttpContext.
                User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            var expertId = int.Parse(idStr);
            var expert = citizenUserRepository.Get(expertId);
            viewModel.Pathologist = citizenUserRepository.Get(expertId);
            viewModel.DateOfForensic = DateTime.Now;
            return View(viewModel);
        }
        [IsMorgue]
        [Authorize]
        [HttpPost]
        public IActionResult WriteReport(ForensicReportViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.IsReportRecorded = true;
            var idStr = httpContextAccessor.HttpContext.
                User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            var expertId = int.Parse(idStr);
            var expert = citizenUserRepository.Get(expertId);
            viewModel.Pathologist = citizenUserRepository.Get(expertId);
            var report = mapper.Map<ForensicReport>(viewModel);
            forensicReportRepository.Save(report);
            return RedirectToAction("ShowReport", "Morgue", new { corpseId = viewModel.CorpseId });
        }
        [IsMorgue]
        [Authorize]
        public IActionResult ShowReport(long corpseId)
        {
            var corpse = registerCardForMorgueRepository.Get(corpseId);
            var viewModel = new DataForShowReportViewModel();
            viewModel.Corpse = mapper.Map<RegisterCardForMorgueViewModel>(corpse);
            viewModel.Report = mapper.Map<ForensicReportViewModel>(corpse.ForensicReport);
            return View(viewModel);
        }
        [IsMorgue]
        [Authorize]
        [HttpGet]
        public IActionResult SetIdentificationDate(long corpseId)
        {
            var viewModel = new IdentificationDateViewModel();
            viewModel.CorpseId = corpseId;
            viewModel.DateOfIdentification = DateTime.Now;
            return View(viewModel);
        }
        [IsMorgue]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
                bodyIdentificationReportRepository.RemoveIdentificationDate(viewModel.CorpseId);
                return RedirectToAction("ShowCorpse", "Morgue");
            }

        }
        [IsMorgue]
        [Authorize]
        public IActionResult ShowDataByCorpse(long corpseId)
        {
            var corpse = registerCardForMorgueRepository.Get(corpseId);
            var viewModel = new DataByCorpseViewModel();
            viewModel.Corpse = mapper.Map<RegisterCardForMorgueViewModel>(corpse);
            viewModel.Report = mapper.Map<ForensicReportViewModel>(corpse.ForensicReport);
            viewModel.Identification = mapper.Map<BodyIdentificationReportViewModel>(corpse.BodyIdentificationReport);
            return View(viewModel);
        }
    }
}
