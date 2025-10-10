/*
 * Oden API
 *
 * The Oden Private Partner API exposes RESTful API endpoints for clients to get, create and update data on the Oden Platform.  The API is based on the OpenAPI 3.0 specification. ### Current Version The URL, and host, for the current version is [https://api.oden.app/v2](https://api.oden.app/v2).  ### Oden's Data Model - **Organization**: This represents the Organization registered as an Oden customer. An organization has an associated collection of users, factories, lines, etc. This is the entity a specific authentication token is associated with. - **Asset** or **Machinegroup**: Assets, or machinegroups, are collections of machines, which may either be a **Factory** or a **Line**:   - **Factory**: Factories are collections of lines, representing a particular manufacturing location.     - **Line**: Lines are collections of machines, often representing a particular production line. Lines may also have **Products** mapped to them, indicating what is currently being manufactured by the specific line.       - **Machine**: Machines are the physical machines that make up a line - **Product**: Products capture what entities a manufacturer produces - **Interval**: An interval is a period of time that takes place on a manufacturing line and expresses some business concern. It's Oden's way of making metrics aggregatable, traceable, and relatable to a manufacturer.   - **Run**: A run is a production interval that labels a period of production as being work on some single product   - **Batch**: A batch is a production interval that represents a portion of a particular run   - **State**: A state is an interval that tracks the availability or utilization of a line     - **State Category**: A state category describes what state a line is in - such as ex. uptime, downtime, scrapping, etc.     - **State Reason**: A state reason describes why a line is in a particular state - such as \"maintenance\" being a reason for the category \"downtime\".   - **Custom**: A custom interval can track any other type of interval-based data a manufacturer might want to analyze. These are created on a per-factory basis. - **Target**: Targets specify values and upper/lower thresholds for metrics when specific products are running on specific lines - **Scrap/Yield**: Scrap/yield output specifies amount of produced product on a line during either a run or batch interval. Oden will categorize all output as either scrap or yield - as specified by the Scrap Yield Schema for a given factory. If you have other categories, like rework/blocked/off-grade, you must choose between categorizing those amounts as either good or bad production by specifying as scrap or yield. Clients may also add scrap codes (i.e., reasons) to a given Scrap Yield Data entry.   - **Scrap Code**: A scrap code is a code that explains the reason for a scrap/yield raw data input - such as \"Rework\" - **Quality Test**: Quality Tests are results of quality assurance tests done on site, and uploaded to Oden. They may be attached to a single Batch or Run. - **Metric**: Known in factories as \"tags\", metrics are the raw data that is collected by Oden from the machines and devices on the factory floor. - **Metric Group**: Metric groups are metrics that represent the same thing across different lines. They provide common display names for tags and allow labeling groups of tags as measuring key types of data like performance or production.  ### Best Practices Under the current implementation, the Oden API does not rate limit requests from clients.  However, rate limiting will be introduced in the near future and it is recommended that users design their API clients to not exceed a request rate of **one per second**.  ### Schema All v2 API access is over HTTPS and accessed from https://api.oden.app/v2 All data is sent and received as JSON.  API requests with duplicate keys will process only the data for the first key detected and ignore the rest, so it's not recommended. Batching multiple messages in this way is currently not possible.   - Example of duplicate key in JSON: {\"raw_data\":{\"scrap\":\"10\",\"scrap\":\"100\"}}  All timestamps are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format:    `YYYY-MM-DDTHH:MM:SSZ`  All durations are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format with the largest unit of time being the hour:     `PT[n]H[n]M[n]S`  All timestamps sent to the API in POST requests should be in ISO 8601 format. ### HTTP Verbs The ONLY HTTP call type (sometimes called *verb* or *method*) used within Oden's API is **POST**. There are three actions supported via a **POST**; call, search, set, and delete, together supporting CRUD operations;   - **search** requests are used to search for and *read* objects in the Oden Platform       - All Oden Objects may be uniquely identified by some combination of, or a single, parameter.         - Ex a `line` my be identified by either:           - `id`           - `name` AND `factory`   - **set** requests are used to *create* or *update* objects   - **delete** requests are used to *delete* objects. If a delete endpoint is not yet implemented for a given object, users may choose to update the values of a specific entity to null or 0 values.  ### URI Components All endpoints may be accessed with the URI pattern: `https://api.oden.app/v2/{object}/{action}`  Where:   - `object` is the name of the object being requested:        - `factory`, `quality_test`, `interval`, `line`, etc...   - `action` is the name of the action being requested     - `search` , `set` , `delete`  e.g. `https://api.oden.app/v2/factory/search`  # Authentication Clients can authenticate through the v2 API using a Token provided by Oden. Tokens are opaque strings similar to [Bearer](https://swagger.io/docs/specification/authentication/bearer-authentication/) tokens that the client must pass in the [HTTP Authorization request header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Authorization) in every request. The syntax is as follows:  `Authorization: <type> <credentials>`  Where \\<type\\> is \"Token\" and \\<credentials\\> is the Token string. For example:  `Authorization: Token tokenStringProvidedByOden`  Authenticating with an invalid Token will return `401 Unauthorized Error`.  Authenticating with a Token that is not authorized to read requested data will return `403 Forbidden Error`.  Some endpoints may require requests to be broken out by machinegroup (i.e., line or factory) and the number of requests would scale accordingly. This multiplicity should be taken into consideration when deciding on the frequency the API client makes requests to the Oden endpoints.  To authenticate in this [UI](https://api.oden.app/v2/ui/), click the Lock icon, and copy/paste the token into the Authorize box. 
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: support@oden.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Oden.Client.FileParameter;
using OpenAPIDateConverter = Oden.Client.OpenAPIDateConverter;
using System.Reflection;

namespace Oden.Model
{
    /// <summary>
    /// Metadata about this interval, such as the associated run or the state category. Will differ based on the type of interval. 
    /// </summary>
    [JsonConverter(typeof(IntervalMetadataJsonConverter))]
    [DataContract(Name = "Interval_metadata")]
    public partial class IntervalMetadata : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalMetadata" /> class
        /// with the <see cref="BatchMetadata" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of BatchMetadata.</param>
        public IntervalMetadata(BatchMetadata actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalMetadata" /> class
        /// with the <see cref="RunMetadata" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of RunMetadata.</param>
        public IntervalMetadata(RunMetadata actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalMetadata" /> class
        /// with the <see cref="StateMetadata" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of StateMetadata.</param>
        public IntervalMetadata(StateMetadata actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalMetadata" /> class
        /// with the <see cref="CustomMetadata" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of CustomMetadata.</param>
        public IntervalMetadata(CustomMetadata actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(BatchMetadata) || value is BatchMetadata)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(CustomMetadata) || value is CustomMetadata)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(RunMetadata) || value is RunMetadata)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(StateMetadata) || value is StateMetadata)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: BatchMetadata, CustomMetadata, RunMetadata, StateMetadata");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `BatchMetadata`. If the actual instance is not `BatchMetadata`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of BatchMetadata</returns>
        public BatchMetadata GetBatchMetadata()
        {
            return (BatchMetadata)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `RunMetadata`. If the actual instance is not `RunMetadata`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of RunMetadata</returns>
        public RunMetadata GetRunMetadata()
        {
            return (RunMetadata)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `StateMetadata`. If the actual instance is not `StateMetadata`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of StateMetadata</returns>
        public StateMetadata GetStateMetadata()
        {
            return (StateMetadata)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `CustomMetadata`. If the actual instance is not `CustomMetadata`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of CustomMetadata</returns>
        public CustomMetadata GetCustomMetadata()
        {
            return (CustomMetadata)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntervalMetadata {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, IntervalMetadata.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of IntervalMetadata
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of IntervalMetadata</returns>
        public static IntervalMetadata FromJson(string jsonString)
        {
            IntervalMetadata newIntervalMetadata = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newIntervalMetadata;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(BatchMetadata).GetProperty("AdditionalProperties") == null)
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<BatchMetadata>(jsonString, IntervalMetadata.SerializerSettings));
                }
                else
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<BatchMetadata>(jsonString, IntervalMetadata.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("BatchMetadata");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into BatchMetadata: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(CustomMetadata).GetProperty("AdditionalProperties") == null)
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<CustomMetadata>(jsonString, IntervalMetadata.SerializerSettings));
                }
                else
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<CustomMetadata>(jsonString, IntervalMetadata.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("CustomMetadata");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into CustomMetadata: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(RunMetadata).GetProperty("AdditionalProperties") == null)
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<RunMetadata>(jsonString, IntervalMetadata.SerializerSettings));
                }
                else
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<RunMetadata>(jsonString, IntervalMetadata.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("RunMetadata");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into RunMetadata: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(StateMetadata).GetProperty("AdditionalProperties") == null)
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<StateMetadata>(jsonString, IntervalMetadata.SerializerSettings));
                }
                else
                {
                    newIntervalMetadata = new IntervalMetadata(JsonConvert.DeserializeObject<StateMetadata>(jsonString, IntervalMetadata.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("StateMetadata");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into StateMetadata: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + String.Join(",", matchedTypes));
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newIntervalMetadata;
        }


        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// Custom JSON converter for IntervalMetadata
    /// </summary>
    public class IntervalMetadataJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(IntervalMetadata).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return IntervalMetadata.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return IntervalMetadata.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
