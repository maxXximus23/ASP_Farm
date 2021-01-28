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
    }
}
