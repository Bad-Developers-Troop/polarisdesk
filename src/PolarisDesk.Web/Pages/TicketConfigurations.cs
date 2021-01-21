using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PolarisDesk.Models;
using PolarisDesk.Web.Services;

namespace PolarisDesk.Web.Pages
{
    public partial class TicketConfigurations
    {

        [Inject]
        public ITicketPriorityDataService ticketPriorityDataService { get; set; }
        [Inject]
        public ITicketStatusDataService ticketStatusDataService { get; set; }

        private TicketPriority[] ticketPriority;
        private TicketStatus[] ticketStatuses;

        private TicketPriority currentPriority;
        private TicketStatus currentStatus;

        protected override async Task OnInitializedAsync()
        {
            await ShowPriority();
            await ShowStatus();
        }


        private async Task ShowPriority()
        {
            currentPriority = null;
           ticketPriority =await  ticketPriorityDataService.GetAll();
        }

        private async Task ShowStatus()
        {
            currentStatus = null;
            ticketStatuses = await ticketStatusDataService.GetAll();
        }
    }
}
