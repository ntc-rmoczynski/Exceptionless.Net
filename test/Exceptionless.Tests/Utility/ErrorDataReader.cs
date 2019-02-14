using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exceptionless.Extensions;
using Exceptionless.Models;
using Exceptionless.Models.Data;
using Exceptionless.Serializer;

namespace Exceptionless.Tests.Utility {
    public class ErrorDataReader {
        private static IJsonSerializer GetSerializer() {
            return new DefaultJsonSerializer();
        }

        private static IEvent GetEvent(string fileName) {
            string json = File.ReadAllText(fileName);
            var serializer = GetSerializer();
            var ev = serializer.Deserialize<IEvent>(json);
            ev.Data[Event.KnownDataKeys.Error] = ev.Data.GetValue<Error>(Event.KnownDataKeys.Error);
            return ev;
        }
        
        public static IEnumerable<IEvent> GetEvents() {
            return Directory.EnumerateFiles(@"..\..\..\ErrorData", "*.json").Select(GetEvent);
        }
    }
}
