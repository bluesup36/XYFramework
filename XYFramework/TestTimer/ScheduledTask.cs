using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestTimer
{
    public class ScheduledTask
    {
        Timer _timer;
        Action _action;
        public ScheduledTask(Action action, double interval)
        {
            _action = action;
            _timer = new Timer(interval);
            _timer.Elapsed += timer_Elapsed; ;
            _timer.Start();
            GC.KeepAlive(_timer);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _action.Invoke();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Excute action error, error msg is " + ee.Message);
                _timer.Stop();
                _timer.Start();
            }
        }
    }
}
