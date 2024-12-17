using Application.Services.EventStore;
using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.EventStore;

public class EventStoreService : IEventStoreService
{
    EventStoreClientSettings GetEventStoreClientSettings(string connection= "esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false")
    {
        return EventStoreClientSettings.Create(connection);
    }

    EventStoreClient Client { get => new(GetEventStoreClientSettings()); }

    public async Task AppendToStreamAsync(string streamName, IEnumerable<EventData> events)
    {
        await Client.AppendToStreamAsync(
            streamName:streamName,
            eventData:events,
            expectedState:StreamState.Any);
    }

    public EventData GenerateEventData(object @event)
    {
        return new EventData(
            eventId:Uuid.NewUuid(),
            type:@event.GetType().Name,
            data:JsonSerializer.SerializeToUtf8Bytes(@event));
    }

    public async Task SubcribeToStreamAsync(string streamName, Func<StreamSubscription, ResolvedEvent, CancellationToken, Task> eventAppeared)
    {
        await Client.SubscribeToStreamAsync(
            streamName:streamName,
            start:FromStream.Start,
            eventAppeared:eventAppeared,
            subscriptionDropped: (streamSubscription, subscriptionDroppedReason, exception) => Console.WriteLine("Disconnected!")
            );
    }
}
