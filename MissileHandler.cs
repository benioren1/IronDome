using System;
using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace IronDomeServerAttack
{
    internal class MissileHandler : WebSocketBehavior
    {
       

        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missiletorforirondome;
        private readonly ConcurrentQueue<Missile> _missiletorforchtz;

        public MissileHandler( WebSocketServer wss, ConcurrentQueue<Missile> missiletor, ConcurrentQueue<Missile> missiletorforchtz)
        {
            _wss = wss;
            _missiletorforirondome = missiletor;
            _missiletorforchtz = missiletorforchtz;
        }

        //private readonly Dictionary<string, string> FromWhere = new Dictionary<string, string>()
        //{
        //    {"shiab","IronChez" },
        //    {"zalal","IronChez"},
        //    {"Kasam","IronDome"},
        //    {"grad","IronDome"}

        //}; 


        protected override async void OnMessage(MessageEventArgs e)
        {
            
                var missile = JsonSerializer.Deserialize<Missile>(e.Data);
                missile.Demage = CommandAttack.Getdamge(missile.Name);



            if (missile.Name == "shiab" || missile.Name == "zalal")
            {
                _missiletorforchtz.Enqueue(missile);

            }
            else 
            {

                _missiletorforirondome.Enqueue(missile);
            }



                
                Console.WriteLine($"Missile received: {e.Data}");

        }
        public void BroadcastStatus(string message)
        {
            _wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(message);
        }
        
       

    }
}
