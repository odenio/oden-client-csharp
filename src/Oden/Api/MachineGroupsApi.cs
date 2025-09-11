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
    public interface IMachineGroupsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <returns>List&lt;Factory&gt;</returns>
        List<Factory> V2FactorySearchPost(Factory factory);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <returns>ApiResponse of List&lt;Factory&gt;</returns>
        ApiResponse<List<Factory>> V2FactorySearchPostWithHttpInfo(Factory factory);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <returns>List&lt;Line&gt;</returns>
        List<Line> V2LineSearchPost(Line line);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <returns>ApiResponse of List&lt;Line&gt;</returns>
        ApiResponse<List<Line>> V2LineSearchPostWithHttpInfo(Line line);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMachineGroupsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Factory&gt;</returns>
        System.Threading.Tasks.Task<List<Factory>> V2FactorySearchPostAsync(Factory factory, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Factory&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Factory>>> V2FactorySearchPostWithHttpInfoAsync(Factory factory, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Line&gt;</returns>
        System.Threading.Tasks.Task<List<Line>> V2LineSearchPostAsync(Line line, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Line&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Line>>> V2LineSearchPostWithHttpInfoAsync(Line line, System.Threading.CancellationToken cancellationToken = default);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMachineGroupsApi : IMachineGroupsApiSync, IMachineGroupsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class MachineGroupsApi : IDisposable, IMachineGroupsApi
    {
        private Oden.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public MachineGroupsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public MachineGroupsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public MachineGroupsApi(Oden.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public MachineGroupsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class.
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
        public MachineGroupsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class using Configuration object.
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
        public MachineGroupsApi(HttpClient client, Oden.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="MachineGroupsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MachineGroupsApi(Oden.Client.ISynchronousClient client, Oden.Client.IAsynchronousClient asyncClient, Oden.Client.IReadableConfiguration configuration)
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
        ///  Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <returns>List&lt;Factory&gt;</returns>
        public List<Factory> V2FactorySearchPost(Factory factory)
        {
            Oden.Client.ApiResponse<List<Factory>> localVarResponse = V2FactorySearchPostWithHttpInfo(factory);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <returns>ApiResponse of List&lt;Factory&gt;</returns>
        public Oden.Client.ApiResponse<List<Factory>> V2FactorySearchPostWithHttpInfo(Factory factory)
        {
            // verify the required parameter 'factory' is set
            if (factory == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'factory' when calling MachineGroupsApi->V2FactorySearchPost");

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

            localVarRequestOptions.Data = factory;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Factory>>("/v2/factory/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2FactorySearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Factory&gt;</returns>
        public async System.Threading.Tasks.Task<List<Factory>> V2FactorySearchPostAsync(Factory factory, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Factory>> localVarResponse = await V2FactorySearchPostWithHttpInfoAsync(factory, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for a specific Factory by a unique indentifier: - &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  OR  - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  Search for all factories: - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="factory"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Factory&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Factory>>> V2FactorySearchPostWithHttpInfoAsync(Factory factory, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'factory' is set
            if (factory == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'factory' when calling MachineGroupsApi->V2FactorySearchPost");


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

            localVarRequestOptions.Data = factory;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Factory>>("/v2/factory/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2FactorySearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <returns>List&lt;Line&gt;</returns>
        public List<Line> V2LineSearchPost(Line line)
        {
            Oden.Client.ApiResponse<List<Line>> localVarResponse = V2LineSearchPostWithHttpInfo(line);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <returns>ApiResponse of List&lt;Line&gt;</returns>
        public Oden.Client.ApiResponse<List<Line>> V2LineSearchPostWithHttpInfo(Line line)
        {
            // verify the required parameter 'line' is set
            if (line == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'line' when calling MachineGroupsApi->V2LineSearchPost");

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

            localVarRequestOptions.Data = line;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Line>>("/v2/line/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2LineSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Line&gt;</returns>
        public async System.Threading.Tasks.Task<List<Line>> V2LineSearchPostAsync(Line line, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Line>> localVarResponse = await V2LineSearchPostWithHttpInfoAsync(line, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for specific Line by any Line identifier. Either: - &#x60;id&#x60; - &#x60;match: unique&#x60; or omit  OR - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - line &#x60;name&#x60; - &#x60;match: unique&#x60; or omit  Search for all Lines for a given Factory: - &#x60;factory&#x60;   - &#x60;name&#x60; or &#x60;id&#x60; - &#x60;match: all&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="line"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Line&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Line>>> V2LineSearchPostWithHttpInfoAsync(Line line, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'line' is set
            if (line == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'line' when calling MachineGroupsApi->V2LineSearchPost");


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

            localVarRequestOptions.Data = line;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Line>>("/v2/line/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2LineSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
