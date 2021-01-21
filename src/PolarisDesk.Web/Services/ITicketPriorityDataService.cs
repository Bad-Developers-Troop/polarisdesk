using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisDesk.Models;
namespace PolarisDesk.Web.Services
{
    public interface ITicketPriorityDataService
    {
        Task<TicketPriority[]> GetAll();

    }
}
