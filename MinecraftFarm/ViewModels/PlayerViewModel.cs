using System.Collections.Generic;

namespace MinecraftFarm.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public int Emeralds { get; set; }

        public ICollection<ResourceViewModel> Resources { get; set; }
    }
}