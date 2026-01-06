using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
    {
        public readonly IAsyncRepository<Event> _eventRepository;
        public readonly IAsyncRepository<Category> _categoryRepository;
        public readonly IMapper _mapper;
        public GetEventDetailsQueryHandler(IAsyncRepository<Event> eventRepository,IMapper mapper,IAsyncRepository<Category> categoryRepository)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
          var @event=await _eventRepository.GetByIdAsync(request.Id);
          var eventDetailsDto= _mapper.Map<EventDetailsVm>(@event);
          var category=await _categoryRepository.GetByIdAsync(@event.CategoryId);
          eventDetailsDto.Category = _mapper.Map<CategoryDto>(category);
          return eventDetailsDto;

        }



    }
}
