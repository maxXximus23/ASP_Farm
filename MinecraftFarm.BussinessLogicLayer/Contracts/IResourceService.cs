using MinecraftFarm.BussinessLogicLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Contracts
{
    public interface IResourceService
    {
        public Task<IReadOnlyCollection<ResourceDto>> GetAll();

        public void Add(ResourceDto resourceDto);

        public Task<ResourceDto> GetById(int id);

        public void Update(ResourceDto resourceDto);

        public void DeleteById(int id);

        public Task<ICollection<PlayerResourceDto>> GetPlayerResourcesById(int id);
    }
}