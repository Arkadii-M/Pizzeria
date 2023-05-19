using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.OrderState
{
    public abstract class OrderState
    {
        public int CurrentStateId
        {
            get;
            private set;
        }
        protected OrderState(int stateId)
        {
            CurrentStateId = stateId;
        }

        public OrderState CancelOrder()
        {
            if (CurrentStateId != CompletedState.StateId)
            {
                return new CancelledState();
            }
            return new CompletedState();
        }
        public abstract OrderState AssignNextStatus();

        public static OrderState GetOrderStateById(int stateId)
        {
            return stateId switch
            {
                NewState.StateId => new NewState(),
                InPorgressState.StateId => new InPorgressState(),
                ReadyState.StateId => new ReadyState(),
                CompletedState.StateId => new CompletedState(),
                CancelledState.StateId => new CancelledState(),
                _ => throw new ArgumentException("Invalid stateId"),
            };
        }


    }
}
