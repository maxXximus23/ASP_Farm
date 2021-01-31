using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftFarm.Controllers
{
    public class AdminController : Controller
    {
        private readonly IResourceService _resourceService;

        private readonly IMapper _mapper;
        public AdminController(IResourceService resourceService, IMapper mapper)
        {
            _resourceService = resourceService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

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
            if(ModelState.IsValid)
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
    }
}
