using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Top.Api.Domain;
using print.Models.DAL;

namespace print.Models.BLL
{
    public class ShipmentOrderPrintInfo
    {
        public Trade tradeInfo { get; set; }
        public ShipmentOrderPrintSettings shipmentOrderPrintSettings { get; set; }
    }
}