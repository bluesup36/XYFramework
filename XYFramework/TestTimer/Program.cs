using System;
using System.IO;

namespace TestTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            var action = new Action(() =>
            {
                var token = Guid.NewGuid().ToString();
                File.WriteAllText("1.txt", token);
                Console.WriteLine(string.Format("Current Token is : {0}", token));
                //throw new Exception("errasdasdasd");
            });
            ScheduledTaskB task = new ScheduledTaskB(action, 1000 * 60 * 60);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
