namespace MinecraftFarm.ViewModels
{
    public enum Action { Add, Edit };
    public interface IFormModel
    {
        Action Action { get; set; }
    }
}
