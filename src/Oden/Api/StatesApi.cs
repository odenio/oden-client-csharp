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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Oden.Client;
using Oden.Model;

namespace Oden.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStatesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Search state categories
        /// </summary>
        /// <remarks>
        /// Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <returns>List&lt;StateCategoryDetail&gt;</returns>
        List<StateCategoryDetail> SearchStateCategories(StateCategorySearch stateCategorySearch);

        /// <summary>
        /// Search state categories
        /// </summary>
        /// <remarks>
        /// Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <returns>ApiResponse of List&lt;StateCategoryDetail&gt;</returns>
        ApiResponse<List<StateCategoryDetail>> SearchStateCategoriesWithHttpInfo(StateCategorySearch stateCategorySearch);
        /// <summary>
        /// Search state reasons on one or more lines
        /// </summary>
        /// <remarks>
        /// Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <returns>List&lt;StateReasonDetail&gt;</returns>
        List<StateReasonDetail> SearchStateReasons(StateReasonSearch stateReasonSearch);

        /// <summary>
        /// Search state reasons on one or more lines
        /// </summary>
        /// <remarks>
        /// Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <returns>ApiResponse of List&lt;StateReasonDetail&gt;</returns>
        ApiResponse<List<StateReasonDetail>> SearchStateReasonsWithHttpInfo(StateReasonSearch stateReasonSearch);
        /// <summary>
        /// Create or update a state category
        /// </summary>
        /// <remarks>
        /// **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <returns>StateCategoryDetail</returns>
        StateCategoryDetail SetStateCategory(StateCategorySet stateCategorySet);

        /// <summary>
        /// Create or update a state category
        /// </summary>
        /// <remarks>
        /// **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <returns>ApiResponse of StateCategoryDetail</returns>
        ApiResponse<StateCategoryDetail> SetStateCategoryWithHttpInfo(StateCategorySet stateCategorySet);
        /// <summary>
        /// Create a state reason on one or more lines
        /// </summary>
        /// <remarks>
        /// Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <returns>List&lt;StateReasonDetail&gt;</returns>
        List<StateReasonDetail> SetStateReasons(StateReasonSet stateReasonSet);

        /// <summary>
        /// Create a state reason on one or more lines
        /// </summary>
        /// <remarks>
        /// Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <returns>ApiResponse of List&lt;StateReasonDetail&gt;</returns>
        ApiResponse<List<StateReasonDetail>> SetStateReasonsWithHttpInfo(StateReasonSet stateReasonSet);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStatesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Search state categories
        /// </summary>
        /// <remarks>
        /// Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateCategoryDetail&gt;</returns>
        System.Threading.Tasks.Task<List<StateCategoryDetail>> SearchStateCategoriesAsync(StateCategorySearch stateCategorySearch, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Search state categories
        /// </summary>
        /// <remarks>
        /// Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateCategoryDetail&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<StateCategoryDetail>>> SearchStateCategoriesWithHttpInfoAsync(StateCategorySearch stateCategorySearch, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Search state reasons on one or more lines
        /// </summary>
        /// <remarks>
        /// Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateReasonDetail&gt;</returns>
        System.Threading.Tasks.Task<List<StateReasonDetail>> SearchStateReasonsAsync(StateReasonSearch stateReasonSearch, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Search state reasons on one or more lines
        /// </summary>
        /// <remarks>
        /// Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateReasonDetail&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<StateReasonDetail>>> SearchStateReasonsWithHttpInfoAsync(StateReasonSearch stateReasonSearch, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create or update a state category
        /// </summary>
        /// <remarks>
        /// **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StateCategoryDetail</returns>
        System.Threading.Tasks.Task<StateCategoryDetail> SetStateCategoryAsync(StateCategorySet stateCategorySet, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Create or update a state category
        /// </summary>
        /// <remarks>
        /// **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StateCategoryDetail)</returns>
        System.Threading.Tasks.Task<ApiResponse<StateCategoryDetail>> SetStateCategoryWithHttpInfoAsync(StateCategorySet stateCategorySet, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a state reason on one or more lines
        /// </summary>
        /// <remarks>
        /// Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateReasonDetail&gt;</returns>
        System.Threading.Tasks.Task<List<StateReasonDetail>> SetStateReasonsAsync(StateReasonSet stateReasonSet, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a state reason on one or more lines
        /// </summary>
        /// <remarks>
        /// Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateReasonDetail&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<StateReasonDetail>>> SetStateReasonsWithHttpInfoAsync(StateReasonSet stateReasonSet, System.Threading.CancellationToken cancellationToken = default);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStatesApi : IStatesApiSync, IStatesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class StatesApi : IDisposable, IStatesApi
    {
        private Oden.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public StatesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public StatesApi(string basePath)
        {
            this.Configuration = Oden.Client.Configuration.MergeConfigurations(
                Oden.Client.GlobalConfiguration.Instance,
                new Oden.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Oden.Client.ApiClient(this.Configuration.BasePath);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Oden.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public StatesApi(Oden.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Oden.Client.Configuration.MergeConfigurations(
                Oden.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Oden.Client.ApiClient(this.Configuration.BasePath);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Oden.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public StatesApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public StatesApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Oden.Client.Configuration.MergeConfigurations(
                Oden.Client.GlobalConfiguration.Instance,
                new Oden.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Oden.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Oden.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public StatesApi(HttpClient client, Oden.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Oden.Client.Configuration.MergeConfigurations(
                Oden.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Oden.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Oden.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StatesApi(Oden.Client.ISynchronousClient client, Oden.Client.IAsynchronousClient asyncClient, Oden.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Oden.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            this.ApiClient?.Dispose();
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public Oden.Client.ApiClient ApiClient { get; set; } = null;

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Oden.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Oden.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Oden.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Oden.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Search state categories Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <returns>List&lt;StateCategoryDetail&gt;</returns>
        public List<StateCategoryDetail> SearchStateCategories(StateCategorySearch stateCategorySearch)
        {
            Oden.Client.ApiResponse<List<StateCategoryDetail>> localVarResponse = SearchStateCategoriesWithHttpInfo(stateCategorySearch);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search state categories Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <returns>ApiResponse of List&lt;StateCategoryDetail&gt;</returns>
        public Oden.Client.ApiResponse<List<StateCategoryDetail>> SearchStateCategoriesWithHttpInfo(StateCategorySearch stateCategorySearch)
        {
            // verify the required parameter 'stateCategorySearch' is set
            if (stateCategorySearch == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateCategorySearch' when calling StatesApi->SearchStateCategories");

            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateCategorySearch;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<StateCategoryDetail>>("/v2/state_category/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchStateCategories", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search state categories Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateCategoryDetail&gt;</returns>
        public async System.Threading.Tasks.Task<List<StateCategoryDetail>> SearchStateCategoriesAsync(StateCategorySearch stateCategorySearch, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<StateCategoryDetail>> localVarResponse = await SearchStateCategoriesWithHttpInfoAsync(stateCategorySearch, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search state categories Returns the state categories available to your organization, including Oden&#39;s built-in ones. Filter by &#x60;id&#x60; or &#x60;name&#x60;; omit both to list all. Built-in categories have no &#x60;organization&#x60; and cannot be modified.  &#x60;type&#x60; summarises how the platform treats time in the category: - &#x60;uptime&#x60;: producing good product - &#x60;scrapping&#x60;: running but not producing good product - &#x60;planned_downtime&#x60;, &#x60;unplanned_downtime&#x60;: not running 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateCategoryDetail&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<StateCategoryDetail>>> SearchStateCategoriesWithHttpInfoAsync(StateCategorySearch stateCategorySearch, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'stateCategorySearch' is set
            if (stateCategorySearch == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateCategorySearch' when calling StatesApi->SearchStateCategories");


            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateCategorySearch;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<StateCategoryDetail>>("/v2/state_category/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchStateCategories", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search state reasons on one or more lines Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <returns>List&lt;StateReasonDetail&gt;</returns>
        public List<StateReasonDetail> SearchStateReasons(StateReasonSearch stateReasonSearch)
        {
            Oden.Client.ApiResponse<List<StateReasonDetail>> localVarResponse = SearchStateReasonsWithHttpInfo(stateReasonSearch);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search state reasons on one or more lines Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <returns>ApiResponse of List&lt;StateReasonDetail&gt;</returns>
        public Oden.Client.ApiResponse<List<StateReasonDetail>> SearchStateReasonsWithHttpInfo(StateReasonSearch stateReasonSearch)
        {
            // verify the required parameter 'stateReasonSearch' is set
            if (stateReasonSearch == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateReasonSearch' when calling StatesApi->SearchStateReasons");

            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateReasonSearch;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<StateReasonDetail>>("/v2/state_reason/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchStateReasons", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search state reasons on one or more lines Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateReasonDetail&gt;</returns>
        public async System.Threading.Tasks.Task<List<StateReasonDetail>> SearchStateReasonsAsync(StateReasonSearch stateReasonSearch, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<StateReasonDetail>> localVarResponse = await SearchStateReasonsWithHttpInfoAsync(stateReasonSearch, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search state reasons on one or more lines Returns the state reasons defined on every line in &#x60;lines&#x60; (required; each by &#x60;id&#x60;, or by &#x60;name&#x60; plus &#x60;factory&#x60;), optionally restricted to one &#x60;category&#x60; (by &#x60;id&#x60; or &#x60;name&#x60;). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with &#x60;active: false&#x60;. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSearch"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateReasonDetail&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<StateReasonDetail>>> SearchStateReasonsWithHttpInfoAsync(StateReasonSearch stateReasonSearch, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'stateReasonSearch' is set
            if (stateReasonSearch == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateReasonSearch' when calling StatesApi->SearchStateReasons");


            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateReasonSearch;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<StateReasonDetail>>("/v2/state_reason/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchStateReasons", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update a state category **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <returns>StateCategoryDetail</returns>
        public StateCategoryDetail SetStateCategory(StateCategorySet stateCategorySet)
        {
            Oden.Client.ApiResponse<StateCategoryDetail> localVarResponse = SetStateCategoryWithHttpInfo(stateCategorySet);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update a state category **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <returns>ApiResponse of StateCategoryDetail</returns>
        public Oden.Client.ApiResponse<StateCategoryDetail> SetStateCategoryWithHttpInfo(StateCategorySet stateCategorySet)
        {
            // verify the required parameter 'stateCategorySet' is set
            if (stateCategorySet == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateCategorySet' when calling StatesApi->SetStateCategory");

            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateCategorySet;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<StateCategoryDetail>("/v2/state_category/set", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetStateCategory", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update a state category **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StateCategoryDetail</returns>
        public async System.Threading.Tasks.Task<StateCategoryDetail> SetStateCategoryAsync(StateCategorySet stateCategorySet, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<StateCategoryDetail> localVarResponse = await SetStateCategoryWithHttpInfoAsync(stateCategorySet, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update a state category **Create** (no &#x60;id&#x60;): &#x60;name&#x60; and &#x60;type&#x60; are required. If a category with that &#x60;name&#x60; already exists for your organization and has the same &#x60;type&#x60;, it is returned unchanged; a different &#x60;type&#x60; is a 409.  **Update** (with &#x60;id&#x60;): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateCategorySet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StateCategoryDetail)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<StateCategoryDetail>> SetStateCategoryWithHttpInfoAsync(StateCategorySet stateCategorySet, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'stateCategorySet' is set
            if (stateCategorySet == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateCategorySet' when calling StatesApi->SetStateCategory");


            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateCategorySet;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<StateCategoryDetail>("/v2/state_category/set", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetStateCategory", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a state reason on one or more lines Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <returns>List&lt;StateReasonDetail&gt;</returns>
        public List<StateReasonDetail> SetStateReasons(StateReasonSet stateReasonSet)
        {
            Oden.Client.ApiResponse<List<StateReasonDetail>> localVarResponse = SetStateReasonsWithHttpInfo(stateReasonSet);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a state reason on one or more lines Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <returns>ApiResponse of List&lt;StateReasonDetail&gt;</returns>
        public Oden.Client.ApiResponse<List<StateReasonDetail>> SetStateReasonsWithHttpInfo(StateReasonSet stateReasonSet)
        {
            // verify the required parameter 'stateReasonSet' is set
            if (stateReasonSet == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateReasonSet' when calling StatesApi->SetStateReasons");

            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateReasonSet;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<StateReasonDetail>>("/v2/state_reason/set", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetStateReasons", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a state reason on one or more lines Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;StateReasonDetail&gt;</returns>
        public async System.Threading.Tasks.Task<List<StateReasonDetail>> SetStateReasonsAsync(StateReasonSet stateReasonSet, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<StateReasonDetail>> localVarResponse = await SetStateReasonsWithHttpInfoAsync(stateReasonSet, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a state reason on one or more lines Ensures the reason &#x60;name&#x60; exists under &#x60;category&#x60; on every line in &#x60;lines&#x60;. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  &#x60;category&#x60; may be given by &#x60;id&#x60; or &#x60;name&#x60; and must be one of your organization&#39;s own categories; Oden&#39;s built-in categories are read-only. &#x60;active&#x60; defaults to true and also re-activates an existing inactive reason (or deactivates with &#x60;false&#x60;).  Requires an organization admin token. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stateReasonSet"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;StateReasonDetail&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<StateReasonDetail>>> SetStateReasonsWithHttpInfoAsync(StateReasonSet stateReasonSet, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'stateReasonSet' is set
            if (stateReasonSet == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'stateReasonSet' when calling StatesApi->SetStateReasons");


            Oden.Client.RequestOptions localVarRequestOptions = new Oden.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Oden.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Oden.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = stateReasonSet;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<StateReasonDetail>>("/v2/state_reason/set", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetStateReasons", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
