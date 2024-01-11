using Contracts.Common.Events;
using Infrastructure.Common;
using MediatR;
using Serilog;

namespace Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventAsync(this IMediator mediator, List<BaseEvent> domainEvents, ILogger logger)
        {
            foreach(var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
                var data = new SerializeService().Serialize(domainEvent);
                logger.Information($"\n-----\nA domain event has been published!\nEvent: {domainEvent.GetType().Name}\nData: {data}\n-----\n");
            }    
        }
    }
}
