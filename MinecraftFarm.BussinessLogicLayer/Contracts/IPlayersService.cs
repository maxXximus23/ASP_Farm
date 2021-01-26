using MinecraftFarm.BussinessLogicLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Contracts
{
    public interface IPlayersService
    {
        public Task<IReadOnlyCollection<PlayerDto>> GetAll();

        public Task<PlayerDto> GetById(int id);

        public void Update(PlayerDto playerDto);

        public void ChangeResourceQuantities(PlayerResourceDto[] playerResourceDtos);

        public void DeleteById(int id);
    }
}