using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronDomeServerAttack
{
    internal class Missile
    {

        public string Name { get; set; }
        public int Speed { get; set; }
        public double Muss { get; set; }
        public Dictionary<string, int> Origin { get; set; } = new Dictionary<string, int>();
        public int Angle { get; set; }
        public int Time { get; set; }

        public float Demage { get; set; }
        public Missile() { }



    }
}



