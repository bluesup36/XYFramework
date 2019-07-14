using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestTimer
{
    public class ScheduledTaskB
    {
        Timer _timer;

        public ScheduledTaskB(Action action, int interval)
        {
            _timer = new Timer(new TimerCallback(a =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Excute action error, error msg is:" + ee.Message);
                    _timer.Change(1000 * 60 * 5, interval);
                }
            }), null, 0, interval);
            GC.KeepAlive(_timer);
        }
    }
}
