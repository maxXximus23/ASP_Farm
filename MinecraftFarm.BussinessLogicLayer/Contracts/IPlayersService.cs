using MinecraftFarm.BussinessLogicLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Contracts
{
    public interface IPlayersService
    {
        public Task<IReadOnlyCollection<PlayerDto>> GetAll();

        public Task<PlayerDto> GetById(int id);

        public Task Update(PlayerDto playerDto);

        public void ChangeResourceQuantities(PlayerResourceDto[] playerResourceDtos);

        public void DeleteById(int id);

        public void Add(PlayerDto playerDto);

        public void ResetPasswordById(int id);

        public void BanById(int id);

        public void UnbanById(int id);
    }
}