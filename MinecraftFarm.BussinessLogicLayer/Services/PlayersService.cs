using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly DatabaseContext _databaseContext;

        private readonly IMapper _mapper;

        public PlayersService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public void ChangeResourceQuantities(PlayerResourceDto[] playerResourceDtos)
        {
            var dtoIds = playerResourceDtos.Select(dto => dto.Id).ToArray();
            var existingResources = _databaseContext.PlayerResources
                .Where(playerResource => dtoIds.Contains(playerResource.Id))
                .OrderBy(playerResource => playerResource.Id)
                .ToArray();

            playerResourceDtos = playerResourceDtos.OrderBy(dto => dto.Id).ToArray();

            for (int i = 0; i < existingResources.Length; i++)
            {
                existingResources[i].Quantity = playerResourceDtos[i].Quantity;
            }

            _databaseContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PlayerDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PlayerDto playerDto)
        {
            throw new NotImplementedException();
        }
    }
}
