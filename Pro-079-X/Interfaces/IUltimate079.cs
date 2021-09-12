using CommandSystem;

namespace Pro079X.Interfaces
{
    public interface IUltimate079 : ICommand
    {
        int Cooldown { get; }
        
        int Cost { get; }
    }
}