using System;

namespace Exceptionless.Models {
    public interface IEvent : IData {

        /// <summary>
        /// The number of duplicated events.
        /// </summary>
        int? Count { get; set; }

        ///// <summary>
        ///// Optional data entries that contain additional information about this event.
        ///// </summary>
        //DataDictionary Data { get; set; }

        /// <summary>
        /// The date that the event occurred on.
        /// </summary>
        DateTimeOffset Date { get; set; }

        /// <summary>
        /// The geo coordinates where the event happened.
        /// </summary>
        string Geo { get; set; }

        /// <summary>
        /// The event message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// An optional identifier to be used for referencing this event instance at a later time.
        /// </summary>
        string ReferenceId { get; set; }

        /// <summary>
        /// The event source (ie. machine name, log name).
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// A list of tags used to categorize this event.
        /// </summary>
        TagSet Tags { get; set; }

        /// <summary>
        /// The event type (ie. error, log message, feature usage).
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// The value of the event if any.
        /// </summary>
        decimal? Value { get; set; }

        //bool Equals(object obj);
        //int GetHashCode();
    }
}