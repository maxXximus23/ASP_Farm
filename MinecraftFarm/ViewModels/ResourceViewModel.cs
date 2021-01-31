using System.ComponentModel.DataAnnotations;

namespace MinecraftFarm.ViewModels
{
    public class ResourceViewModel : IFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string IconFileName { get; set; }
        public Action Action { get; set; }
    }
}
