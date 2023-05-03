namespace Core.ILogger
{
    public interface INLogLogger
    {
        void Debug(string message);
        void Error(string message);
        void Info(string message);
        void Warn(string message);
    }
}