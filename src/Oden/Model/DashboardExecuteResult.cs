/*
 * Oden API
 *
 * The Oden Private Partner API exposes RESTful API endpoints for clients to get, create and update data on the Oden Platform.  The API is based on the OpenAPI 3.0 specification. ### Current Version The URL, and host, for the current version is [https://api.oden.app/v2](https://api.oden.app/v2).  ### Oden's Data Model - **Organization**: This represents the Organization registered as an Oden customer. An organization has an associated collection of users, factories, lines, etc. This is the entity a specific authentication token is associated with. - **Asset** or **Machinegroup**: Assets, or machinegroups, are collections of machines, which may either be a **Factory** or a **Line**:   - **Factory**: Factories are collections of lines, representing a particular manufacturing location.     - **Line**: Lines are collections of machines, often representing a particular production line. Lines may also have **Products** mapped to them, indicating what is currently being manufactured by the specific line.       - **Machine**: Machines are the physical machines that make up a line - **Product**: Products capture what entities a manufacturer produces - **Interval**: An interval is a period of time that takes place on a manufacturing line and expresses some business concern. It's Oden's way of making metrics aggregatable, traceable, and relatable to a manufacturer.   - **Run**: A run is a production interval that labels a period of production as being work on some single product   - **Batch**: A batch is a production interval that represents a portion of a particular run   - **State**: A state is an interval that tracks the availability or utilization of a line     - **State Category**: A state category describes what state a line is in - such as ex. uptime, downtime, scrapping, etc.     - **State Reason**: A state reason describes why a line is in a particular state - such as \"maintenance\" being a reason for the category \"downtime\".   - **Custom**: A custom interval can track any other type of interval-based data a manufacturer might want to analyze. These are created on a per-factory basis. - **Target**: Targets specify values and upper/lower thresholds for metrics when specific products are running on specific lines - **Scrap/Yield**: Scrap/yield output specifies amount of produced product on a line during either a run or batch interval. Oden will categorize all output as either scrap or yield - as specified by the Scrap Yield Schema for a given factory. If you have other categories, like rework/blocked/off-grade, you must choose between categorizing those amounts as either good or bad production by specifying as scrap or yield. Clients may also add scrap codes (i.e., reasons) to a given Scrap Yield Data entry.   - **Scrap Code**: A scrap code is a code that explains the reason for a scrap/yield raw data input - such as \"Rework\" - **Quality Test**: Quality Tests are results of quality assurance tests done on site, and uploaded to Oden. They may be attached to a single Batch or Run. - **Metric**: Known in factories as \"tags\", metrics are the raw data that is collected by Oden from the machines and devices on the factory floor. - **Metric Group**: Metric groups are metrics that represent the same thing across different lines. They provide common display names for tags and allow labeling groups of tags as measuring key types of data like performance or production. - **Maintenance Work Order**: A maintenance work order can be used to track work orders maintained in MaintainX and associate them with an Oden line.   ### Best Practices Under the current implementation, the Oden API does not rate limit requests from clients.  However, rate limiting will be introduced in the near future and it is recommended that users design their API clients to not exceed a request rate of **one per second**.  ### Schema All v2 API access is over HTTPS and accessed from https://api.oden.app/v2 All data is sent and received as JSON.  API requests with duplicate keys will process only the data for the first key detected and ignore the rest, so it's not recommended. Batching multiple messages in this way is currently not possible.   - Example of duplicate key in JSON: {\"raw_data\":{\"scrap\":\"10\",\"scrap\":\"100\"}}  All timestamps are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format:    `YYYY-MM-DDTHH:MM:SSZ`  All durations are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format with the largest unit of time being the hour:     `PT[n]H[n]M[n]S`  All timestamps sent to the API in POST requests should be in ISO 8601 format. ### HTTP Verbs The ONLY HTTP call type (sometimes called *verb* or *method*) used within Oden's API is **POST**. There are three actions supported via a **POST**; call, search, set, and delete, together supporting CRUD operations;   - **search** requests are used to search for and *read* objects in the Oden Platform       - All Oden Objects may be uniquely identified by some combination of, or a single, parameter.         - Ex a `line` my be identified by either:           - `id`           - `name` AND `factory`   - **set** requests are used to *create* or *update* objects   - **delete** requests are used to *delete* objects. If a delete endpoint is not yet implemented for a given object, users may choose to update the values of a specific entity to null or 0 values.  ### URI Components All endpoints may be accessed with the URI pattern: `https://api.oden.app/v2/{object}/{action}`  Where:   - `object` is the name of the object being requested:        - `factory`, `quality_test`, `interval`, `line`, etc...   - `action` is the name of the action being requested     - `search` , `set` , `delete`  e.g. `https://api.oden.app/v2/factory/search`  # Authentication Clients can authenticate through the v2 API using a Token provided by Oden. Tokens are opaque strings similar to [Bearer](https://swagger.io/docs/specification/authentication/bearer-authentication/) tokens that the client must pass in the [HTTP Authorization request header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Authorization) in every request. The syntax is as follows:  `Authorization: <type> <credentials>`  Where \\<type\\> is \"Token\" and \\<credentials\\> is the Token string. For example:  `Authorization: Token tokenStringProvidedByOden`  Authenticating with an invalid Token will return `401 Unauthorized Error`.  Authenticating with a Token that is not authorized to read requested data will return `403 Forbidden Error`.  Some endpoints may require requests to be broken out by machinegroup (i.e., line or factory) and the number of requests would scale accordingly. This multiplicity should be taken into consideration when deciding on the frequency the API client makes requests to the Oden endpoints.  To authenticate in this [UI](https://api.oden.app/v2/ui/), click the Lock icon, and copy/paste the token into the Authorize box. 
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
using System.ComponentModel.DataAnnotations;
using FileParameter = Oden.Client.FileParameter;
using OpenAPIDateConverter = Oden.Client.OpenAPIDateConverter;

namespace Oden.Model
{
    /// <summary>
    /// Executed output of a single dashboard module.
    /// </summary>
    [DataContract(Name = "DashboardExecuteResult")]
    public partial class DashboardExecuteResult : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardExecuteResult" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DashboardExecuteResult() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardExecuteResult" /> class.
        /// </summary>
        /// <param name="moduleId">moduleId (required).</param>
        /// <param name="moduleName">moduleName (required).</param>
        /// <param name="moduleType">The module&#39;s stored visualization (e.g. &#x60;table&#x60;, &#x60;line_chart&#x60;, &#x60;bar_chart&#x60;). Type label only — does not change the response shape.  (required).</param>
        /// <param name="range">range.</param>
        /// <param name="filtersApplied">Echo of the filter dimensions that were applied, resolved to human-readable values where possible (e.g. line names instead of IDs). .</param>
        /// <param name="columns">Column metadata. &#x60;type&#x60; is derived from the first non-null cell in the column. Null when the module errored. .</param>
        /// <param name="rows">Row data as objects keyed by column name (not positional arrays). Values are typed JSON natively. Null when the module errored. .</param>
        /// <param name="error">Set to a short message when the module failed to parse or execute. Null on success. .</param>
        public DashboardExecuteResult(Guid moduleId = default, string moduleName = default, string moduleType = default, DashboardExecuteResultRange range = default, Dictionary<string, Object> filtersApplied = default, List<DashboardColumnSpec> columns = default, List<Dictionary<string, Object>> rows = default, string error = default)
        {
            this.ModuleId = moduleId;
            // to ensure "moduleName" is required (not null)
            if (moduleName == null)
            {
                throw new ArgumentNullException("moduleName is a required property for DashboardExecuteResult and cannot be null");
            }
            this.ModuleName = moduleName;
            // to ensure "moduleType" is required (not null)
            if (moduleType == null)
            {
                throw new ArgumentNullException("moduleType is a required property for DashboardExecuteResult and cannot be null");
            }
            this.ModuleType = moduleType;
            this.Range = range;
            this.FiltersApplied = filtersApplied;
            this.Columns = columns;
            this.Rows = rows;
            this.Error = error;
        }

        /// <summary>
        /// Gets or Sets ModuleId
        /// </summary>
        [DataMember(Name = "module_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid ModuleId { get; set; }

        /// <summary>
        /// Gets or Sets ModuleName
        /// </summary>
        [DataMember(Name = "module_name", IsRequired = true, EmitDefaultValue = true)]
        public string ModuleName { get; set; }

        /// <summary>
        /// The module&#39;s stored visualization (e.g. &#x60;table&#x60;, &#x60;line_chart&#x60;, &#x60;bar_chart&#x60;). Type label only — does not change the response shape. 
        /// </summary>
        /// <value>The module&#39;s stored visualization (e.g. &#x60;table&#x60;, &#x60;line_chart&#x60;, &#x60;bar_chart&#x60;). Type label only — does not change the response shape. </value>
        [DataMember(Name = "module_type", IsRequired = true, EmitDefaultValue = true)]
        public string ModuleType { get; set; }

        /// <summary>
        /// Gets or Sets Range
        /// </summary>
        [DataMember(Name = "range", EmitDefaultValue = false)]
        public DashboardExecuteResultRange Range { get; set; }

        /// <summary>
        /// Echo of the filter dimensions that were applied, resolved to human-readable values where possible (e.g. line names instead of IDs). 
        /// </summary>
        /// <value>Echo of the filter dimensions that were applied, resolved to human-readable values where possible (e.g. line names instead of IDs). </value>
        [DataMember(Name = "filters_applied", EmitDefaultValue = false)]
        public Dictionary<string, Object> FiltersApplied { get; set; }

        /// <summary>
        /// Column metadata. &#x60;type&#x60; is derived from the first non-null cell in the column. Null when the module errored. 
        /// </summary>
        /// <value>Column metadata. &#x60;type&#x60; is derived from the first non-null cell in the column. Null when the module errored. </value>
        [DataMember(Name = "columns", EmitDefaultValue = true)]
        public List<DashboardColumnSpec> Columns { get; set; }

        /// <summary>
        /// Row data as objects keyed by column name (not positional arrays). Values are typed JSON natively. Null when the module errored. 
        /// </summary>
        /// <value>Row data as objects keyed by column name (not positional arrays). Values are typed JSON natively. Null when the module errored. </value>
        [DataMember(Name = "rows", EmitDefaultValue = true)]
        public List<Dictionary<string, Object>> Rows { get; set; }

        /// <summary>
        /// Set to a short message when the module failed to parse or execute. Null on success. 
        /// </summary>
        /// <value>Set to a short message when the module failed to parse or execute. Null on success. </value>
        [DataMember(Name = "error", EmitDefaultValue = true)]
        public string Error { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DashboardExecuteResult {\n");
            sb.Append("  ModuleId: ").Append(ModuleId).Append("\n");
            sb.Append("  ModuleName: ").Append(ModuleName).Append("\n");
            sb.Append("  ModuleType: ").Append(ModuleType).Append("\n");
            sb.Append("  Range: ").Append(Range).Append("\n");
            sb.Append("  FiltersApplied: ").Append(FiltersApplied).Append("\n");
            sb.Append("  Columns: ").Append(Columns).Append("\n");
            sb.Append("  Rows: ").Append(Rows).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
