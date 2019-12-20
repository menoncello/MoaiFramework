namespace MoaiFramework.Events
{
    using System;

    public class StoredEvent : Event
    {
        public StoredEvent(Event @event, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; }

        public string Data { get; }

        public string User { get; }
    }
}