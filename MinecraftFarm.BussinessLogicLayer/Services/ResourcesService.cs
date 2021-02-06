using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Contexts;
using MinecraftFarm.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Services
{
    public class ResourcesService : IResourceService
    {
        private readonly DatabaseContext _databaseContext;

        private readonly IMapper _mapper;

        public ResourcesService(IMapper mapper, DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public void Add(ResourceDto resourceDto)
        {
            var newResource = _mapper.Map<Resource>(resourceDto);
            _databaseContext.Resources.Add(newResource);
            _databaseContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var resource = _databaseContext.Resources.Single(resource => resource.Id == id);

            _databaseContext.Resources.Remove(resource);
            _databaseContext.SaveChanges();
        }

        public async Task<IReadOnlyCollection<ResourceDto>> GetAll()
        {
            var dtos = await _databaseContext.Resources
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<IReadOnlyCollection<ResourceDto>>(dtos);
        }

        public async Task<ResourceDto> GetById(int id)
        {
            var resource = await _databaseContext.Resources
                .AsNoTracking()
                .SingleAsync(resource => resource.Id == id);

            return _mapper.Map<ResourceDto>(resource);
        }

        public async Task<ICollection<PlayerResourceDto>> GetPlayerResourcesById(int id)
        {
            var resources = await _databaseContext.PlayerResources
                .AsNoTracking()
                .Include(resources => resources.Resource)
                .Where(resource => resource.PlayerId == id)
                .ToArrayAsync();

            return _mapper.Map<ICollection<PlayerResourceDto>>(resources);
        }

        public void Update(ResourceDto resourceDto)
        {
            var resource = _databaseContext.Resources
                .AsNoTracking()
                .Single(resource => resource.Id == resourceDto.Id);

            resource = _mapper.Map<Resource>(resourceDto);

            _databaseContext.Update(resource);
            _databaseContext.SaveChanges();
        }
    }
}
