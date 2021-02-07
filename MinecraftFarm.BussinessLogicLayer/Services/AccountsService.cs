using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinecraftFarm.BussinessLogicLayer.Contracts;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Contexts;
using MinecraftFarm.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Services
{
    public class AccountsService : IAccountService
    {
        private readonly DatabaseContext _databaseContext;

        private readonly IMapper _mapper;

        public AccountsService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public async Task AddUser(string login, string password, string nickname)
        {
            _databaseContext.Players.Add(new Player { Login = login, Password = password, Nickname = nickname });
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<PlayerDto> TryFindUserByEmail(string login)
        {
            var user = await _databaseContext.Players.FirstOrDefaultAsync(u => u.Login == login);
            return _mapper.Map<PlayerDto>(user);
        }

        public async Task<PlayerDto> TryFindUserByEmailAndPassword(string login, string password)
        {
            var user = await _databaseContext.Players.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return _mapper.Map<PlayerDto>(user);
        }
    }
}
