using MinecraftFarm.BussinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Contracts
{
    public interface IResourceService
    {
        public Task<IReadOnlyCollection<ResourceDto>> GetAll();

        public Task<ResourceDto> GetById(int id);

        public void Update(ResourceDto resourceDto);

        public void DeleteById(int id);
    }
}
