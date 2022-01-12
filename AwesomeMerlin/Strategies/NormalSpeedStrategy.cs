using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Strategies
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {
        public NormalSpeedStrategy()
        {

        }

        public double GetSpeed(double speed)
        {
            if(speed > 4)
            {
                speed = 4;
            }
            return speed;
        }

     
    }
}
