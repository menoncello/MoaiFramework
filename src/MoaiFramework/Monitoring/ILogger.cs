namespace MoaiFramework.Monitoring
{
    using System;

    public interface ILogger
    {
        void Verbose(string messageTemplate);
        void Verbose(string messageTemplate, params object[] objectValues);

        void Debug(string messageTemplate);
        void Debug(string messageTemplate, params object[] objectValues);

        void Information(string messageTemplate);
        void Information(string messageTemplate, params object[] objectValues);

        void Warning(string messageTemplate);
        void Warning(string messageTemplate, params object[] objectValues);

        void Error(Exception exception, string messageTemplate);
        void Error(Exception exception, string messageTemplate, params object[] objectValues);

        void Fatal(Exception exception, string messageTemplate);
        void Fatal(Exception exception, string messageTemplate, params object[] objectValues);
    }
}