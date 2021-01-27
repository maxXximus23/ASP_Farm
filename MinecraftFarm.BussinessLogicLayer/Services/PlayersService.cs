using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Contexts;
using MinecraftFarm.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var joined = existingResources.Join(playerResourceDtos,
                resource => resource.Id,
                resourceDto => resourceDto.Id,
                (resource, resourceDto) => UpdateResourceQuantityValue(resource, resourceDto.Quantity)
                ).ToArray();

            _databaseContext.SaveChanges();
        }

        private PlayerResource UpdateResourceQuantityValue(PlayerResource resource, int newQuantity)
        {
            resource.Quantity = newQuantity;
            return resource;
        }

        public void DeleteById(int id)
        {
            var player = _databaseContext.Players.Single(player => player.Id == id);

            _databaseContext.Players.Remove(player);
            _databaseContext.SaveChanges();
        }

        public async Task<IReadOnlyCollection<PlayerDto>> GetAll()
        {
            var dtos = await _databaseContext.Players
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<IReadOnlyCollection<PlayerDto>>(dtos);
        }

        public async Task<PlayerDto> GetById(int id)
        {
            var player = await _databaseContext.Players.SingleAsync(player => player.Id == id);

            return _mapper.Map<PlayerDto>(player);
        }

        public void Update(PlayerDto playerDto)
        {
            var player = _databaseContext.Players.Single(player => player.Id == playerDto.Id);

            player = _mapper.Map<Player>(playerDto);

            _databaseContext.Update(player);
            _databaseContext.SaveChanges();
        }
    }
}