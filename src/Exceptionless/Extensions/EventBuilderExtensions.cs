﻿using System;
using System.Collections.Generic;
using Exceptionless.Models.Data;

#if !PORTABLE && !NETSTANDARD1_2
using Exceptionless.Plugins.Default;
#endif

namespace Exceptionless {
    public static class EventBuilderExtensions {
        /// <summary>
        /// Sets the user's identity (ie. email address, username, user id) that the event happened to.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="identity">The user's identity that the event happened to.</param>
        public static IEventBuilder SetUserIdentity(this IEventBuilder builder, string identity) {
            builder.Target.SetUserIdentity(identity);
            return builder;
        }

        /// <summary>
        /// Sets the user's identity (ie. email address, username, user id) that the event happened to.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="identity">The user's identity that the event happened to.</param>
        /// <param name="name">The user's friendly name that the event happened to.</param>
        public static IEventBuilder SetUserIdentity(this IEventBuilder builder, string identity, string name) {
            builder.Target.SetUserIdentity(identity, name);
            return builder;
        }

        /// <summary>
        /// Sets the user's identity (ie. email address, username, user id) that the event happened to.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="userInfo">The user's identity that the event happened to.</param>
        public static IEventBuilder SetUserIdentity(this IEventBuilder builder, UserInfo userInfo) {
            builder.Target.SetUserIdentity(userInfo);
            return builder;
        }

        /// <summary>
        /// Sets the user's description of the event.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="emailAddress">The user's email address.</param>
        /// <param name="description">The user's description of the event.</param>
        public static IEventBuilder SetUserDescription(this IEventBuilder builder, string emailAddress, string description) {
            builder.Target.SetUserDescription(emailAddress, description);
            return builder;
        }

        /// <summary>
        /// Sets the version that the event happened on.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="version">The version.</param>
        public static IEventBuilder SetVersion(this IEventBuilder builder, string version) {
            builder.Target.SetVersion(version);
            return builder;
        }

        /// <summary>
        /// Changes default stacking behavior by setting the stacking key.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="signatureData">Key value pair that determines how the event is stacked.</param>
        public static IEventBuilder SetManualStackingInfo(this IEventBuilder builder, IDictionary<string, string> signatureData) {
            builder.Target.SetManualStackingInfo(signatureData);
            return builder;
        }

        /// <summary>
        /// Changes default stacking behavior by setting the stacking key.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="title">The stack title.</param>
        /// <param name="signatureData">Key value pair that determines how the event is stacked.</param>
        public static IEventBuilder SetManualStackingInfo(this IEventBuilder builder, string title, IDictionary<string, string> signatureData) {
            builder.Target.SetManualStackingInfo(title, signatureData);
            return builder;
        }

        /// <summary>
        /// Changes default stacking behavior by setting the stacking key.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="manualStackingKey">The manual stacking key.</param>
        public static IEventBuilder SetManualStackingKey(this IEventBuilder builder, string manualStackingKey) {
            builder.Target.SetManualStackingKey(manualStackingKey);
            return builder;
        }

        /// <summary>
        /// Changes default stacking behavior by setting the stacking key.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="title">The stack title.</param>
        /// <param name="manualStackingKey">The manual stacking key.</param>
        public static IEventBuilder SetManualStackingKey(this IEventBuilder builder, string title, string manualStackingKey) {
            builder.Target.SetManualStackingKey(title, manualStackingKey);
            return builder;
        }

#if !PORTABLE && !NETSTANDARD1_2
        /// <summary>
        /// Adds the recent trace log entries to the event.
        /// </summary>
        /// <param name="builder">The event builder object.</param>
        /// <param name="listener">The listener.</param>
        /// <param name="maxEntriesToInclude"></param>
        public static IEventBuilder AddRecentTraceLogEntries(this IEventBuilder builder, Diagnostics.ExceptionlessTraceListener listener = null, int maxEntriesToInclude = TraceLogPlugin.DefaultMaxEntriesToInclude) {
            TraceLogPlugin.AddRecentTraceLogEntries(builder.Target, listener, maxEntriesToInclude);
            return builder;
        }
#endif
    }
}