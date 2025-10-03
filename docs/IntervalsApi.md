# Oden.Api.IntervalsApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V2IntervalDeletePost**](IntervalsApi.md#v2intervaldeletepost) | **POST** /v2/interval/delete |  |
| [**V2IntervalSearchPost**](IntervalsApi.md#v2intervalsearchpost) | **POST** /v2/interval/search |  |
| [**V2IntervalSetPost**](IntervalsApi.md#v2intervalsetpost) | **POST** /v2/interval/set |  |
| [**V2IntervalTypeSearchPost**](IntervalsApi.md#v2intervaltypesearchpost) | **POST** /v2/interval_type/search |  |
| [**V2IntervalsDeletePost**](IntervalsApi.md#v2intervalsdeletepost) | **POST** /v2/intervals/delete |  |
| [**V2IntervalsSetPost**](IntervalsApi.md#v2intervalssetpost) | **POST** /v2/intervals/set |  |

<a id="v2intervaldeletepost"></a>
# **V2IntervalDeletePost**
> List&lt;Interval&gt; V2IntervalDeletePost (Interval interval)



Delete an interval by `type`, `line`, and `id`  **Note:** The `id` must be obtained from either: - The response when creating an interval via `/v2/interval/set` - Searching for intervals via `/v2/interval/search`  The examples below use placeholder IDs - replace with actual IDs from your system. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalDeletePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var interval = new Interval(); // Interval | 

            try
            {
                List<Interval> result = apiInstance.V2IntervalDeletePost(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalDeletePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalDeletePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Interval>> response = apiInstance.V2IntervalDeletePostWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalDeletePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **interval** | [**Interval**](Interval.md) |  |  |

### Return type

[**List&lt;Interval&gt;**](Interval.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list containing the deleted interval. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2intervalsearchpost"></a>
# **V2IntervalSearchPost**
> List&lt;Interval&gt; V2IntervalSearchPost (Interval interval)



Searches for intervals by `type`, `line` and other optional parameters:  - `id` (for a specific Interval) - `match: unique` or omit  OR  - `match : last` for the most recent Interval of the given type on the given line  OR  - `start_time` and `end_time` (for a range of Intervals over a period of time) - `match: all` for more than one result  OR  - match all intervals for all lines in a given factory  AND/OR  - `name` (only for Intervals with a matching name) 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalSearchPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var interval = new Interval(); // Interval | 

            try
            {
                List<Interval> result = apiInstance.V2IntervalSearchPost(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalSearchPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalSearchPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Interval>> response = apiInstance.V2IntervalSearchPostWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalSearchPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **interval** | [**Interval**](Interval.md) |  |  |

### Return type

[**List&lt;Interval&gt;**](Interval.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of intervals. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2intervalsetpost"></a>
# **V2IntervalSetPost**
> List&lt;Interval&gt; V2IntervalSetPost (Interval interval)



Create or update an Interval.  Must include `line` and `type`. `match` must be omitted, `unique` or `last`   - If `id` is not supplied, a new Interval will be created.   - If `id` is supplied, existing Interval will be updated. This interval's start time can be modified using `start_time` field.  To update a specific interval supply the `id` of that interval.  If the interval exists with all the same parameters nothing is done.  To update the most recent Interval of a given `type` on a `line` one may use `match: last` and omit `id`  For `RUN` type: if `product` and/or `product_mapping` does not exist a new one will be created. Further a `target` may be set by adding a `target` to the metadata field. The `line` and `product` for this target will be the same as the interval.  Please see examples for more specific information. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalSetPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var interval = new Interval(); // Interval | 

            try
            {
                List<Interval> result = apiInstance.V2IntervalSetPost(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalSetPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalSetPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Interval>> response = apiInstance.V2IntervalSetPostWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalSetPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **interval** | [**Interval**](Interval.md) |  |  |

### Return type

[**List&lt;Interval&gt;**](Interval.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated interval. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2intervaltypesearchpost"></a>
# **V2IntervalTypeSearchPost**
> List&lt;IntervalType&gt; V2IntervalTypeSearchPost (IntervalType intervalType)



Search for Interval Types by `name`, `id`, `factory` or just `match: all` to return all Interval Types associated with the your organization. Basic Interval Types - - `RUN`, `BATCH`, and `STATE` - - are associated with every factory in Oden's system. Custom Interval Types may be created by users, are set on a per factory basis, and may only describe Intervals on Lines associated with that Factory. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalTypeSearchPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var intervalType = new IntervalType(); // IntervalType | 

            try
            {
                List<IntervalType> result = apiInstance.V2IntervalTypeSearchPost(intervalType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalTypeSearchPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalTypeSearchPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<IntervalType>> response = apiInstance.V2IntervalTypeSearchPostWithHttpInfo(intervalType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalTypeSearchPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalType** | [**IntervalType**](IntervalType.md) |  |  |

### Return type

[**List&lt;IntervalType&gt;**](IntervalType.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful response |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2intervalsdeletepost"></a>
# **V2IntervalsDeletePost**
> V2IntervalsDeletePost200Response V2IntervalsDeletePost (IntervalBulkDelete intervalBulkDelete)



Delete a group of intervals by a single `type` and a single `line`, between `start_time` and `end_time`. Returns a list of intervals that were not deleted, and the number of intervals deleted.  Limitations: - Cannot exceed 15,000 intervals per request, or 30 days worth of data. - Currently does not support \"batch\" or \"run\" interval types. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalsDeletePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var intervalBulkDelete = new IntervalBulkDelete(); // IntervalBulkDelete | 

            try
            {
                V2IntervalsDeletePost200Response result = apiInstance.V2IntervalsDeletePost(intervalBulkDelete);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalsDeletePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalsDeletePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<V2IntervalsDeletePost200Response> response = apiInstance.V2IntervalsDeletePostWithHttpInfo(intervalBulkDelete);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalsDeletePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalBulkDelete** | [**IntervalBulkDelete**](IntervalBulkDelete.md) |  |  |

### Return type

[**V2IntervalsDeletePost200Response**](V2IntervalsDeletePost200Response.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list containing any intervals found but not deleted. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2intervalssetpost"></a>
# **V2IntervalsSetPost**
> List&lt;string&gt; V2IntervalsSetPost (IntervalBulkCreate intervalBulkCreate)



Create (Does not update) a group of custom intervals, for the same `type` and `line`. Line and type do not need to be included in each individual interval, just once at the top level.  Limitations: - Cannot excees 2500 intervals per request. - Will not write over other intervals - Does not support \"batch\", \"run\", or \"state\" interval types. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class V2IntervalsSetPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var intervalBulkCreate = new IntervalBulkCreate(); // IntervalBulkCreate | 

            try
            {
                List<string> result = apiInstance.V2IntervalsSetPost(intervalBulkCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalsSetPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2IntervalsSetPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<string>> response = apiInstance.V2IntervalsSetPostWithHttpInfo(intervalBulkCreate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.V2IntervalsSetPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalBulkCreate** | [**IntervalBulkCreate**](IntervalBulkCreate.md) |  |  |

### Return type

**List<string>**

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of created interval IDs. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

