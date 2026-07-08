# Oden.Api.MaintenanceWorkOrdersApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteMaintenanceWorkOrder**](MaintenanceWorkOrdersApi.md#deletemaintenanceworkorder) | **POST** /v2/maintenance_work_order/delete | Delete a maintenance work order |
| [**SearchMaintenanceWorkOrders**](MaintenanceWorkOrdersApi.md#searchmaintenanceworkorders) | **POST** /v2/maintenance_work_order/search | Search maintenance work orders |
| [**SetMaintenanceWorkOrder**](MaintenanceWorkOrdersApi.md#setmaintenanceworkorder) | **POST** /v2/maintenance_work_order/set | Create or update a maintenance work order |

<a id="deletemaintenanceworkorder"></a>
# **DeleteMaintenanceWorkOrder**
> List&lt;MaintenanceWorkOrder&gt; DeleteMaintenanceWorkOrder (MaintenanceWorkOrder maintenanceWorkOrder)

Delete a maintenance work order

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
    public class DeleteMaintenanceWorkOrderExample
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
                // Delete a maintenance work order
                List<MaintenanceWorkOrder> result = apiInstance.DeleteMaintenanceWorkOrder(maintenanceWorkOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.DeleteMaintenanceWorkOrder: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteMaintenanceWorkOrderWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a maintenance work order
    ApiResponse<List<MaintenanceWorkOrder>> response = apiInstance.DeleteMaintenanceWorkOrderWithHttpInfo(maintenanceWorkOrder);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.DeleteMaintenanceWorkOrderWithHttpInfo: " + e.Message);
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

<a id="searchmaintenanceworkorders"></a>
# **SearchMaintenanceWorkOrders**
> List&lt;MaintenanceWorkOrder&gt; SearchMaintenanceWorkOrders (SearchMaintenanceWorkOrdersRequest searchMaintenanceWorkOrdersRequest)

Search maintenance work orders

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
    public class SearchMaintenanceWorkOrdersExample
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
            var searchMaintenanceWorkOrdersRequest = new SearchMaintenanceWorkOrdersRequest(); // SearchMaintenanceWorkOrdersRequest | 

            try
            {
                // Search maintenance work orders
                List<MaintenanceWorkOrder> result = apiInstance.SearchMaintenanceWorkOrders(searchMaintenanceWorkOrdersRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.SearchMaintenanceWorkOrders: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchMaintenanceWorkOrdersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search maintenance work orders
    ApiResponse<List<MaintenanceWorkOrder>> response = apiInstance.SearchMaintenanceWorkOrdersWithHttpInfo(searchMaintenanceWorkOrdersRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.SearchMaintenanceWorkOrdersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **searchMaintenanceWorkOrdersRequest** | [**SearchMaintenanceWorkOrdersRequest**](SearchMaintenanceWorkOrdersRequest.md) |  |  |

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

<a id="setmaintenanceworkorder"></a>
# **SetMaintenanceWorkOrder**
> MaintenanceWorkOrder SetMaintenanceWorkOrder (MaintenanceWorkOrder maintenanceWorkOrder)

Create or update a maintenance work order

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
    public class SetMaintenanceWorkOrderExample
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
                // Create or update a maintenance work order
                MaintenanceWorkOrder result = apiInstance.SetMaintenanceWorkOrder(maintenanceWorkOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MaintenanceWorkOrdersApi.SetMaintenanceWorkOrder: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetMaintenanceWorkOrderWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a maintenance work order
    ApiResponse<MaintenanceWorkOrder> response = apiInstance.SetMaintenanceWorkOrderWithHttpInfo(maintenanceWorkOrder);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MaintenanceWorkOrdersApi.SetMaintenanceWorkOrderWithHttpInfo: " + e.Message);
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

