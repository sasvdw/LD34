using System.Diagnostics;

namespace Tests.Helpers
{
    public class ConsoleLogger
    {
        public void Log(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
