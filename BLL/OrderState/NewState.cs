using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public class NewState : OrderState
    {
        public const int StateId = 1;
        public NewState():base(StateId)
        {
        }

        public override OrderState AssignNextStatus()
        {
            return new InPorgressState();
        }
    }
}
