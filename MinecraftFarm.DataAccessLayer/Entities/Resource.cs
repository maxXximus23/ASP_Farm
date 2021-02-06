using System.ComponentModel.DataAnnotations;

namespace MinecraftFarm.DataAccessLayer.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string IconFileName { get; set; }
    }
}