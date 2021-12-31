namespace FrameWork.Core.Domain.ApplicationServices.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
       

        public CommandHandler()
        {
            
        }

        public abstract CommandResult Handle(TCommand command);

    }

    public abstract class CommandHandler<TCommand, TData> where TCommand : ICommand
    {
       

        public CommandHandler()
        {
          
        }

        public abstract CommandResult<TData> Handle(TCommand command);

    }
}
