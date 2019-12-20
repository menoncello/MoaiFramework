namespace MoaiFramework.Bus
{
    using System.Threading.Tasks;

    using Commands;
    using Events;

    public interface IMediatorHandler
    {
        Task RaiseEventAsync<T>(T @event)
            where T : Event;

        Task SendCommandAsync<T>(T command)
            where T : Command;
    }
}