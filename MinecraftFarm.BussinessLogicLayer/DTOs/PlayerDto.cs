using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.BussinessLogicLayer.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public int Emeralds { get; set; }

        public ICollection<ResourceDto> Resources { get; set; }
    }
}
