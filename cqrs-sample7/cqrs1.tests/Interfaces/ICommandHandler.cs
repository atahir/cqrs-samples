using cqrs7.utilities.Commands;

namespace cqrs7.utilities.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand 
    {
        void Handle(T command);
    }
}