namespace MinecraftFarm.ViewModels
{
    public class PlayerResourceViewModel : IFormModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public ResourceViewModel Resource { get; set; }
        public Action Action { get; set; }
    }
}
