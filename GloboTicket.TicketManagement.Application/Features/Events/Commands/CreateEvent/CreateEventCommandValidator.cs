using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator:AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository) {

            _eventRepository= eventRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 charachters");

            RuleFor(p => p.Date).NotEmpty().NotNull().GreaterThan(DateTime.Now);
            RuleFor(p => p).MustAsync(EventNameAndDateUnique).WithMessage("Event is exist for the given date");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e ,CancellationToken token)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name,e.Date));
        }
    }
}
