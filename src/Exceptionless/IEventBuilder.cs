using System;
using System.Collections.Generic;
using Exceptionless.Models;
using Exceptionless.Plugins;

namespace Exceptionless {
    public interface IEventBuilder {
        ExceptionlessClient Client { get; set; }

        /// <summary>
        /// Any contextual data objects to be used by Exceptionless plugins to gather additional
        /// information for inclusion in the event.
        /// </summary>
        ContextData PluginContextData { get; }

        IEvent Target { get; }
        
        /// <summary>
        /// Adds the object to extended data. Use either <paramref name="excludedPropertyNames" /> or
        /// <see cref="Exceptionless.Json.ExceptionlessIgnoreAttribute" /> to exclude data from being included in the event.
        /// </summary>
        /// <param name="data">The data object to add.</param>
        /// <param name="name">The name of the object to add.</param>
        /// <param name="maxDepth">The max depth of the object to include.</param>
        /// <param name="excludedPropertyNames">Any property names that should be excluded.</param>
        /// <param name="ignoreSerializationErrors">Specifies if properties that throw serialization errors should be ignored.</param>
        IEventBuilder AddObject(object data, string name = null, int? maxDepth = null, ICollection<string> excludedPropertyNames = null, bool ignoreSerializationErrors = false);

        /// <summary>
        /// Adds one or more tags to the event.
        /// </summary>
        /// <param name="tags">The tags to be added to the event.</param>
        IEventBuilder AddTags(params string[] tags);

        /// <summary>
        /// Marks the event as being a critical occurrence.
        /// </summary>
        IEventBuilder MarkAsCritical();

        /// <summary>
        /// Allows you to reference a parent event by its <seealso cref="Event.ReferenceId" /> property. This allows you to have parent and child relationships.
        /// </summary>
        /// <param name="name">Reference name</param>
        /// <param name="id">The reference id that points to a specific event</param>
        IEventBuilder SetEventReference(string name, string id);

        /// <summary>
        /// Sets the event exception object.
        /// </summary>
        /// <param name="ex">The exception</param>
        IEventBuilder SetException(Exception ex);

        /// <summary>
        /// Sets the event geo coordinates.
        /// </summary>
        /// <param name="latitude">The event latitude.</param>
        /// <param name="longitude">The event longitude.</param>
        IEventBuilder SetGeo(double latitude, double longitude);

        /// <summary>
        /// Sets the event geo coordinates. Can be either "lat,lon" or an IP address that will be used to auto detect the geo coordinates.
        /// </summary>
        /// <param name="coordinates">The event coordinates.</param>
        IEventBuilder SetGeo(string coordinates);

        /// <summary>
        /// Sets the event message.
        /// </summary>
        /// <param name="message">The event message.</param>
        IEventBuilder SetMessage(string message);

        /// <summary>
        /// Sets an extended property value to include with the event. Use either <paramref name="excludedPropertyNames" /> or
        /// <see cref="Exceptionless.Json.ExceptionlessIgnoreAttribute" /> to exclude data from being included in the event report.
        /// </summary>
        /// <param name="name">The name of the object to add.</param>
        /// <param name="value">The data object to add.</param>
        /// <param name="maxDepth">The max depth of the object to include.</param>
        /// <param name="excludedPropertyNames">Any property names that should be excluded.</param>
        /// <param name="ignoreSerializationErrors">Specifies if properties that throw serialization errors should be ignored.</param>
        IEventBuilder SetProperty(string name, object value, int? maxDepth = null, ICollection<string> excludedPropertyNames = null, bool ignoreSerializationErrors = false);

        /// <summary>
        /// Sets the event reference id.
        /// </summary>
        /// <param name="referenceId">The event reference id.</param>
        IEventBuilder SetReferenceId(string referenceId);

        /// <summary>
        /// Sets the event source.
        /// </summary>
        /// <param name="source">The event source.</param>
        IEventBuilder SetSource(string source);

        /// <summary>
        /// Sets the event type.
        /// </summary>
        /// <param name="type">The event type.</param>
        IEventBuilder SetType(string type);

        /// <summary>
        /// Sets the event value.
        /// </summary>
        /// <param name="value">The value of the event.</param>
        IEventBuilder SetValue(decimal value);

        /// <summary>
        /// Submits the event report.
        /// </summary>
        void Submit();
    }
}