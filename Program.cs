using System;
using System.Collections.Concurrent;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using WebSocketSharp.Server;
namespace IronDomeServerAttack
{
    class Program
    {

        public static ConcurrentQueue<Missile> listmissile = new ConcurrentQueue<Missile>();
        public static ConcurrentQueue<Missile> listmissileforchetz = new ConcurrentQueue<Missile>();
      

        static async Task Main(string[] args)
        {
            
          
            WebSocketServer wss = new WebSocketServer("ws://localhost:3108");
            wss.AddWebSocketService<MissileHandler>("/MissileHandler", () => new MissileHandler(wss,listmissile, listmissileforchetz));
            ManagerIron manager = new ManagerIron(listmissile,wss);
            ManagerChetz managerchtz = new ManagerChetz(listmissileforchetz,wss);

            manager.start();
            managerchtz.start();
            wss.Start();
         


            Console.WriteLine("Backend server is running. Press Enter to exit...");
            Console.ReadLine();
            wss.Stop();

            //MissileQueue missiles1 = new MissileQueue();

            //List<Missile> missiles = await CommandAttack.PrintJson();
            //foreach (var mil in missiles)
            //{

            //    missiles1.Addmissile(mil);

            //}
            //Console.WriteLine(missiles1.getlen());

        }
    }
}