# Oden.Api.QualityTestApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkDeleteQualityTests**](QualityTestApi.md#bulkdeletequalitytests) | **POST** /v2/quality_tests/delete | Delete multiple quality tests |
| [**DeleteQualityTest**](QualityTestApi.md#deletequalitytest) | **POST** /v2/quality_test/delete | Delete a quality test |
| [**SearchQualitySchemas**](QualityTestApi.md#searchqualityschemas) | **POST** /v2/quality_schema/search | Search quality schemas for a factory |
| [**SearchQualityTests**](QualityTestApi.md#searchqualitytests) | **POST** /v2/quality_test/search | Search quality tests |
| [**SetQualityTest**](QualityTestApi.md#setqualitytest) | **POST** /v2/quality_test/set | Create or update a quality test result |

<a id="bulkdeletequalitytests"></a>
# **BulkDeleteQualityTests**
> void BulkDeleteQualityTests (BulkDeleteQualityTestsRequest bulkDeleteQualityTestsRequest)

Delete multiple quality tests

Bulk deletes quality tests, either: - All quality tests on a given `line` whose `timsetamp` is between `start_time` and `end_time` OR - All quality tests whose `id` is supplied  It will do one or the other, with a bias for `id`'s if both are supplied. 

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
    public class BulkDeleteQualityTestsExample
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
            var apiInstance = new QualityTestApi(httpClient, config, httpClientHandler);
            var bulkDeleteQualityTestsRequest = new BulkDeleteQualityTestsRequest(); // BulkDeleteQualityTestsRequest | 

            try
            {
                // Delete multiple quality tests
                apiInstance.BulkDeleteQualityTests(bulkDeleteQualityTestsRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QualityTestApi.BulkDeleteQualityTests: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkDeleteQualityTestsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete multiple quality tests
    apiInstance.BulkDeleteQualityTestsWithHttpInfo(bulkDeleteQualityTestsRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QualityTestApi.BulkDeleteQualityTestsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bulkDeleteQualityTestsRequest** | [**BulkDeleteQualityTestsRequest**](BulkDeleteQualityTestsRequest.md) |  |  |

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

<a id="deletequalitytest"></a>
# **DeleteQualityTest**
> void DeleteQualityTest (QualityTest qualityTest)

Delete a quality test

Searches for uniqueQuality Test by:  - `id`  OR  - `interval` (of type `RUN` or `BATCH`)*  *This only work if there is a single quality test record for the interval. 

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
    public class DeleteQualityTestExample
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
            var apiInstance = new QualityTestApi(httpClient, config, httpClientHandler);
            var qualityTest = new QualityTest(); // QualityTest | 

            try
            {
                // Delete a quality test
                apiInstance.DeleteQualityTest(qualityTest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QualityTestApi.DeleteQualityTest: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteQualityTestWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a quality test
    apiInstance.DeleteQualityTestWithHttpInfo(qualityTest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QualityTestApi.DeleteQualityTestWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **qualityTest** | [**QualityTest**](QualityTest.md) |  |  |

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

<a id="searchqualityschemas"></a>
# **SearchQualitySchemas**
> void SearchQualitySchemas (QualitySchema qualitySchema)

Search quality schemas for a factory

Searches for Quality Schema[s] by:  - `factory` 

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
    public class SearchQualitySchemasExample
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
            var apiInstance = new QualityTestApi(httpClient, config, httpClientHandler);
            var qualitySchema = new QualitySchema(); // QualitySchema | 

            try
            {
                // Search quality schemas for a factory
                apiInstance.SearchQualitySchemas(qualitySchema);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QualityTestApi.SearchQualitySchemas: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchQualitySchemasWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search quality schemas for a factory
    apiInstance.SearchQualitySchemasWithHttpInfo(qualitySchema);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QualityTestApi.SearchQualitySchemasWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **qualitySchema** | [**QualitySchema**](QualitySchema.md) |  |  |

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

<a id="searchqualitytests"></a>
# **SearchQualityTests**
> void SearchQualityTests (QualityTest qualityTest)

Search quality tests

Searches for Quality Test[s] by:  - `id`  OR  - `interval` (of type `RUN` or `BATCH`) 

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
    public class SearchQualityTestsExample
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
            var apiInstance = new QualityTestApi(httpClient, config, httpClientHandler);
            var qualityTest = new QualityTest(); // QualityTest | 

            try
            {
                // Search quality tests
                apiInstance.SearchQualityTests(qualityTest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QualityTestApi.SearchQualityTests: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchQualityTestsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search quality tests
    apiInstance.SearchQualityTestsWithHttpInfo(qualityTest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QualityTestApi.SearchQualityTestsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **qualityTest** | [**QualityTest**](QualityTest.md) |  |  |

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

<a id="setqualitytest"></a>
# **SetQualityTest**
> void SetQualityTest (QualityTest qualityTest)

Create or update a quality test result

Create or update a Quality Test record: - To update `id` must be supplied. Only the supplied fields will be updated, the rest will remain unchanged. - If `id` is not supplied, a new `quality_test_record` will be created. 

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
    public class SetQualityTestExample
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
            var apiInstance = new QualityTestApi(httpClient, config, httpClientHandler);
            var qualityTest = new QualityTest(); // QualityTest | 

            try
            {
                // Create or update a quality test result
                apiInstance.SetQualityTest(qualityTest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QualityTestApi.SetQualityTest: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetQualityTestWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a quality test result
    apiInstance.SetQualityTestWithHttpInfo(qualityTest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QualityTestApi.SetQualityTestWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **qualityTest** | [**QualityTest**](QualityTest.md) |  |  |

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

