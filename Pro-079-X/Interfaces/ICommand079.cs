using CommandSystem;

namespace Pro079X.Interfaces
{
    public interface ICommand079 : ICommand
    {
        string ExtraArguments { get; }

        bool Cassie { get; }
        
        int Cooldown { get; }
        
        int MinLevel { get; }
        
        int Cost { get; }
        
        string CommandReady { get; }
    }
}