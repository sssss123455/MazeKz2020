﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Account;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    public class AccountController : Controller
    {
        private CitizenUserRepository citizenUserRepository;
        private AdressRepository adressRepository;
        private IWebHostEnvironment hostEnvironment;
        private IMapper mapper;
        private UserService userService;

        public AccountController(CitizenUserRepository citizenUserRepository,
            IMapper mapper,
            IWebHostEnvironment hostEnvironment, AdressRepository adressRepository, UserService userService)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
            this.adressRepository = adressRepository;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            viewModel.ReturnUrl = Request.Query["ReturnUrl"];

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = citizenUserRepository
                .GetUserByNameAndPassword(loginViewModel.Login, loginViewModel.Password);
            if (user == null)
            {
                return View(loginViewModel);
            }

            //Строки в документе
            var recordId = new Claim("Id", user.Id.ToString());
            var recordName = new Claim(ClaimTypes.Name, user.Login);
            var position = "user";
            if (user.Position != null)
            {
                position = user.Position;
            }
            var recordPosition = new Claim("Position", position);

            var recordAuthMethod = new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod);

            //Страница в документе
            var page = new List<Claim>() { recordId, recordName, recordPosition, recordAuthMethod };

            //Документ
            var claimsIdentity = new ClaimsIdentity(page, Startup.AuthMethod);

            //Пользователь с точки зрения .net
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(loginViewModel.ReturnUrl);
            }


        }

        [HttpGet]
        public IActionResult Registration()
        {
            var viewModel = new RegistrationViewModel()
            {
                Login = "Test",
                Password = "Test"
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = mapper.Map<CitizenUser>(viewModel);
            citizenUserRepository.Save(user);
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var user = userService.GetCurrentUser();
            var viewModel = mapper.Map<ProfileViewModel>(user);
            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel profileViewModel)
        {
            var citizen = mapper.Map<CitizenUser>(profileViewModel);
            citizenUserRepository.Save(citizen);
            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvatar(ProfileViewModel viewModel)
        {
            var fileName = viewModel.Avatar.FileName;
            var wwwrootPath = hostEnvironment.WebRootPath;
            var path = @$"{wwwrootPath}\image\avatar\{fileName}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await viewModel.Avatar.CopyToAsync(fileStream);
            }

            var citizen = citizenUserRepository.Get(viewModel.Id);
            citizen.AvatarUrl = $"/image/avatar/{fileName}";
            citizenUserRepository.Save(citizen);

            return RedirectToAction("Profile", new { id = viewModel.Id });
        }

        [HttpGet]
        public IActionResult AddAdress(long userId)
        {
            var viewModel = new AdressViewModel()
            {
                OwnerId = userId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddAdress(AdressViewModel adressViewModel)
        {
            var adress = mapper.Map<Adress>(adressViewModel);
            var user = citizenUserRepository.Get(adressViewModel.OwnerId);

            adress.Owner = user;

            adressRepository.Save(adress);

            return RedirectToAction("Profile", new { id = adressViewModel.OwnerId });
        }
    }
}
