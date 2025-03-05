namespace WebApplication1.Services.Abstraction
{
    public interface IOutputService
    {
        string OutputMode { get; }
        void AppendLine(string text);
        string GetOutput();
    }
}
