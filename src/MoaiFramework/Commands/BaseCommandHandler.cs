using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MoaiFramework.Bus;
using MoaiFramework.Notifications;
using MoaiFramework.Repositories;

namespace MoaiFramework.Commands
{
    public abstract class BaseCommandHandler<TRequest> : CommandHandler, IRequestHandler<TRequest, bool>
        where TRequest : Command
    {
        protected BaseCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public sealed override Task<bool> HandleCommand(Command request, CancellationToken cancellationToken)
        {
            return Handle((TRequest) request, cancellationToken);
        }

        public abstract Task<bool> Handle(TRequest request, CancellationToken cancellationToken);
    }
}