using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.DataAccessLayer.Entities
{
    public class PlayerResource
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int ResourceId { get; set; }

        public int Quantity { get; set; }

        public Player Player { get; set; }

        public Resource Resource { get; set; }
    }
}
