using cqrs6.utilities.Commands;

namespace cqrs6.utilities.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand 
    {
        void Handle(T command);
    }
}