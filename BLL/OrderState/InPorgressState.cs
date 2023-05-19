using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public class InPorgressState : OrderState
    {
        public const int StateId = 2;
        public InPorgressState() : base(StateId)
        {
        }

        public override OrderState AssignNextStatus()
        {
            return new ReadyState();
        }
    }
}
