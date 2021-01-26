using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.BussinessLogicLayer.DTOs
{
    public class PlayerResourceDto
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int ResourceId { get; set; }

        public int Quantity { get; set; }

        public PlayerDto Player { get; set; }

        public ResourceDto Resource { get; set; }
    }
}
