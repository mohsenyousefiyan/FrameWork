using FrameWork.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Domain.ApplicationServices.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly DomainEventDistpacher domainEventDistpacher;

        public CommandHandler(DomainEventDistpacher domainEventDistpacher)
        {
            this.domainEventDistpacher = domainEventDistpacher;
        }

        public abstract CommandResult Handle(TCommand command);

    }

    public abstract class CommandHandler<TCommand, TData> where TCommand : ICommand
    {
        protected readonly DomainEventDistpacher domainEventDistpacher;

        public CommandHandler(DomainEventDistpacher domainEventDistpacher)
        {
            this.domainEventDistpacher = domainEventDistpacher;
        }

        public abstract CommandResult<TData> Handle(TCommand command);

    }
}
