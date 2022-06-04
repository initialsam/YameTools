using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace YameTools.Helper
{
    public class StopWatchTimer : IDisposable
    {
        private readonly string _message;
        private readonly Action<string> _logAction;
        private readonly Stopwatch _stopwatch;

        public StopWatchTimer(string message) : this(message, Console.WriteLine)
        {
        }

        public StopWatchTimer(string message, Action<string> logAction)
        {
            _message = message;
            _logAction = logAction;
            _logAction.Invoke($"Start {_message}");
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }


        public void Dispose()
        {
            _stopwatch.Stop();

            _logAction($"Finish {_message} in {DispalyTime(_stopwatch.Elapsed)}");
            _stopwatch.Reset();
        }

        private string DispalyTime(TimeSpan elapsed)
        {
            var result = String.Empty;
            if(elapsed.Hours != 0)
            {
                result += $"{elapsed.Hours}h ";
            }
            if (elapsed.Minutes != 0)
            {
                result += $"{elapsed.Minutes}m ";
            }
            if (elapsed.Seconds != 0)
            {
                result += $"{elapsed.Seconds}s ";
            }
            if (elapsed.Milliseconds == 0)
            {
                result += $"{elapsed.TotalMilliseconds * 1000:n3}μs";
            }
            else
            {
                result += $"{elapsed.Milliseconds}ms ";
            }
            return result;
        }
    }
}
