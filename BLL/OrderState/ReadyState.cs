using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public class ReadyState : OrderState
    {
        public const int StateId = 3;
        public ReadyState() : base(StateId)
        {
        }

        public override OrderState AssignNextStatus()
        {
            return new CompletedState();
        }
    }
}
