namespace MoaiFramework.Events
{
    using System;

    using MediatR;

    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}