using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackServer2
{
    internal class MissileQueue : Queue<Missile>
    {
        Queue<Missile> missiles = new Queue<Missile>();

        public async Task addmissile(Missile missile)
        {

            missiles.Enqueue(missile);


        }

        public int getlen()
        {

            return missiles.Count;
        }



    }
}
