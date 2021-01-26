using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.BussinessLogicLayer.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconFileName { get; set; }

        public ICollection<PlayerDto> Players { get; set; }
    }
}
