using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.Testing
{
    public class TestWatch : Stopwatch
    {
        private static Stopwatch _stopwatch;

        public static void Start(string tag = "StopWatch Started")
        {
            if (_stopwatch == null)
            {
                _stopwatch = StartNew();
            }
            else
            {
                _stopwatch.Restart();
            }
            WriteLine(tag);
        }

        public new static void Stop()
        {
            if (_stopwatch != null)
            {
                _stopwatch.Stop();
                WriteLine("StopWatch Stopped");
            }
        }

        public static void WriteLine(string tag = "StopWatch")
        {
            if (_stopwatch != null && _stopwatch.IsRunning)
            {
                Debug.WriteLine(tag + ": " + _stopwatch.Elapsed);
            }
            else if (_stopwatch != null && !_stopwatch.IsRunning)
            {
                Debug.WriteLine(tag + ": Stopped at " + _stopwatch.Elapsed);
            }
        }
    }
}
