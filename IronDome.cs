using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronDomeServerAttack
{
    internal class IronDome
    {

        public string Name { get; set; }
        
        public int AmountMissile { get; set; }

        public IronDome(string name , int amount )
        { 
        
            Name = name;
            AmountMissile = amount;
        
        }

        public void SetAmountPlus(int num)
        {

            this.AmountMissile += num;
        
        }
        public void SetAmountMynus()
        {

            this.AmountMissile -= 1;

        }
        public  string InterceptMissileAsync(Missile missile , bool booly)
        {
            if( booly == true)
            {
                return $"Missile {missile.Name} intercepted successfully by {Name}.";

            }
            else
            {
                return $"Missile {missile.Name} intercepted faild by {Name}.";

            }
           
            
        }
        

    }
}
