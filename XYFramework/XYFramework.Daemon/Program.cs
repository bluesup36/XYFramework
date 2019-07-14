using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using XYFramework.Configuration;
using System.IO;

namespace XYFramework.Daemon
{
    class Program
    {
        static Manager manager;
        static void Main(string[] args)
        {
            manager = Manager.Load("jsconfig1.json");
            Console.WriteLine("Start watching");
            var fileName = "TestTimer";
            fileName = manager["daemon"]["watchApps"].First.ToString();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    StartWatch(fileName);
                    Thread.Sleep(1000);
                }
            });
            Console.ReadKey();
        }

        public static void StartWatch(string address)
        {
            bool flag = false;
            Process[] arrayProcess = Process.GetProcesses();
            List<string> lst = manager["daemon"]["excludedApps"].ToList();
            foreach (var p in arrayProcess)
            {
                if (!lst.Contains(p.ProcessName))
                {
                    try
                    {
                        //File.AppendAllText("2.txt", p.ProcessName.ToString() + Environment.NewLine);
                        if (p.MainModule.FileName.ToString() == address)
                        {
                            flag = true;
                        }
                    }
                    catch
                    {
                        File.AppendAllText("1.txt", p.ProcessName.ToString() + Environment.NewLine);
                        //拒绝访问进程的全路径
                        Console.WriteLine("Process(" + p.Id.ToString() + ")(" + p.ProcessName.ToString() + ") cannot access！");
                    }
                }
            }
            if (!flag)
            {
                Process process = new Process();
                process.StartInfo.FileName = address;
                process.Start();
            }
        }
    }
}
