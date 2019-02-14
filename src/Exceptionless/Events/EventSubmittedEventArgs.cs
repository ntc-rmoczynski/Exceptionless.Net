using System;
using Exceptionless.Models;
using Exceptionless.Plugins;

namespace Exceptionless {
    public class EventSubmittedEventArgs : EventSubmissionEventArgsBase {
        public EventSubmittedEventArgs(ExceptionlessClient client, IEvent data, ContextData pluginContextData) : base(client, data, pluginContextData) {}
    }
}