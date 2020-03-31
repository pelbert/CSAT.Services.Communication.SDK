﻿

namespace CSAT.Services.Communication.SDK.Client
{
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    public class Serializer : ISerializer
    {
        JsonSerializerSettings jsonSerializerSettings;

        public Serializer()
            : this(
                  new JsonSerializerSettings
                  {
                      ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                      TypeNameHandling = TypeNameHandling.None
                  })
        {
        }

        public Serializer(JsonSerializerSettings jsonSerializerSettings)
        {
            this.jsonSerializerSettings = jsonSerializerSettings;
        }

        /// <summary>
        /// Deserializes the stream to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="stream">The stream to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T DeserializeObject<T>(Stream stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            using (var streamReader = new StreamReader(
                stream,
                Encoding.UTF8 /* encoding */,
                true /* detectEncodingFromByteOrderMarks */,
                4096 /* bufferSize */,
                true /* leaveOpen */))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var jsonSerializer = new JsonSerializer();

                return jsonSerializer.Deserialize<T>(textReader);
            }
        }

        /// <summary>
        /// Deserializes the JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="inputString">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T DeserializeObject<T>(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(inputString, this.jsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the specified object into a JSON string.
        /// </summary>
        /// <param name="serializeableObject">The object to serialize.</param>
        /// <returns>The JSON string.</returns>
        public string SerializeObject(object serializeableObject)
        {
            if (serializeableObject == null)
            {
                return null;
            }

            var stream = serializeableObject as Stream;
            if (stream != null)
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }

            var stringValue = serializeableObject as string;
            if (stringValue != null)
            {
                return stringValue;
            }

            return JsonConvert.SerializeObject(serializeableObject, this.jsonSerializerSettings);
        }
    }
}
 