# Oden.Api.StatesApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchStateCategories**](StatesApi.md#searchstatecategories) | **POST** /v2/state_category/search | Search state categories |
| [**SearchStateReasons**](StatesApi.md#searchstatereasons) | **POST** /v2/state_reason/search | Search state reasons on one or more lines |
| [**SetStateCategory**](StatesApi.md#setstatecategory) | **POST** /v2/state_category/set | Create or update a state category |
| [**SetStateReasons**](StatesApi.md#setstatereasons) | **POST** /v2/state_reason/set | Create a state reason on one or more lines |

<a id="searchstatecategories"></a>
# **SearchStateCategories**
> List&lt;StateCategoryDetail&gt; SearchStateCategories (StateCategorySearch stateCategorySearch)

Search state categories

Returns the state categories available to your organization, including Oden's built-in ones. Filter by `id` or `name`; omit both to list all. Built-in categories have no `organization` and cannot be modified.  `type` summarises how the platform treats time in the category: - `uptime`: producing good product - `scrapping`: running but not producing good product - `planned_downtime`, `unplanned_downtime`: not running 

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
    public class SearchStateCategoriesExample
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
            var apiInstance = new StatesApi(httpClient, config, httpClientHandler);
            var stateCategorySearch = new StateCategorySearch(); // StateCategorySearch | 

            try
            {
                // Search state categories
                List<StateCategoryDetail> result = apiInstance.SearchStateCategories(stateCategorySearch);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatesApi.SearchStateCategories: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchStateCategoriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search state categories
    ApiResponse<List<StateCategoryDetail>> response = apiInstance.SearchStateCategoriesWithHttpInfo(stateCategorySearch);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatesApi.SearchStateCategoriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stateCategorySearch** | [**StateCategorySearch**](StateCategorySearch.md) |  |  |

### Return type

[**List&lt;StateCategoryDetail&gt;**](StateCategoryDetail.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The matching state categories. |  -  |
| **400** | The request is malformed. Either one of the input parameters is invalid (ParameterError body), or this endpoint does not support the combination of inputs supplied (GenericError body, error message prefixed \&quot;Unimplemented:\&quot;).  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchstatereasons"></a>
# **SearchStateReasons**
> List&lt;StateReasonDetail&gt; SearchStateReasons (StateReasonSearch stateReasonSearch)

Search state reasons on one or more lines

Returns the state reasons defined on every line in `lines` (required; each by `id`, or by `name` plus `factory`), optionally restricted to one `category` (by `id` or `name`). Each result names its line, so one request can audit a whole fleet. Inactive reasons are included, with `active: false`. 

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
    public class SearchStateReasonsExample
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
            var apiInstance = new StatesApi(httpClient, config, httpClientHandler);
            var stateReasonSearch = new StateReasonSearch(); // StateReasonSearch | 

            try
            {
                // Search state reasons on one or more lines
                List<StateReasonDetail> result = apiInstance.SearchStateReasons(stateReasonSearch);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatesApi.SearchStateReasons: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchStateReasonsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search state reasons on one or more lines
    ApiResponse<List<StateReasonDetail>> response = apiInstance.SearchStateReasonsWithHttpInfo(stateReasonSearch);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatesApi.SearchStateReasonsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stateReasonSearch** | [**StateReasonSearch**](StateReasonSearch.md) |  |  |

### Return type

[**List&lt;StateReasonDetail&gt;**](StateReasonDetail.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The matching state reasons. |  -  |
| **400** | The request is malformed. Either one of the input parameters is invalid (ParameterError body), or this endpoint does not support the combination of inputs supplied (GenericError body, error message prefixed \&quot;Unimplemented:\&quot;).  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setstatecategory"></a>
# **SetStateCategory**
> StateCategoryDetail SetStateCategory (StateCategorySet stateCategorySet)

Create or update a state category

**Create** (no `id`): `name` and `type` are required. If a category with that `name` already exists for your organization and has the same `type`, it is returned unchanged; a different `type` is a 409.  **Update** (with `id`): fields you omit keep their current value. Built-in categories (no organization) cannot be updated.  Requires an organization admin token. 

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
    public class SetStateCategoryExample
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
            var apiInstance = new StatesApi(httpClient, config, httpClientHandler);
            var stateCategorySet = new StateCategorySet(); // StateCategorySet | 

            try
            {
                // Create or update a state category
                StateCategoryDetail result = apiInstance.SetStateCategory(stateCategorySet);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatesApi.SetStateCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetStateCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a state category
    ApiResponse<StateCategoryDetail> response = apiInstance.SetStateCategoryWithHttpInfo(stateCategorySet);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatesApi.SetStateCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stateCategorySet** | [**StateCategorySet**](StateCategorySet.md) |  |  |

### Return type

[**StateCategoryDetail**](StateCategoryDetail.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The state category after set. |  -  |
| **400** | The request is malformed. Either one of the input parameters is invalid (ParameterError body), or this endpoint does not support the combination of inputs supplied (GenericError body, error message prefixed \&quot;Unimplemented:\&quot;).  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | The entity already exists in a shape that conflicts with the request, or a concurrent request created it and the conflict did not resolve on retry. The message says which.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setstatereasons"></a>
# **SetStateReasons**
> List&lt;StateReasonDetail&gt; SetStateReasons (StateReasonSet stateReasonSet)

Create a state reason on one or more lines

Ensures the reason `name` exists under `category` on every line in `lines`. Lines that already have it are returned as they are; the rest are created in one transaction. The response has one entry per line, in request order, so calling this again is a no-op.  `category` may be given by `id` or `name` and must be one of your organization's own categories; Oden's built-in categories are read-only. `active` defaults to true and also re-activates an existing inactive reason (or deactivates with `false`).  Requires an organization admin token. 

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
    public class SetStateReasonsExample
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
            var apiInstance = new StatesApi(httpClient, config, httpClientHandler);
            var stateReasonSet = new StateReasonSet(); // StateReasonSet | 

            try
            {
                // Create a state reason on one or more lines
                List<StateReasonDetail> result = apiInstance.SetStateReasons(stateReasonSet);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatesApi.SetStateReasons: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetStateReasonsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a state reason on one or more lines
    ApiResponse<List<StateReasonDetail>> response = apiInstance.SetStateReasonsWithHttpInfo(stateReasonSet);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatesApi.SetStateReasonsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stateReasonSet** | [**StateReasonSet**](StateReasonSet.md) |  |  |

### Return type

[**List&lt;StateReasonDetail&gt;**](StateReasonDetail.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The state reason on each requested line. |  -  |
| **400** | The request is malformed. Either one of the input parameters is invalid (ParameterError body), or this endpoint does not support the combination of inputs supplied (GenericError body, error message prefixed \&quot;Unimplemented:\&quot;).  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | The entity already exists in a shape that conflicts with the request, or a concurrent request created it and the conflict did not resolve on retry. The message says which.  |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

