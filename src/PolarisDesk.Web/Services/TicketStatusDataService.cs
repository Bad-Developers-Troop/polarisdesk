using PolarisDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PolarisDesk.Web.Services
{
    public class TicketStatusDataService : ITicketStatusDataService
    {
        private readonly HttpClient httpClient;
        public TicketStatusDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TicketStatus[]> GetAll()
        {
            return await httpClient.GetFromJsonAsync<TicketStatus[]>("api/TicketStatus");
        }
    }
}
