using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = MinecraftFarm.ViewModels.Action;

namespace MinecraftFarm.Controllers
{
    public class AdminController : Controller
    {
        private readonly IResourceService _resourceService;

        private readonly IPlayersService _playersService;

        private readonly IMapper _mapper;
        public AdminController(IResourceService resourceService, IPlayersService playersService, IMapper mapper)
        {
            _resourceService = resourceService;
            _playersService = playersService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return View("~/Views/Account/Login.cshtml");
        }

        #region Resource
        public async Task<IActionResult> Resources()
        {
            var dtos = await _resourceService.GetAll();
            var models = _mapper.Map<IReadOnlyCollection<ResourceDto>, IReadOnlyCollection<ResourceViewModel>>(dtos);
            return View(models);
        }

        [HttpGet]
        public IActionResult AddResource()
        {
            var model = new ResourceViewModel();
            model.Action = Action.Add;
            return View("AddOrEditResource", model);
        }

        [HttpPost]
        public IActionResult AddResource(ResourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ResourceDto>(model);
                _resourceService.Add(dto);
                return RedirectToAction(nameof(Resources));
            }
            return View("AddOrEditResource", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditResource(int id)
        {
            var dto = await _resourceService.GetById(id);
            var model = _mapper.Map<ResourceViewModel>(dto);
            model.Action = Action.Edit;
            return View("AddOrEditResource", model);
        }

        [HttpPost]
        public IActionResult EditResource(ResourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ResourceDto>(model);
                _resourceService.Update(dto);
                return RedirectToAction(nameof(Resources));
            }
            return View("AddOrEditResource", model);
        }

        [HttpPost]
        public IActionResult DeleteResource(int id)
        {
            _resourceService.DeleteById(id);
            return Ok();
        }
        #endregion

        public async Task<IActionResult> Players()
        {
            var dtos = await _playersService.GetAll();
            var models = _mapper.Map<IReadOnlyCollection<PlayerDto>, IReadOnlyCollection<PlayerViewModel>>(dtos);
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var dto = await _playersService.GetById(id);
            var model = _mapper.Map<PlayerDto, PlayerViewModel>(dto);
            model.Action = Action.Edit;
            return View("EditPlayer", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditPlayerResources(int id)
        {
            var dtos = await _resourceService.GetPlayerResourcesById(id);
            var model = _mapper.Map<ICollection<PlayerResourceDto>, ICollection<PlayerResourceViewModel>>(dtos);
            return View("EditPlayerResources", model);
        }

        [HttpPost]
        public IActionResult EditPlayerResources(ICollection<PlayerResourceViewModel> model)
        {
            var dtos = _mapper.Map<ICollection<PlayerResourceViewModel>, ICollection<PlayerResourceDto>>(model).ToArray();
            _playersService.ChangeResourceQuantities(dtos);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<PlayerViewModel, PlayerDto>(model);
                await _playersService.Update(dto);
                return RedirectToAction(nameof(Players));
            }
            return View("EditPlayer", model);
        }

        [HttpPost]
        public IActionResult ResetPasswordPlayer(int id)
        {
            _playersService.ResetPasswordById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult BanPlayer(int id)
        {
            _playersService.BanById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult UnbanPlayer(int id)
        {
            _playersService.UnbanById(id);
            return Ok();
        }
    }
}