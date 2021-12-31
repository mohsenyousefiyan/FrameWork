using System;

namespace FrameWork.Core.Domain.ApplicationServices.Commands
{
    public class CommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public CommandResult Dispatch(ICommand command)
        {
            Type type = typeof(CommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);            
            CommandResult result = handler.Handle((dynamic)command);
            return result;
        }

        public CommandResult<TData> Dispatch<TData>(ICommand command)
        {
            Type type = typeof(CommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(TData) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            CommandResult<TData> result = handler.Handle((dynamic)command);
            return result;
        }
    }
}
