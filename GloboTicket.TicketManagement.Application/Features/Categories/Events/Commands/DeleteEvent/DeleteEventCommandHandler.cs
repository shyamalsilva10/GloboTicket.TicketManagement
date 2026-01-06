using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IMapper imapper)
        {
            _eventRepository = eventRepository;
            _mapper = imapper;

        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);
            var eventToUpdateMapped = _mapper.Map<Event>(eventToUpdate);
            await _eventRepository.DeleteAsync(eventToUpdateMapped);

        }






    }
}
