using CintraStore.Shared.Commands;

namespace CintraStore.Shared
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
