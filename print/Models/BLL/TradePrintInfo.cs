using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.DAL;
using Top.Api.Domain;

namespace print.Models.BLL
{
    public class TradePrintInfo
    {
        public Sender sender { get; set; }
        public SenderInfoPrintSettings senderInfoPrintSettings { get; set; }
        public ReceiverInfoPrintSettings receiverInfoPrintSettings { get; set; }
        public Trade tradeInfo { get; set; }
    }
}