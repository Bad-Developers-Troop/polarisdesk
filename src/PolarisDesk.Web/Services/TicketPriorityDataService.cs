using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PolarisDesk.Web.Services
{
    public class TicketPriorityDataService : ITicketPriorityDataService
    {
        private readonly HttpClient httpClient;
        public TicketPriorityDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<TicketPriority[]> GetAll()
        {
           return await httpClient.GetFromJsonAsync<TicketPriority[]>("api/TicketPriority");
        }
    }
}
