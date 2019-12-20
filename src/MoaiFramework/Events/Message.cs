namespace MoaiFramework.Events
{
    using System;

    using MediatR;

    public class Message : IRequest<bool>
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public Guid AggregateId { get; protected set; }

        public string MessageType { get; protected set; }
    }
}