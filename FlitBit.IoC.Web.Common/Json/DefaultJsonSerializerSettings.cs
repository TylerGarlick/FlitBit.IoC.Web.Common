﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlitBit.IoC.Web.Common.Json
{
    public static class DefaultJsonSerializerSettings
    {
        static DefaultJsonSerializerSettings()
        {
            Current = new JsonSerializerSettings
                      {
                          Formatting = Formatting.Indented,
                          ContractResolver = new CamelCasePropertyNamesContractResolver(),
                          MissingMemberHandling = MissingMemberHandling.Ignore,
                          ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                          Converters = new[] { new DefaultJsonConverter() }
                      };
        }
        public static JsonSerializerSettings Current { get; set; }
    }
}