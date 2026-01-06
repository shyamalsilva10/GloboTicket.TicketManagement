using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery:IRequest<EventDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
