using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P2P
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count() <= 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    Process.Start("P2P.exe");
                }
            }
            new Program().Run();
        }

        public void Run()
        {
            var peer = new Peer();
            var peerThread = new Thread(peer.Run) { IsBackground = true };
            peerThread.Start();

            //wait for the server to start up.
            Thread.Sleep(1000);

            while (true)
            {
                string tmp = Console.ReadLine();
                peer.Channel.Vote(new Block(DateTime.Now, null, tmp));
            }

            peer.Stop();
            peerThread.Join();
        }
    }
}
