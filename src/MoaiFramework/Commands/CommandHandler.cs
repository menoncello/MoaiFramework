using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MoaiFramework.Bus;
using MoaiFramework.Notifications;
using MoaiFramework.Repositories;

namespace MoaiFramework.Commands
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler bus;

        private readonly DomainNotificationHandler notifications;

        private readonly IUnitOfWork uow;

        protected CommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
        {
            this.uow = uow;
            this.notifications = (DomainNotificationHandler) notifications;
            this.bus = bus;
        }

        public async Task<bool> CommitAsync()
        {
            if (notifications.HasNotifications()) return false;
            if (await uow.CommitAsync().ConfigureAwait(true)) return true;

            await bus
                .RaiseEventAsync(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }

        public abstract Task<bool> HandleCommand(Command request, CancellationToken cancellationToken);

        protected async Task NotifyValidationErrorsAsync(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                await bus.RaiseEventAsync(new DomainNotification(message.MessageType, error.ErrorMessage))
                    .ConfigureAwait(true);
        }
    }
}