# Oden.Api.MachineGroupsApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchFactories**](MachineGroupsApi.md#searchfactories) | **POST** /v2/factory/search | Search factories |
| [**SearchLines**](MachineGroupsApi.md#searchlines) | **POST** /v2/line/search | Search production lines |

<a id="searchfactories"></a>
# **SearchFactories**
> List&lt;Factory&gt; SearchFactories (Factory factory)

Search factories

Search for a specific Factory by a unique indentifier: - `name` - `match: unique` or omit  OR  - `id` - `match: unique` or omit  Search for all factories: - `match: all` 

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
    public class SearchFactoriesExample
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
            var apiInstance = new MachineGroupsApi(httpClient, config, httpClientHandler);
            var factory = new Factory(); // Factory | 

            try
            {
                // Search factories
                List<Factory> result = apiInstance.SearchFactories(factory);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MachineGroupsApi.SearchFactories: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchFactoriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search factories
    ApiResponse<List<Factory>> response = apiInstance.SearchFactoriesWithHttpInfo(factory);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MachineGroupsApi.SearchFactoriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **factory** | [**Factory**](Factory.md) |  |  |

### Return type

[**List&lt;Factory&gt;**](Factory.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of factories. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchlines"></a>
# **SearchLines**
> List&lt;Line&gt; SearchLines (Line line)

Search production lines

Search for specific Line by any Line identifier. Either: - `id` - `match: unique` or omit  OR - `factory`   - `name` or `id` - line `name` - `match: unique` or omit  Search for all Lines for a given Factory: - `factory`   - `name` or `id` - `match: all` 

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
    public class SearchLinesExample
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
            var apiInstance = new MachineGroupsApi(httpClient, config, httpClientHandler);
            var line = new Line(); // Line | 

            try
            {
                // Search production lines
                List<Line> result = apiInstance.SearchLines(line);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MachineGroupsApi.SearchLines: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchLinesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search production lines
    ApiResponse<List<Line>> response = apiInstance.SearchLinesWithHttpInfo(line);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MachineGroupsApi.SearchLinesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **line** | [**Line**](Line.md) |  |  |

### Return type

[**List&lt;Line&gt;**](Line.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of lines. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

