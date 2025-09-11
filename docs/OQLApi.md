# Oden.Api.OQLApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V2OqlQueryPost**](OQLApi.md#v2oqlquerypost) | **POST** /v2/oql/query |  |

<a id="v2oqlquerypost"></a>
# **V2OqlQueryPost**
> void V2OqlQueryPost (OQLQuery oQLQuery, string format = null)



Run an OQL (Oden Query Language) query.  For reference on writing OQL queries, see:  [https://platform.oden.app/knowledge/how-do-i-write-queries-in-oden-query-language-oql](https://platform.oden.app/knowledge/how-do-i-write-queries-in-oden-query-language-oql) 

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
    public class V2OqlQueryPostExample
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
            var apiInstance = new OQLApi(httpClient, config, httpClientHandler);
            var oQLQuery = new OQLQuery(); // OQLQuery | 
            var format = "json";  // string | Format of the response. Can be `json`, `jsonextended` or `csv`. If unspecified, defaults to `jsonextended`.  (optional)  (default to json)

            try
            {
                apiInstance.V2OqlQueryPost(oQLQuery, format);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OQLApi.V2OqlQueryPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2OqlQueryPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.V2OqlQueryPostWithHttpInfo(oQLQuery, format);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OQLApi.V2OqlQueryPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **oQLQuery** | [**OQLQuery**](OQLQuery.md) |  |  |
| **format** | **string** | Format of the response. Can be &#x60;json&#x60;, &#x60;jsonextended&#x60; or &#x60;csv&#x60;. If unspecified, defaults to &#x60;jsonextended&#x60;.  | [optional] [default to json] |

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
| **400** | An error occurred regarding one of the input parameters |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **403** | User has provided valid credentials but is not authorized to access the entity  |  -  |
| **404** | Entity not found |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **413** | Too many requests |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

