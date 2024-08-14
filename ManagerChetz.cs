using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace IronDomeServerAttack
{
    internal class ManagerChetz
    {

        private readonly ConcurrentQueue<Missile> _mytor;
        private readonly WebSocketServer _wss;
        MissileHandler _missileHandler;

        public ManagerChetz(ConcurrentQueue<Missile> missilelist, WebSocketServer wss)
        {
            _mytor = missilelist;
            _wss = wss;
        }
        public List<int> integer = new List<int>() {1,0,1,1};
        public async void start()
        {
            List<string> list = new List<string> { "magenchetz1", "magenchetz2"};
            Console.WriteLine("sdfghjkl;");
            foreach (string s in list)
            {

                var interecped = new Thread(() => ProcessNextMissileAsync(s));
                interecped.Start();

            };

        }





        public async void ProcessNextMissileAsync(string name)
        {
            MissileChez _missileChez = new MissileChez(name, 5);
            Console.WriteLine(_missileChez);

            while (true)
            {
                Random random = new Random();
                var intercepted = random.Next(integer.Count);
                int booly = integer[intercepted];
                if (_mytor.TryDequeue(out var missile))
                {
                    if (booly == 1)
                    {
                        await Task.Delay(missile.Time * 1000);

                        //if (_ironDome.AmountMissile <= 1)
                        //{

                        //    _ironDome.SetAmountPlus(4);
                        //}
                        var resultMessage = _missileChez.InterceptMissileChezAsync(missile, true);

                        Console.WriteLine(resultMessage);
                        _missileChez.SetAmountMynus();
                        _wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(resultMessage);

                    }
                    else
                    {

                        await Task.Delay(missile.Time * 1000);

                        var resultMessage = _missileChez.InterceptMissileChezAsync(missile, false);

                        Console.WriteLine(resultMessage);

                        _wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(resultMessage);
                    }
                }

            }
        }


    }
}
