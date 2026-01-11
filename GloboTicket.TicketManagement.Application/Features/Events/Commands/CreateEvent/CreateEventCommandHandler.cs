using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand,Guid>
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
            
        public CreateEventCommandHandler(IEventRepository eventRepository,IMapper imapper)
        {
            _eventRepository= eventRepository;
            _mapper= imapper;

        }

        public async Task<Guid> Handle(CreateEventCommand request,CancellationToken cancellationToken) {
            
            CreateEventCommandValidator validator = new CreateEventCommandValidator(_eventRepository);

            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);
            return @event.EventId;


        }





    }
}
