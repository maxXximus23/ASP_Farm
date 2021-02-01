using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinecraftFarm.ViewModels
{
    public class PlayerViewModel : IFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Nickname { get; set; }

        public int Emeralds { get; set; }

        public ICollection<ResourceViewModel> Resources { get; set; }

        public Action Action { get; set; }

        public bool IsBanned { get; set; }
    }
}