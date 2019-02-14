using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exceptionless.Models;
using Exceptionless.Submission;

namespace Exceptionless.Queue {
    public interface IEventQueue : IDisposable {
        void Enqueue(IEvent ev);
        Task ProcessAsync();
        void SuspendProcessing(TimeSpan? duration = null, bool discardFutureQueuedItems = false, bool clearQueue = false);
        event EventHandler<EventsPostedEventArgs> EventsPosted;
    }

    public class EventsPostedEventArgs : EventArgs {
        public SubmissionResponse Response { get; set; }
        public ICollection<IEvent> Events { get; set; }
    }
}