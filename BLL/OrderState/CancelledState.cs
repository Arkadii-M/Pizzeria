using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public class CancelledState : OrderState
    {
        public const int StateId = 5;
        public CancelledState() : base(StateId)
        {
        }

        public override OrderState AssignNextStatus()
        {
            return new CancelledState();
        }
    }
}
