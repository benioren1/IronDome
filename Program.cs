using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackServer2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MissileQueue missiles1 = new MissileQueue();

            List<Missile> missiles = await CommandAttack.PrintJson();
            foreach (var mil in missiles)
            {

                missiles1.addmissile(mil);

            }
            Console.WriteLine(missiles1.getlen());
        }
    }
}
