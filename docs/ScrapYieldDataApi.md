# Oden.Api.ScrapYieldDataApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V2ScrapYieldDeletePost**](ScrapYieldDataApi.md#v2scrapyielddeletepost) | **POST** /v2/scrap_yield/delete |  |
| [**V2ScrapYieldSearchPost**](ScrapYieldDataApi.md#v2scrapyieldsearchpost) | **POST** /v2/scrap_yield/search |  |
| [**V2ScrapYieldSetPost**](ScrapYieldDataApi.md#v2scrapyieldsetpost) | **POST** /v2/scrap_yield/set |  |

<a id="v2scrapyielddeletepost"></a>
# **V2ScrapYieldDeletePost**
> void V2ScrapYieldDeletePost (V2ScrapYieldSearchPostRequest v2ScrapYieldSearchPostRequest)



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
    public class V2ScrapYieldDeletePostExample
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
            var v2ScrapYieldSearchPostRequest = new V2ScrapYieldSearchPostRequest(); // V2ScrapYieldSearchPostRequest | 

            try
            {
                apiInstance.V2ScrapYieldDeletePost(v2ScrapYieldSearchPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldDeletePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2ScrapYieldDeletePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.V2ScrapYieldDeletePostWithHttpInfo(v2ScrapYieldSearchPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldDeletePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **v2ScrapYieldSearchPostRequest** | [**V2ScrapYieldSearchPostRequest**](V2ScrapYieldSearchPostRequest.md) |  |  |

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

<a id="v2scrapyieldsearchpost"></a>
# **V2ScrapYieldSearchPost**
> void V2ScrapYieldSearchPost (V2ScrapYieldSearchPostRequest v2ScrapYieldSearchPostRequest)



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
    public class V2ScrapYieldSearchPostExample
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
            var v2ScrapYieldSearchPostRequest = new V2ScrapYieldSearchPostRequest(); // V2ScrapYieldSearchPostRequest | 

            try
            {
                apiInstance.V2ScrapYieldSearchPost(v2ScrapYieldSearchPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldSearchPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2ScrapYieldSearchPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.V2ScrapYieldSearchPostWithHttpInfo(v2ScrapYieldSearchPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldSearchPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **v2ScrapYieldSearchPostRequest** | [**V2ScrapYieldSearchPostRequest**](V2ScrapYieldSearchPostRequest.md) |  |  |

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

<a id="v2scrapyieldsetpost"></a>
# **V2ScrapYieldSetPost**
> void V2ScrapYieldSetPost (V2ScrapYieldSetPostRequest v2ScrapYieldSetPostRequest, string pattern = null)



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
    public class V2ScrapYieldSetPostExample
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
            var v2ScrapYieldSetPostRequest = new V2ScrapYieldSetPostRequest(); // V2ScrapYieldSetPostRequest | 
            var pattern = "exact";  // string | Optional pattern type to use for matching: - `exact` for exact match - `contains` for the string to be contained in the query - `regex` to match based on a regular expression  (optional)  (default to exact)

            try
            {
                apiInstance.V2ScrapYieldSetPost(v2ScrapYieldSetPostRequest, pattern);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldSetPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2ScrapYieldSetPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.V2ScrapYieldSetPostWithHttpInfo(v2ScrapYieldSetPostRequest, pattern);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScrapYieldDataApi.V2ScrapYieldSetPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **v2ScrapYieldSetPostRequest** | [**V2ScrapYieldSetPostRequest**](V2ScrapYieldSetPostRequest.md) |  |  |
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

