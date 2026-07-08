# Oden.Api.ScrapYieldDataApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteScrapYield**](ScrapYieldDataApi.md#deletescrapyield) | **POST** /v2/scrap_yield/delete | Delete a scrap/yield record |
| [**SearchScrapYield**](ScrapYieldDataApi.md#searchscrapyield) | **POST** /v2/scrap_yield/search | Search scrap/yield records |
| [**SetScrapYield**](ScrapYieldDataApi.md#setscrapyield) | **POST** /v2/scrap_yield/set | Create or update a scrap/yield record |

<a id="deletescrapyield"></a>
# **DeleteScrapYield**
> void DeleteScrapYield (SearchScrapYieldRequest searchScrapYieldRequest)

Delete a scrap/yield record

Deletes Scrap Yield record by ID and line 

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
    public class DeleteScrapYieldExample
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
            var apiInstance = new ScrapYieldDataApi(httpClient, config, httpClientHandler);
            var searchScrapYieldRequest = new SearchScrapYieldRequest(); // SearchScrapYieldRequest | 

            try
            {
                // Delete a scrap/yield record
                apiInstance.DeleteScrapYield(searchScrapYieldRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.DeleteScrapYield: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteScrapYieldWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a scrap/yield record
    apiInstance.DeleteScrapYieldWithHttpInfo(searchScrapYieldRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.DeleteScrapYieldWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **searchScrapYieldRequest** | [**SearchScrapYieldRequest**](SearchScrapYieldRequest.md) |  |  |

### Return type

void (empty response body)

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
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchscrapyield"></a>
# **SearchScrapYield**
> void SearchScrapYield (SearchScrapYieldRequest searchScrapYieldRequest)

Search scrap/yield records

Searches for scrap/yield records for a given Interval 

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
    public class SearchScrapYieldExample
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
            var apiInstance = new ScrapYieldDataApi(httpClient, config, httpClientHandler);
            var searchScrapYieldRequest = new SearchScrapYieldRequest(); // SearchScrapYieldRequest | 

            try
            {
                // Search scrap/yield records
                apiInstance.SearchScrapYield(searchScrapYieldRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.SearchScrapYield: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchScrapYieldWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search scrap/yield records
    apiInstance.SearchScrapYieldWithHttpInfo(searchScrapYieldRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.SearchScrapYieldWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **searchScrapYieldRequest** | [**SearchScrapYieldRequest**](SearchScrapYieldRequest.md) |  |  |

### Return type

void (empty response body)

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
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setscrapyield"></a>
# **SetScrapYield**
> void SetScrapYield (SetScrapYieldRequest setScrapYieldRequest, string pattern = null)

Create or update a scrap/yield record

Uploads scrap or yield raw data.  Notes:  - If `id` is provided the existing Scrap/Yield record will be updated.  - If `id` is omitted a new Scrap/Yield record will be created.  - The scrap yield for an interval is an aggregate of all scrap yield raw data records associated with that interval     - Therefore, multiple scrap yield records can exist for a single interval, each contributing to the \"aggregate\" (i.e. sum total) scrap/yield of that interval  - Changing an aggregate can be done by either adding another record with an offset, or updating an existing record.     - Example: If you have 3 scrap records in an interval: 50 50 50 = 150 and want to make the aggregate 100 for a given interval, either update one of the existing scrap records from 50 -> 0, or add a new one with value -50  - Duplicate keys should be avoided, see Schema docs above for details. 

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
    public class SetScrapYieldExample
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
            var apiInstance = new ScrapYieldDataApi(httpClient, config, httpClientHandler);
            var setScrapYieldRequest = new SetScrapYieldRequest(); // SetScrapYieldRequest | 
            var pattern = "exact";  // string | Optional pattern type to use for matching: - `exact` for exact match - `contains` for the string to be contained in the query - `regex` to match based on a regular expression  (optional)  (default to exact)

            try
            {
                // Create or update a scrap/yield record
                apiInstance.SetScrapYield(setScrapYieldRequest, pattern);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.SetScrapYield: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetScrapYieldWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a scrap/yield record
    apiInstance.SetScrapYieldWithHttpInfo(setScrapYieldRequest, pattern);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.SetScrapYieldWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **setScrapYieldRequest** | [**SetScrapYieldRequest**](SetScrapYieldRequest.md) |  |  |
| **pattern** | **string** | Optional pattern type to use for matching: - &#x60;exact&#x60; for exact match - &#x60;contains&#x60; for the string to be contained in the query - &#x60;regex&#x60; to match based on a regular expression  | [optional] [default to exact] |

### Return type

void (empty response body)

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
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **404** | Entity not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

