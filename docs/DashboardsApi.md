# Oden.Api.DashboardsApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ExecuteDashboard**](DashboardsApi.md#executedashboard) | **POST** /v2/dashboard/execute | Execute a dashboard |

<a id="executedashboard"></a>
# **ExecuteDashboard**
> List&lt;DashboardExecuteResult&gt; ExecuteDashboard (DashboardExecuteRequest dashboardExecuteRequest)

Execute a dashboard

Execute every module in a dashboard with shared time-range and filter overrides, returning the columns and rows produced by each module.  Modules execute in parallel and are reported in the dashboard's stored module order. Per-module failures (parse, dispatch) land in the `error` field of that module's result; siblings continue to run.  Known v1 limitations: - Template variables (`{var_name}` in stored OQL) are not substituted   server-side. Modules containing unsubstituted placeholders will   fail at parse time. 

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
    public class ExecuteDashboardExample
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
            var apiInstance = new DashboardsApi(httpClient, config, httpClientHandler);
            var dashboardExecuteRequest = new DashboardExecuteRequest(); // DashboardExecuteRequest | 

            try
            {
                // Execute a dashboard
                List<DashboardExecuteResult> result = apiInstance.ExecuteDashboard(dashboardExecuteRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DashboardsApi.ExecuteDashboard: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExecuteDashboardWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Execute a dashboard
    ApiResponse<List<DashboardExecuteResult>> response = apiInstance.ExecuteDashboardWithHttpInfo(dashboardExecuteRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DashboardsApi.ExecuteDashboardWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **dashboardExecuteRequest** | [**DashboardExecuteRequest**](DashboardExecuteRequest.md) |  |  |

### Return type

[**List&lt;DashboardExecuteResult&gt;**](DashboardExecuteResult.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Dashboard loaded and each module executed. Individual modules may still report &#x60;error&#x60; in their result; this is not a 200/non-200 distinction.  |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **429** | Too many requests |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

