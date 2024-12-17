using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EventStore;

public interface IEventStoreService
{
    Task AppendToStreamAsync(string streamName,IEnumerable< EventData> events);
    EventData GenerateEventData(object @event);
    Task SubcribeToStreamAsync(string streamName,Func<StreamSubscription,ResolvedEvent,CancellationToken,Task> eventAppeared);
}
