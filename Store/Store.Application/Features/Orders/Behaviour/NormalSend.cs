using Store.Domain.OrderDomain.Behaviour.Send;
using Store.Domain.OrderDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Behaviour
{
    public class NormalSend : HowSend
    {
        public EnmHowSend send()
        {
            return EnmHowSend.Normal;
        }
    }
}
