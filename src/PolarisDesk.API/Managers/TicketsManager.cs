using Microsoft.EntityFrameworkCore;
using PolarisDesk.DataAccessLayer;
using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.API.Managers
{
    public class TicketsManager : ITicketsManager
    {
        private readonly IPolarisDeskContext polarisDeskContext;

        public TicketsManager(IPolarisDeskContext polarisDeskContext)
        {
            this.polarisDeskContext = polarisDeskContext;
        }

        public async Task SaveTicketAsync(Ticket ticket)
        {
            await polarisDeskContext.ExecuteTransactionAsync(async () =>
            {
                var customer = await polarisDeskContext.GetData<Customer>(trackingChanges: true).FirstOrDefaultAsync();
                polarisDeskContext.Insert(ticket);
                customer.Updated = DateTime.UtcNow;

                await polarisDeskContext.SaveAsync();
            });
        }
    }
}
