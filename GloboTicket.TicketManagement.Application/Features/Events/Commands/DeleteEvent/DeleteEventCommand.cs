using System.Net;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand:IRequest
    {
        //testing
        public Guid Id { get; set; }
    }
}
