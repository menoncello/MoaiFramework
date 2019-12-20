namespace MoaiFramework.Commands
{
    using System;

    using FluentValidation.Results;

    using Events;

    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();

        public abstract string GetPath();
    }
}