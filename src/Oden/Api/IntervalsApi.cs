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
    public interface IIntervalsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        List<Interval> V2IntervalDeletePost(Interval interval);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        ApiResponse<List<Interval>> V2IntervalDeletePostWithHttpInfo(Interval interval);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        List<Interval> V2IntervalSearchPost(Interval interval);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        ApiResponse<List<Interval>> V2IntervalSearchPostWithHttpInfo(Interval interval);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        List<Interval> V2IntervalSetPost(Interval interval);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        ApiResponse<List<Interval>> V2IntervalSetPostWithHttpInfo(Interval interval);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <returns>List&lt;IntervalType&gt;</returns>
        List<IntervalType> V2IntervalTypeSearchPost(IntervalType intervalType);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <returns>ApiResponse of List&lt;IntervalType&gt;</returns>
        ApiResponse<List<IntervalType>> V2IntervalTypeSearchPostWithHttpInfo(IntervalType intervalType);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        List<Interval> V2IntervalUpdatePost(Interval interval);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        ApiResponse<List<Interval>> V2IntervalUpdatePostWithHttpInfo(Interval interval);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <returns>V2IntervalsDeletePost200Response</returns>
        V2IntervalsDeletePost200Response V2IntervalsDeletePost(IntervalBulkDelete intervalBulkDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <returns>ApiResponse of V2IntervalsDeletePost200Response</returns>
        ApiResponse<V2IntervalsDeletePost200Response> V2IntervalsDeletePostWithHttpInfo(IntervalBulkDelete intervalBulkDelete);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> V2IntervalsSetPost(IntervalBulkCreate intervalBulkCreate);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> V2IntervalsSetPostWithHttpInfo(IntervalBulkCreate intervalBulkCreate);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <returns>V2IntervalsUpdatePost200Response</returns>
        V2IntervalsUpdatePost200Response V2IntervalsUpdatePost(IntervalBulkUpdate intervalBulkUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <returns>ApiResponse of V2IntervalsUpdatePost200Response</returns>
        ApiResponse<V2IntervalsUpdatePost200Response> V2IntervalsUpdatePostWithHttpInfo(IntervalBulkUpdate intervalBulkUpdate);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIntervalsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        System.Threading.Tasks.Task<List<Interval>> V2IntervalDeletePostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Interval>>> V2IntervalDeletePostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        System.Threading.Tasks.Task<List<Interval>> V2IntervalSearchPostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Interval>>> V2IntervalSearchPostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        System.Threading.Tasks.Task<List<Interval>> V2IntervalSetPostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Interval>>> V2IntervalSetPostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;IntervalType&gt;</returns>
        System.Threading.Tasks.Task<List<IntervalType>> V2IntervalTypeSearchPostAsync(IntervalType intervalType, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;IntervalType&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<IntervalType>>> V2IntervalTypeSearchPostWithHttpInfoAsync(IntervalType intervalType, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        System.Threading.Tasks.Task<List<Interval>> V2IntervalUpdatePostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Interval>>> V2IntervalUpdatePostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of V2IntervalsDeletePost200Response</returns>
        System.Threading.Tasks.Task<V2IntervalsDeletePost200Response> V2IntervalsDeletePostAsync(IntervalBulkDelete intervalBulkDelete, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (V2IntervalsDeletePost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<V2IntervalsDeletePost200Response>> V2IntervalsDeletePostWithHttpInfoAsync(IntervalBulkDelete intervalBulkDelete, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> V2IntervalsSetPostAsync(IntervalBulkCreate intervalBulkCreate, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> V2IntervalsSetPostWithHttpInfoAsync(IntervalBulkCreate intervalBulkCreate, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of V2IntervalsUpdatePost200Response</returns>
        System.Threading.Tasks.Task<V2IntervalsUpdatePost200Response> V2IntervalsUpdatePostAsync(IntervalBulkUpdate intervalBulkUpdate, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </remarks>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (V2IntervalsUpdatePost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<V2IntervalsUpdatePost200Response>> V2IntervalsUpdatePostWithHttpInfoAsync(IntervalBulkUpdate intervalBulkUpdate, System.Threading.CancellationToken cancellationToken = default);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIntervalsApi : IIntervalsApiSync, IIntervalsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IntervalsApi : IDisposable, IIntervalsApi
    {
        private Oden.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public IntervalsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public IntervalsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public IntervalsApi(Oden.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public IntervalsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class.
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
        public IntervalsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class using Configuration object.
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
        public IntervalsApi(HttpClient client, Oden.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="IntervalsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IntervalsApi(Oden.Client.ISynchronousClient client, Oden.Client.IAsynchronousClient asyncClient, Oden.Client.IReadableConfiguration configuration)
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
        ///  Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        public List<Interval> V2IntervalDeletePost(Interval interval)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = V2IntervalDeletePostWithHttpInfo(interval);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        public Oden.Client.ApiResponse<List<Interval>> V2IntervalDeletePostWithHttpInfo(Interval interval)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalDeletePost");

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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Interval>>("/v2/interval/delete", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalDeletePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        public async System.Threading.Tasks.Task<List<Interval>> V2IntervalDeletePostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = await V2IntervalDeletePostWithHttpInfoAsync(interval, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Delete an interval by &#x60;type&#x60;, &#x60;line&#x60;, and &#x60;id&#x60;  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60;  The examples below use placeholder IDs - replace with actual IDs from your system. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Interval>>> V2IntervalDeletePostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalDeletePost");


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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Interval>>("/v2/interval/delete", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalDeletePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        public List<Interval> V2IntervalSearchPost(Interval interval)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = V2IntervalSearchPostWithHttpInfo(interval);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        public Oden.Client.ApiResponse<List<Interval>> V2IntervalSearchPostWithHttpInfo(Interval interval)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalSearchPost");

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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Interval>>("/v2/interval/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        public async System.Threading.Tasks.Task<List<Interval>> V2IntervalSearchPostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = await V2IntervalSearchPostWithHttpInfoAsync(interval, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Searches for intervals by &#x60;type&#x60;, &#x60;line&#x60; and other optional parameters:  - &#x60;id&#x60; (for a specific Interval) - &#x60;match: unique&#x60; or omit  OR  - &#x60;match : last&#x60; for the most recent Interval of the given type on the given line  OR  - &#x60;start_time&#x60; and &#x60;end_time&#x60; (for a range of Intervals over a period of time) - &#x60;match: all&#x60; for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - &#x60;name&#x60; (only for Intervals with a matching name) 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Interval>>> V2IntervalSearchPostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalSearchPost");


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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Interval>>("/v2/interval/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        public List<Interval> V2IntervalSetPost(Interval interval)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = V2IntervalSetPostWithHttpInfo(interval);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        public Oden.Client.ApiResponse<List<Interval>> V2IntervalSetPostWithHttpInfo(Interval interval)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalSetPost");

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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Interval>>("/v2/interval/set", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalSetPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        public async System.Threading.Tasks.Task<List<Interval>> V2IntervalSetPostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = await V2IntervalSetPostWithHttpInfoAsync(interval, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Create or update an Interval.  Must include &#x60;line&#x60; and &#x60;type&#x60;. &#x60;match&#x60; must be omitted, &#x60;unique&#x60; or &#x60;last&#x60;   - If &#x60;id&#x60; is not supplied, a new Interval will be created.   - If &#x60;id&#x60; is supplied, existing Interval will be updated. This interval&#39;s start time can be modified using &#x60;start_time&#x60; field.  To update a specific interval supply the &#x60;id&#x60; of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given &#x60;type&#x60; on a &#x60;line&#x60; one may use &#x60;match: last&#x60; and omit &#x60;id&#x60;  For &#x60;RUN&#x60; type: if &#x60;product&#x60; and/or &#x60;product_mapping&#x60; does not exist a new one will be created. Further a &#x60;target&#x60; may be set by adding a &#x60;target&#x60; to the metadata field. The &#x60;line&#x60; and &#x60;product&#x60; for this target will be the same as the interval.  Please see examples for more specific information. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Interval>>> V2IntervalSetPostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalSetPost");


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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Interval>>("/v2/interval/set", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalSetPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <returns>List&lt;IntervalType&gt;</returns>
        public List<IntervalType> V2IntervalTypeSearchPost(IntervalType intervalType)
        {
            Oden.Client.ApiResponse<List<IntervalType>> localVarResponse = V2IntervalTypeSearchPostWithHttpInfo(intervalType);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <returns>ApiResponse of List&lt;IntervalType&gt;</returns>
        public Oden.Client.ApiResponse<List<IntervalType>> V2IntervalTypeSearchPostWithHttpInfo(IntervalType intervalType)
        {
            // verify the required parameter 'intervalType' is set
            if (intervalType == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalType' when calling IntervalsApi->V2IntervalTypeSearchPost");

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

            localVarRequestOptions.Data = intervalType;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<IntervalType>>("/v2/interval_type/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalTypeSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;IntervalType&gt;</returns>
        public async System.Threading.Tasks.Task<List<IntervalType>> V2IntervalTypeSearchPostAsync(IntervalType intervalType, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<IntervalType>> localVarResponse = await V2IntervalTypeSearchPostWithHttpInfoAsync(intervalType, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Search for Interval Types by &#x60;name&#x60;, &#x60;id&#x60;, &#x60;factory&#x60; or just &#x60;match: all&#x60; to return all Interval Types associated with the your organization. Basic Interval Types - - &#x60;RUN&#x60;, &#x60;BATCH&#x60;, and &#x60;STATE&#x60; - - are associated with every factory in Oden&#39;s system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalType"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;IntervalType&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<IntervalType>>> V2IntervalTypeSearchPostWithHttpInfoAsync(IntervalType intervalType, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'intervalType' is set
            if (intervalType == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalType' when calling IntervalsApi->V2IntervalTypeSearchPost");


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

            localVarRequestOptions.Data = intervalType;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<IntervalType>>("/v2/interval_type/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalTypeSearchPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>List&lt;Interval&gt;</returns>
        public List<Interval> V2IntervalUpdatePost(Interval interval)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = V2IntervalUpdatePostWithHttpInfo(interval);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <returns>ApiResponse of List&lt;Interval&gt;</returns>
        public Oden.Client.ApiResponse<List<Interval>> V2IntervalUpdatePostWithHttpInfo(Interval interval)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalUpdatePost");

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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<Interval>>("/v2/interval/update", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalUpdatePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Interval&gt;</returns>
        public async System.Threading.Tasks.Task<List<Interval>> V2IntervalUpdatePostAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<Interval>> localVarResponse = await V2IntervalUpdatePostWithHttpInfoAsync(interval, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include &#x60;line&#x60;, &#x60;type&#x60;, and &#x60;id&#x60;. The &#x60;id&#x60; must reference an existing interval.  This interval&#39;s properties can be modified using the following fields: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The &#x60;id&#x60; must be obtained from either: - The response when creating an interval via &#x60;/v2/interval/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="interval"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Interval&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<Interval>>> V2IntervalUpdatePostWithHttpInfoAsync(Interval interval, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'interval' when calling IntervalsApi->V2IntervalUpdatePost");


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

            localVarRequestOptions.Data = interval;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<Interval>>("/v2/interval/update", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalUpdatePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <returns>V2IntervalsDeletePost200Response</returns>
        public V2IntervalsDeletePost200Response V2IntervalsDeletePost(IntervalBulkDelete intervalBulkDelete)
        {
            Oden.Client.ApiResponse<V2IntervalsDeletePost200Response> localVarResponse = V2IntervalsDeletePostWithHttpInfo(intervalBulkDelete);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <returns>ApiResponse of V2IntervalsDeletePost200Response</returns>
        public Oden.Client.ApiResponse<V2IntervalsDeletePost200Response> V2IntervalsDeletePostWithHttpInfo(IntervalBulkDelete intervalBulkDelete)
        {
            // verify the required parameter 'intervalBulkDelete' is set
            if (intervalBulkDelete == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkDelete' when calling IntervalsApi->V2IntervalsDeletePost");

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

            localVarRequestOptions.Data = intervalBulkDelete;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<V2IntervalsDeletePost200Response>("/v2/intervals/delete", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsDeletePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of V2IntervalsDeletePost200Response</returns>
        public async System.Threading.Tasks.Task<V2IntervalsDeletePost200Response> V2IntervalsDeletePostAsync(IntervalBulkDelete intervalBulkDelete, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<V2IntervalsDeletePost200Response> localVarResponse = await V2IntervalsDeletePostWithHttpInfoAsync(intervalBulkDelete, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Delete a group of intervals by a single &#x60;type&#x60; and a single &#x60;line&#x60;, between &#x60;start_time&#x60; and &#x60;end_time&#x60;. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \&quot;batch\&quot; or \&quot;run\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkDelete"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (V2IntervalsDeletePost200Response)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<V2IntervalsDeletePost200Response>> V2IntervalsDeletePostWithHttpInfoAsync(IntervalBulkDelete intervalBulkDelete, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'intervalBulkDelete' is set
            if (intervalBulkDelete == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkDelete' when calling IntervalsApi->V2IntervalsDeletePost");


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

            localVarRequestOptions.Data = intervalBulkDelete;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<V2IntervalsDeletePost200Response>("/v2/intervals/delete", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsDeletePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> V2IntervalsSetPost(IntervalBulkCreate intervalBulkCreate)
        {
            Oden.Client.ApiResponse<List<string>> localVarResponse = V2IntervalsSetPostWithHttpInfo(intervalBulkCreate);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public Oden.Client.ApiResponse<List<string>> V2IntervalsSetPostWithHttpInfo(IntervalBulkCreate intervalBulkCreate)
        {
            // verify the required parameter 'intervalBulkCreate' is set
            if (intervalBulkCreate == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkCreate' when calling IntervalsApi->V2IntervalsSetPost");

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

            localVarRequestOptions.Data = intervalBulkCreate;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<List<string>>("/v2/intervals/set", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsSetPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> V2IntervalsSetPostAsync(IntervalBulkCreate intervalBulkCreate, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<List<string>> localVarResponse = await V2IntervalsSetPostWithHttpInfoAsync(intervalBulkCreate, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Create (Does not update) a group of custom intervals, for the same &#x60;type&#x60; and &#x60;line&#x60;. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \&quot;batch\&quot;, \&quot;run\&quot;, or \&quot;state\&quot; interval types. 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkCreate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<List<string>>> V2IntervalsSetPostWithHttpInfoAsync(IntervalBulkCreate intervalBulkCreate, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'intervalBulkCreate' is set
            if (intervalBulkCreate == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkCreate' when calling IntervalsApi->V2IntervalsSetPost");


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

            localVarRequestOptions.Data = intervalBulkCreate;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<string>>("/v2/intervals/set", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsSetPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <returns>V2IntervalsUpdatePost200Response</returns>
        public V2IntervalsUpdatePost200Response V2IntervalsUpdatePost(IntervalBulkUpdate intervalBulkUpdate)
        {
            Oden.Client.ApiResponse<V2IntervalsUpdatePost200Response> localVarResponse = V2IntervalsUpdatePostWithHttpInfo(intervalBulkUpdate);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <returns>ApiResponse of V2IntervalsUpdatePost200Response</returns>
        public Oden.Client.ApiResponse<V2IntervalsUpdatePost200Response> V2IntervalsUpdatePostWithHttpInfo(IntervalBulkUpdate intervalBulkUpdate)
        {
            // verify the required parameter 'intervalBulkUpdate' is set
            if (intervalBulkUpdate == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkUpdate' when calling IntervalsApi->V2IntervalsUpdatePost");

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

            localVarRequestOptions.Data = intervalBulkUpdate;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<V2IntervalsUpdatePost200Response>("/v2/intervals/update", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsUpdatePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of V2IntervalsUpdatePost200Response</returns>
        public async System.Threading.Tasks.Task<V2IntervalsUpdatePost200Response> V2IntervalsUpdatePostAsync(IntervalBulkUpdate intervalBulkUpdate, System.Threading.CancellationToken cancellationToken = default)
        {
            Oden.Client.ApiResponse<V2IntervalsUpdatePost200Response> localVarResponse = await V2IntervalsUpdatePostWithHttpInfoAsync(intervalBulkUpdate, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the &#x60;intervals&#x60; array must include an &#x60;id&#x60; that references an existing interval.  Updatable fields for each interval: - &#x60;name&#x60;: Update the interval name - &#x60;start_time&#x60;: Modify the start time - &#x60;end_time&#x60;: Modify the end time - &#x60;metadata&#x60;: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same &#x60;type&#x60; and on the same &#x60;line&#x60;  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via &#x60;/v2/interval/set&#x60; or &#x60;/v2/intervals/set&#x60; - Searching for intervals via &#x60;/v2/interval/search&#x60; 
        /// </summary>
        /// <exception cref="Oden.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="intervalBulkUpdate"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (V2IntervalsUpdatePost200Response)</returns>
        public async System.Threading.Tasks.Task<Oden.Client.ApiResponse<V2IntervalsUpdatePost200Response>> V2IntervalsUpdatePostWithHttpInfoAsync(IntervalBulkUpdate intervalBulkUpdate, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'intervalBulkUpdate' is set
            if (intervalBulkUpdate == null)
                throw new Oden.Client.ApiException(400, "Missing required parameter 'intervalBulkUpdate' when calling IntervalsApi->V2IntervalsUpdatePost");


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

            localVarRequestOptions.Data = intervalBulkUpdate;

            // authentication (APIKeyAuth) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<V2IntervalsUpdatePost200Response>("/v2/intervals/update", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2IntervalsUpdatePost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
