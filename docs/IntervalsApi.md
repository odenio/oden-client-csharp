# Oden.Api.IntervalsApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkDeleteIntervals**](IntervalsApi.md#bulkdeleteintervals) | **POST** /v2/intervals/delete | Delete intervals in a time range |
| [**BulkSetIntervals**](IntervalsApi.md#bulksetintervals) | **POST** /v2/intervals/set | Create a set of intervals |
| [**BulkUpdateIntervals**](IntervalsApi.md#bulkupdateintervals) | **POST** /v2/intervals/update | Update a set of intervals |
| [**DeleteInterval**](IntervalsApi.md#deleteinterval) | **POST** /v2/interval/delete | Delete an interval |
| [**DeleteIntervalType**](IntervalsApi.md#deleteintervaltype) | **POST** /v2/interval_type/delete | Delete a custom interval type |
| [**SearchIntervalTypes**](IntervalsApi.md#searchintervaltypes) | **POST** /v2/interval_type/search | Search interval types |
| [**SearchIntervals**](IntervalsApi.md#searchintervals) | **POST** /v2/interval/search | Search intervals on a line |
| [**SetInterval**](IntervalsApi.md#setinterval) | **POST** /v2/interval/set | Create or update an interval |
| [**SetIntervalType**](IntervalsApi.md#setintervaltype) | **POST** /v2/interval_type/set | Create or update a custom interval type |
| [**UpdateInterval**](IntervalsApi.md#updateinterval) | **POST** /v2/interval/update | Update an interval |

<a id="bulkdeleteintervals"></a>
# **BulkDeleteIntervals**
> BulkDeleteIntervals200Response BulkDeleteIntervals (IntervalBulkDelete intervalBulkDelete)

Delete intervals in a time range

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
    public class BulkDeleteIntervalsExample
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
                // Delete intervals in a time range
                BulkDeleteIntervals200Response result = apiInstance.BulkDeleteIntervals(intervalBulkDelete);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.BulkDeleteIntervals: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkDeleteIntervalsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete intervals in a time range
    ApiResponse<BulkDeleteIntervals200Response> response = apiInstance.BulkDeleteIntervalsWithHttpInfo(intervalBulkDelete);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.BulkDeleteIntervalsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalBulkDelete** | [**IntervalBulkDelete**](IntervalBulkDelete.md) |  |  |

### Return type

[**BulkDeleteIntervals200Response**](BulkDeleteIntervals200Response.md)

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

<a id="bulksetintervals"></a>
# **BulkSetIntervals**
> List&lt;string&gt; BulkSetIntervals (IntervalBulkCreate intervalBulkCreate)

Create a set of intervals

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
    public class BulkSetIntervalsExample
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
                // Create a set of intervals
                List<string> result = apiInstance.BulkSetIntervals(intervalBulkCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.BulkSetIntervals: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkSetIntervalsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a set of intervals
    ApiResponse<List<string>> response = apiInstance.BulkSetIntervalsWithHttpInfo(intervalBulkCreate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.BulkSetIntervalsWithHttpInfo: " + e.Message);
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

<a id="bulkupdateintervals"></a>
# **BulkUpdateIntervals**
> BulkUpdateIntervals200Response BulkUpdateIntervals (IntervalBulkUpdate intervalBulkUpdate)

Update a set of intervals

Update multiple existing intervals. This endpoint only updates intervals and will not create new ones.  Each interval in the `intervals` array must include an `id` that references an existing interval.  Updatable fields for each interval: - `name`: Update the interval name - `start_time`: Modify the start time - `end_time`: Modify the end time - `metadata`: Update metadata (product, target, category, reason, etc.)  The endpoint will attempt to update all intervals and return information about successes and failures: - Successfully updated intervals are returned in the response - Failed intervals are listed with their IDs and error reasons  Limitations: - Cannot exceed 2500 intervals per request - All intervals must be of the same `type` and on the same `line`  **Note:** Interval IDs must be obtained from either: - The response when creating intervals via `/v2/interval/set` or `/v2/intervals/set` - Searching for intervals via `/v2/interval/search` 

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
    public class BulkUpdateIntervalsExample
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
            var intervalBulkUpdate = new IntervalBulkUpdate(); // IntervalBulkUpdate | 

            try
            {
                // Update a set of intervals
                BulkUpdateIntervals200Response result = apiInstance.BulkUpdateIntervals(intervalBulkUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.BulkUpdateIntervals: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkUpdateIntervalsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a set of intervals
    ApiResponse<BulkUpdateIntervals200Response> response = apiInstance.BulkUpdateIntervalsWithHttpInfo(intervalBulkUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.BulkUpdateIntervalsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalBulkUpdate** | [**IntervalBulkUpdate**](IntervalBulkUpdate.md) |  |  |

### Return type

[**BulkUpdateIntervals200Response**](BulkUpdateIntervals200Response.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Response containing successfully updated intervals and any failures that occurred. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deleteinterval"></a>
# **DeleteInterval**
> List&lt;Interval&gt; DeleteInterval (Interval interval)

Delete an interval

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
    public class DeleteIntervalExample
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
                // Delete an interval
                List<Interval> result = apiInstance.DeleteInterval(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.DeleteInterval: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteIntervalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an interval
    ApiResponse<List<Interval>> response = apiInstance.DeleteIntervalWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.DeleteIntervalWithHttpInfo: " + e.Message);
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

<a id="deleteintervaltype"></a>
# **DeleteIntervalType**
> IntervalType DeleteIntervalType (IntervalType intervalType)

Delete a custom interval type

Delete an existing custom Interval Type. `id` is required. Built-in types (RUN, BATCH, STATE) cannot be deleted. 

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
    public class DeleteIntervalTypeExample
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
                // Delete a custom interval type
                IntervalType result = apiInstance.DeleteIntervalType(intervalType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.DeleteIntervalType: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteIntervalTypeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a custom interval type
    ApiResponse<IntervalType> response = apiInstance.DeleteIntervalTypeWithHttpInfo(intervalType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.DeleteIntervalTypeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalType** | [**IntervalType**](IntervalType.md) |  |  |

### Return type

[**IntervalType**](IntervalType.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The deleted interval type. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchintervaltypes"></a>
# **SearchIntervalTypes**
> List&lt;IntervalType&gt; SearchIntervalTypes (IntervalType intervalType)

Search interval types

Search for Interval Types by `name`, `id`, or just `match: all` to return all Interval Types associated with the your organization. Basic Interval Types - - `RUN`, `BATCH`, and `STATE` - - are dedicated interval types that come out-of-the-box with Oden. Custom Interval Types may be created by users. 

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
    public class SearchIntervalTypesExample
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
                // Search interval types
                List<IntervalType> result = apiInstance.SearchIntervalTypes(intervalType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.SearchIntervalTypes: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchIntervalTypesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search interval types
    ApiResponse<List<IntervalType>> response = apiInstance.SearchIntervalTypesWithHttpInfo(intervalType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.SearchIntervalTypesWithHttpInfo: " + e.Message);
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

<a id="searchintervals"></a>
# **SearchIntervals**
> List&lt;Interval&gt; SearchIntervals (Interval interval)

Search intervals on a line

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
    public class SearchIntervalsExample
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
                // Search intervals on a line
                List<Interval> result = apiInstance.SearchIntervals(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.SearchIntervals: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchIntervalsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search intervals on a line
    ApiResponse<List<Interval>> response = apiInstance.SearchIntervalsWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.SearchIntervalsWithHttpInfo: " + e.Message);
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

<a id="setinterval"></a>
# **SetInterval**
> List&lt;Interval&gt; SetInterval (Interval interval)

Create or update an interval

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
    public class SetIntervalExample
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
                // Create or update an interval
                List<Interval> result = apiInstance.SetInterval(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.SetInterval: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetIntervalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update an interval
    ApiResponse<List<Interval>> response = apiInstance.SetIntervalWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.SetIntervalWithHttpInfo: " + e.Message);
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

<a id="setintervaltype"></a>
# **SetIntervalType**
> IntervalType SetIntervalType (IntervalTypeSet intervalTypeSet)

Create or update a custom interval type

**Create** (no `id` in the body): send `name` (required) and optional `metadata_schema` / `tags`.  **Update** (with `id`): send the interval type’s `id` and optional `metadata_schema` / `tags` only. Do not send `name` for updates; including `name` returns 400. Renames are not supported.  **Patch (update only)**: `metadata_schema` — if the key is missing, the existing value is kept; if present, it replaces. `tags` — if the key is missing, tags are unchanged; `null` leaves tags unchanged; `[]` clears tags; a non-empty array replaces.  **Built-in types (RUN, BATCH, STATE) cannot be created, set, or deleted.** 

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
    public class SetIntervalTypeExample
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
            var intervalTypeSet = new IntervalTypeSet(); // IntervalTypeSet | 

            try
            {
                // Create or update a custom interval type
                IntervalType result = apiInstance.SetIntervalType(intervalTypeSet);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.SetIntervalType: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetIntervalTypeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a custom interval type
    ApiResponse<IntervalType> response = apiInstance.SetIntervalTypeWithHttpInfo(intervalTypeSet);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.SetIntervalTypeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **intervalTypeSet** | [**IntervalTypeSet**](IntervalTypeSet.md) |  |  |

### Return type

[**IntervalType**](IntervalType.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The interval type after set. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateinterval"></a>
# **UpdateInterval**
> List&lt;Interval&gt; UpdateInterval (Interval interval)

Update an interval

Update an existing Interval. This endpoint only updates intervals and will not create new ones.  Must include `line`, `type`, and `id`. The `id` must reference an existing interval.  This interval's properties can be modified using the following fields: - `name`: Update the interval name - `start_time`: Modify the start time - `end_time`: Modify the end time - `metadata`: Update metadata (product, target, category, reason, etc.)  If the interval does not exist, a 404 error will be returned.  **Note:** The `id` must be obtained from either: - The response when creating an interval via `/v2/interval/set` - Searching for intervals via `/v2/interval/search` 

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
    public class UpdateIntervalExample
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
                // Update an interval
                List<Interval> result = apiInstance.UpdateInterval(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IntervalsApi.UpdateInterval: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateIntervalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an interval
    ApiResponse<List<Interval>> response = apiInstance.UpdateIntervalWithHttpInfo(interval);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IntervalsApi.UpdateIntervalWithHttpInfo: " + e.Message);
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
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

