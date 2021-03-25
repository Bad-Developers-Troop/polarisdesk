using System.Threading.Tasks;

namespace PolarisDesk.API.Managers
{
    public interface ITicketsManager
    {
        Task SaveTicketAsync(Ticket ticket);
    }
}