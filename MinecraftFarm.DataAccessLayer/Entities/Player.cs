using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinecraftFarm.DataAccessLayer.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [MaxLength(64)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [MaxLength(32)]
        [MinLength(4)]
        public string Nickname { get; set; }

        [Range(0, int.MaxValue)]
        public int Emeralds { get; set; }

        public bool IsBanned { get; set; }

        public virtual ICollection<PlayerResource> Resources { get; set; }

        public Player()
        {
            Resources = new List<PlayerResource>();
        }
    }
}