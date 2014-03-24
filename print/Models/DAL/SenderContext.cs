using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace print.Models.DAL
{
    public class SenderContext :DbContext
    {
        public DbSet<Sender> Senders { get; set; }
        public DbSet<SenderInfoPrintSettings> SenderInfoPrintSettings { get; set; }
        public DbSet<ReceiverInfoPrintSettings> ReceiverInfoPrintSettings { get; set; }
        public DbSet<ShipmentOrderPrintSettings> ShipmentOrderPrintSettings { get; set; }
    }
}