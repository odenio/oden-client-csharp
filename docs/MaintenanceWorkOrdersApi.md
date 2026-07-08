# Oden.Api.MaintenanceWorkOrdersApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V2MaintenanceWorkOrderDeletePost**](MaintenanceWorkOrdersApi.md#v2maintenanceworkorderdeletepost) | **POST** /v2/maintenance_work_order/delete |  |
| [**V2MaintenanceWorkOrderSearchPost**](MaintenanceWorkOrdersApi.md#v2maintenanceworkordersearchpost) | **POST** /v2/maintenance_work_order/search |  |
| [**V2MaintenanceWorkOrderSetPost**](MaintenanceWorkOrdersApi.md#v2maintenanceworkordersetpost) | **POST** /v2/maintenance_work_order/set |  |

<a id="v2maintenanceworkorderdeletepost"></a>
# **V2MaintenanceWorkOrderDeletePost**
> List&lt;MaintenanceWorkOrder&gt; V2MaintenanceWorkOrderDeletePost (MaintenanceWorkOrder maintenanceWorkOrder)



Delete a Maintenance Work Order by unique identifier: - `id` OR `external_id` - `match: unique` or omit (only unique is supported) 

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
    public class V2MaintenanceWorkOrderDeletePostExample
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
            var apiInstance = new MaintenanceWorkOrdersApi(httpClient, config, httpClientHandler);
            var maintenanceWorkOrder = new MaintenanceWorkOrder(); // MaintenanceWorkOrder | 

            try
            {
                List<MaintenanceWorkOrder> result = apiInstance.V2MaintenanceWorkOrderDeletePost(maintenanceWorkOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderDeletePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2MaintenanceWorkOrderDeletePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<MaintenanceWorkOrder>> response = apiInstance.V2MaintenanceWorkOrderDeletePostWithHttpInfo(maintenanceWorkOrder);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderDeletePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **maintenanceWorkOrder** | [**MaintenanceWorkOrder**](MaintenanceWorkOrder.md) |  |  |

### Return type

[**List&lt;MaintenanceWorkOrder&gt;**](MaintenanceWorkOrder.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list containing the deleted maintenance work order. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2maintenanceworkordersearchpost"></a>
# **V2MaintenanceWorkOrderSearchPost**
> List&lt;MaintenanceWorkOrder&gt; V2MaintenanceWorkOrderSearchPost (V2MaintenanceWorkOrderSearchPostRequest v2MaintenanceWorkOrderSearchPostRequest)



Search for Maintenance Work Orders by: - `id` - `external_id` - `line_id` with required `start_time` and `end_time` filters 

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
    public class V2MaintenanceWorkOrderSearchPostExample
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
            var apiInstance = new MaintenanceWorkOrdersApi(httpClient, config, httpClientHandler);
            var v2MaintenanceWorkOrderSearchPostRequest = new V2MaintenanceWorkOrderSearchPostRequest(); // V2MaintenanceWorkOrderSearchPostRequest | 

            try
            {
                List<MaintenanceWorkOrder> result = apiInstance.V2MaintenanceWorkOrderSearchPost(v2MaintenanceWorkOrderSearchPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderSearchPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2MaintenanceWorkOrderSearchPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<MaintenanceWorkOrder>> response = apiInstance.V2MaintenanceWorkOrderSearchPostWithHttpInfo(v2MaintenanceWorkOrderSearchPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderSearchPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **v2MaintenanceWorkOrderSearchPostRequest** | [**V2MaintenanceWorkOrderSearchPostRequest**](V2MaintenanceWorkOrderSearchPostRequest.md) |  |  |

### Return type

[**List&lt;MaintenanceWorkOrder&gt;**](MaintenanceWorkOrder.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of maintenance work orders. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v2maintenanceworkordersetpost"></a>
# **V2MaintenanceWorkOrderSetPost**
> MaintenanceWorkOrder V2MaintenanceWorkOrderSetPost (MaintenanceWorkOrder maintenanceWorkOrder)



Create or update a Maintenance Work Order.  To **create** a new Maintenance Work Order: - Include `name` and `line`, `external_id`, `started_at` (required) - Omit `id` field - include `completed_at`, `description`, `metadata`  To **update** an existing Maintenance Work Order: - Include the `id` of the existing work order - Include any fields to update  NOTE: Any fields not included in an update request will be left unchanged. 

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
    public class V2MaintenanceWorkOrderSetPostExample
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
            var apiInstance = new MaintenanceWorkOrdersApi(httpClient, config, httpClientHandler);
            var maintenanceWorkOrder = new MaintenanceWorkOrder(); // MaintenanceWorkOrder | 

            try
            {
                MaintenanceWorkOrder result = apiInstance.V2MaintenanceWorkOrderSetPost(maintenanceWorkOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderSetPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2MaintenanceWorkOrderSetPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<MaintenanceWorkOrder> response = apiInstance.V2MaintenanceWorkOrderSetPostWithHttpInfo(maintenanceWorkOrder);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.V2MaintenanceWorkOrderSetPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **maintenanceWorkOrder** | [**MaintenanceWorkOrder**](MaintenanceWorkOrder.md) |  |  |

### Return type

[**MaintenanceWorkOrder**](MaintenanceWorkOrder.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list containing the created or updated maintenance work order. |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

