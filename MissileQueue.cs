using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronDomeServerAttack
{
    internal  class MissileQueue : Queue<Missile>
    {

        
       static Queue<Missile> missiles = new Queue<Missile>();

        public MissileQueue(Missile mis )
        { 
        this.Addmissile( mis );
        
        }

        public void Addmissile(Missile missile)
        {

             missiles.Enqueue(missile);


        }

        public int getlen()
        {

            return missiles.Count;
        }



    }
}
