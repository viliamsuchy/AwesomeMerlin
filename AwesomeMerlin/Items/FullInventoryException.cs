using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors.Items
{
    public class FullInventoryException : Exception
    {
        public FullInventoryException(string Message) : base(Message)
        {

        }
    }
}
