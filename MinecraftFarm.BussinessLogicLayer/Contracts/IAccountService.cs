using MinecraftFarm.BussinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftFarm.BussinessLogicLayer.Contracts
{
    public interface IAccountService
    {
        public Task<PlayerDto> TryFindUserByEmailAndPassword(string login, string password);

        public Task<PlayerDto> TryFindUserByEmail(string login);

        public Task AddUser(string login, string password, string Nickname);
    }
}
