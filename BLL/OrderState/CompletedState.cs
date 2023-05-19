using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public class CompletedState : OrderState
    {
        public const int StateId = 4;
        public CompletedState() : base(StateId)
        {
        }

        public override OrderState AssignNextStatus()
        {
            return new CompletedState();
        }
    }
}
