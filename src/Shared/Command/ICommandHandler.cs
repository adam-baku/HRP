namespace HRP.Shared.Command;

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    public Task HandleAsync(TCommand command);
}
