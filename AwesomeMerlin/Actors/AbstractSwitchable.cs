using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public abstract class AbstractSwitchable : AbstractActor, ISwitchable
    {
        private bool isOn = false;

        public bool IsOn()
        {
            return isOn;

        }

        public void Toggle()
        {
            isOn = !isOn;
            if (isOn)
            {
                TurnOn();
            }
            else
            {
                TurnOff();

            }
        }

        public void TurnOff()
        {
            isOn = false;
            UpdateAnimation(isOn);
        }

        public virtual void TurnOn()
        {
            isOn = true;
            UpdateAnimation(isOn);
        }

        protected virtual void UpdateAnimation(bool isOn)
        {

        }

    }
}
