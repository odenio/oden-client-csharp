# Oden.Api.ProductAttributesApi

All URIs are relative to *https://api.oden.app*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchProductAttributes**](ProductAttributesApi.md#searchproductattributes) | **POST** /v2/product_attribute/search | Search product attributes |
| [**SetProductAttribute**](ProductAttributesApi.md#setproductattribute) | **POST** /v2/product_attribute/set | Create or update a product attribute |

<a id="searchproductattributes"></a>
# **SearchProductAttributes**
> List&lt;ProductAttribute&gt; SearchProductAttributes (ProductAttribute productAttribute)

Search product attributes

Searches for Product Attributes  Product attributes may be searched by ID, product, or, display_name - in that order.  If an ID is supplied, it will be used to search for a Product Attribute, and display_name, product will be ignored.  If a product is supplied (and no ID), it will be used to search for a Product Attribute, and display_name will be ignored. 

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
    public class SearchProductAttributesExample
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
            var apiInstance = new ProductAttributesApi(httpClient, config, httpClientHandler);
            var productAttribute = new ProductAttribute(); // ProductAttribute | 

            try
            {
                // Search product attributes
                List<ProductAttribute> result = apiInstance.SearchProductAttributes(productAttribute);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductAttributesApi.SearchProductAttributes: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchProductAttributesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search product attributes
    ApiResponse<List<ProductAttribute>> response = apiInstance.SearchProductAttributesWithHttpInfo(productAttribute);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductAttributesApi.SearchProductAttributesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productAttribute** | [**ProductAttribute**](ProductAttribute.md) |  |  |

### Return type

[**List&lt;ProductAttribute&gt;**](ProductAttribute.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of product attributes - potentially with products and values. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setproductattribute"></a>
# **SetProductAttribute**
> List&lt;ProductAttribute&gt; SetProductAttribute (ProductAttribute productAttribute)

Create or update a product attribute

Set a Product Attribute for a Product.  If the supplied Product Attribute doesn't exist, it will be created.  If the supplied Product Attribute Value doesn't exist, it will be created.  If the supplied Product Attribute Value is already set for the Product, it will be updated.  If the supplied Product Attribute Value is not set for the Product, it will be added.  Supplied Product must exist already. 

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
    public class SetProductAttributeExample
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
            var apiInstance = new ProductAttributesApi(httpClient, config, httpClientHandler);
            var productAttribute = new ProductAttribute(); // ProductAttribute | 

            try
            {
                // Create or update a product attribute
                List<ProductAttribute> result = apiInstance.SetProductAttribute(productAttribute);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductAttributesApi.SetProductAttribute: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetProductAttributeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create or update a product attribute
    ApiResponse<List<ProductAttribute>> response = apiInstance.SetProductAttributeWithHttpInfo(productAttribute);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductAttributesApi.SetProductAttributeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productAttribute** | [**ProductAttribute**](ProductAttribute.md) |  |  |

### Return type

[**List&lt;ProductAttribute&gt;**](ProductAttribute.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of product attributes - potentially with products and values. |  -  |
| **409** | A {match: \&quot;unique\&quot;} was requested, but multiple entities matched the search parameters.  |  -  |
| **401** | User has provided either no credentials or invalid credentials |  -  |
| **500** | An internal server error has occurred. If reporting the error to Oden, include the ID returned in this response to aid in debugging.  |  -  |
| **501** | Endpoint is not yet implemented |  -  |
| **400** | An error occurred regarding one of the input parameters |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

