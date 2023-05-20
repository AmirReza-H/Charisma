using Store.Domain.OrderDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.OrderDomain.Dtos
{
    public class ValueAndSendDto
    {
        public decimal Cost { get; set; }
        public EnmHowSend HowSend { get; set; }
    }
}
