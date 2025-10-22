# Oden - the C# library for the Oden API

The Oden Private Partner API exposes RESTful API endpoints for clients to get, create and update data on the Oden Platform.

The API is based on the OpenAPI 3.0 specification.
### Current Version
The URL, and host, for the current version is [https://api.oden.app/v2](https://api.oden.app/v2).

### Oden's Data Model
- **Organization**: This represents the Organization registered as an Oden customer. An organization has an associated collection of users, factories, lines, etc. This is the entity a specific authentication token is associated with.
- **Asset** or **Machinegroup**: Assets, or machinegroups, are collections of machines, which may either be a **Factory** or a **Line**:
  - **Factory**: Factories are collections of lines, representing a particular manufacturing location.
    - **Line**: Lines are collections of machines, often representing a particular production line. Lines may also have **Products** mapped to them, indicating what is currently being manufactured by the specific line.
      - **Machine**: Machines are the physical machines that make up a line
- **Product**: Products capture what entities a manufacturer produces
- **Interval**: An interval is a period of time that takes place on a manufacturing line and expresses some business concern. It's Oden's way of making metrics aggregatable, traceable, and relatable to a manufacturer.
  - **Run**: A run is a production interval that labels a period of production as being work on some single product
  - **Batch**: A batch is a production interval that represents a portion of a particular run
  - **State**: A state is an interval that tracks the availability or utilization of a line
    - **State Category**: A state category describes what state a line is in - such as ex. uptime, downtime, scrapping, etc.
    - **State Reason**: A state reason describes why a line is in a particular state - such as \"maintenance\" being a reason for the category \"downtime\".
  - **Custom**: A custom interval can track any other type of interval-based data a manufacturer might want to analyze. These are created on a per-factory basis.
- **Target**: Targets specify values and upper/lower thresholds for metrics when specific products are running on specific lines
- **Scrap/Yield**: Scrap/yield output specifies amount of produced product on a line during either a run or batch interval. Oden will categorize all output as either scrap or yield - as specified by the Scrap Yield Schema for a given factory. If you have other categories, like rework/blocked/off-grade, you must choose between categorizing those amounts as either good or bad production by specifying as scrap or yield. Clients may also add scrap codes (i.e., reasons) to a given Scrap Yield Data entry.
  - **Scrap Code**: A scrap code is a code that explains the reason for a scrap/yield raw data input - such as \"Rework\"
- **Quality Test**: Quality Tests are results of quality assurance tests done on site, and uploaded to Oden. They may be attached to a single Batch or Run.
- **Metric**: Known in factories as \"tags\", metrics are the raw data that is collected by Oden from the machines and devices on the factory floor.
- **Metric Group**: Metric groups are metrics that represent the same thing across different lines. They provide common display names for tags and allow labeling groups of tags as measuring key types of data like performance or production.

### Best Practices
Under the current implementation, the Oden API does not rate limit requests from clients.

However, rate limiting will be introduced in the near future and it is recommended that users design their API
clients to not exceed a request rate of **one per second**.

### Schema
All v2 API access is over HTTPS and accessed from https://api.oden.app/v2
All data is sent and received as JSON.

API requests with duplicate keys will process only the data for the first key detected and ignore the rest, so it's not recommended. Batching multiple messages in this way is currently not possible.
  - Example of duplicate key in JSON: {\"raw_data\":{\"scrap\":\"10\",\"scrap\":\"100\"}}

All timestamps are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format:

  `YYYY-MM-DDTHH:MM:SSZ`

All durations are returned in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#Times) format with the largest unit of time being the hour:

   `PT[n]H[n]M[n]S`

All timestamps sent to the API in POST requests should be in ISO 8601 format.
### HTTP Verbs
The ONLY HTTP call type (sometimes called *verb* or *method*) used within Oden's API is **POST**.
There are three actions supported via a **POST**; call, search, set, and delete, together supporting CRUD operations;
  - **search** requests are used to search for and *read* objects in the Oden Platform
      - All Oden Objects may be uniquely identified by some combination of, or a single, parameter.
        - Ex a `line` my be identified by either:
          - `id`
          - `name` AND `factory`
  - **set** requests are used to *create* or *update* objects
  - **delete** requests are used to *delete* objects. If a delete endpoint is not yet implemented for a given object, users may choose to update the values of a specific entity to null or 0 values.

### URI Components
All endpoints may be accessed with the URI pattern:
`https://api.oden.app/v2/{object}/{action}`

Where:
  - `object` is the name of the object being requested:
       - `factory`, `quality_test`, `interval`, `line`, etc...
  - `action` is the name of the action being requested
    - `search` , `set` , `delete`

e.g. `https://api.oden.app/v2/factory/search`

# Authentication
Clients can authenticate through the v2 API using a Token provided by Oden. Tokens are opaque strings similar to
[Bearer](https://swagger.io/docs/specification/authentication/bearer-authentication/) tokens that the client must
pass in the [HTTP Authorization request header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Authorization) in every request.
The syntax is as follows:

`Authorization: <type> <credentials>`

Where \\<type\\> is \"Token\" and \\<credentials\\> is the Token string. For example:

`Authorization: Token tokenStringProvidedByOden`

Authenticating with an invalid Token will return `401 Unauthorized Error`.

Authenticating with a Token that is not authorized to read requested data will return `403 Forbidden Error`.

Some endpoints may require requests to be broken out by machinegroup (i.e., line or factory) and the number of
requests would scale accordingly. This multiplicity should be taken into consideration when deciding on the
frequency the API client makes requests to the Oden endpoints.

To authenticate in this [UI](https://api.oden.app/v2/ui/), click the Lock icon, and copy/paste the token into the Authorize box.


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 2.0.0
- SDK version: 1.0.0
- Generator version: 7.15.0
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://oden.io/contact/](https://oden.io/contact/)

<a id="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a id="dependencies"></a>
## Dependencies

- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```
<a id="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Oden.Api;
using Oden.Client;
using Oden.Model;
```
<a id="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

### Connections
Each ApiClass (properly the ApiClient inside it) will create an instance of HttpClient. It will use that for the entire lifecycle and dispose it when called the Dispose method.

To better manager the connections it's a common practice to reuse the HttpClient and HttpClientHandler (see [here](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net) for details). To use your own HttpClient instance just pass it to the ApiClass constructor.

```csharp
HttpClientHandler yourHandler = new HttpClientHandler();
HttpClient yourHttpClient = new HttpClient(yourHandler);
var api = new YourApiClass(yourHttpClient, yourHandler);
```

If you want to use an HttpClient and don't have access to the handler, for example in a DI context in Asp.net Core when using IHttpClientFactory.

```csharp
HttpClient yourHttpClient = new HttpClient();
var api = new YourApiClass(yourHttpClient);
```
You'll loose some configuration settings, the features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings. You need to either manually handle those in your setup of the HttpClient or they won't be available.

Here an example of DI setup in a sample web project:

```csharp
services.AddHttpClient<YourApiClass>(httpClient =>
   new PetApi(httpClient));
```


<a id="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Oden.Api;
using Oden.Client;
using Oden.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://api.oden.app";
            // Configure API key authorization: APIKeyAuth
            config.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("Authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IntervalsApi(httpClient, config, httpClientHandler);
            var interval = new Interval(); // Interval | 

            try
            {
                List<Interval> result = apiInstance.V2IntervalDeletePost(interval);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IntervalsApi.V2IntervalDeletePost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a id="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.oden.app*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*IntervalsApi* | [**V2IntervalDeletePost**](docs/IntervalsApi.md#v2intervaldeletepost) | **POST** /v2/interval/delete | 
*IntervalsApi* | [**V2IntervalSearchPost**](docs/IntervalsApi.md#v2intervalsearchpost) | **POST** /v2/interval/search | 
*IntervalsApi* | [**V2IntervalSetPost**](docs/IntervalsApi.md#v2intervalsetpost) | **POST** /v2/interval/set | 
*IntervalsApi* | [**V2IntervalTypeSearchPost**](docs/IntervalsApi.md#v2intervaltypesearchpost) | **POST** /v2/interval_type/search | 
*IntervalsApi* | [**V2IntervalUpdatePost**](docs/IntervalsApi.md#v2intervalupdatepost) | **POST** /v2/interval/update | 
*IntervalsApi* | [**V2IntervalsDeletePost**](docs/IntervalsApi.md#v2intervalsdeletepost) | **POST** /v2/intervals/delete | 
*IntervalsApi* | [**V2IntervalsSetPost**](docs/IntervalsApi.md#v2intervalssetpost) | **POST** /v2/intervals/set | 
*IntervalsApi* | [**V2IntervalsUpdatePost**](docs/IntervalsApi.md#v2intervalsupdatepost) | **POST** /v2/intervals/update | 
*MachineGroupsApi* | [**V2FactorySearchPost**](docs/MachineGroupsApi.md#v2factorysearchpost) | **POST** /v2/factory/search | 
*MachineGroupsApi* | [**V2LineSearchPost**](docs/MachineGroupsApi.md#v2linesearchpost) | **POST** /v2/line/search | 
*MetricGroupsApi* | [**V2MetricGroupSearchPost**](docs/MetricGroupsApi.md#v2metricgroupsearchpost) | **POST** /v2/metric_group/search | 
*OQLApi* | [**V2OqlQueryPost**](docs/OQLApi.md#v2oqlquerypost) | **POST** /v2/oql/query | 
*ProductAttributesApi* | [**V2ProductAttributeSearchPost**](docs/ProductAttributesApi.md#v2productattributesearchpost) | **POST** /v2/product_attribute/search | 
*ProductAttributesApi* | [**V2ProductAttributeSetPost**](docs/ProductAttributesApi.md#v2productattributesetpost) | **POST** /v2/product_attribute/set | 
*ProductMappingsApi* | [**V2ProductMappingSearchPost**](docs/ProductMappingsApi.md#v2productmappingsearchpost) | **POST** /v2/product_mapping/search | 
*ProductMappingsApi* | [**V2ProductMappingSetPost**](docs/ProductMappingsApi.md#v2productmappingsetpost) | **POST** /v2/product_mapping/set | 
*ProductsApi* | [**V2ProductDeletePost**](docs/ProductsApi.md#v2productdeletepost) | **POST** /v2/product/delete | 
*ProductsApi* | [**V2ProductSearchPost**](docs/ProductsApi.md#v2productsearchpost) | **POST** /v2/product/search | 
*ProductsApi* | [**V2ProductSetPost**](docs/ProductsApi.md#v2productsetpost) | **POST** /v2/product/set | 
*QualityTestApi* | [**V2QualitySchemaSearchPost**](docs/QualityTestApi.md#v2qualityschemasearchpost) | **POST** /v2/quality_schema/search | 
*QualityTestApi* | [**V2QualityTestDeletePost**](docs/QualityTestApi.md#v2qualitytestdeletepost) | **POST** /v2/quality_test/delete | 
*QualityTestApi* | [**V2QualityTestSearchPost**](docs/QualityTestApi.md#v2qualitytestsearchpost) | **POST** /v2/quality_test/search | 
*QualityTestApi* | [**V2QualityTestSetPost**](docs/QualityTestApi.md#v2qualitytestsetpost) | **POST** /v2/quality_test/set | 
*QualityTestApi* | [**V2QualityTestsDeletePost**](docs/QualityTestApi.md#v2qualitytestsdeletepost) | **POST** /v2/quality_tests/delete | 
*ScrapYieldDataApi* | [**V2ScrapYieldDeletePost**](docs/ScrapYieldDataApi.md#v2scrapyielddeletepost) | **POST** /v2/scrap_yield/delete | 
*ScrapYieldDataApi* | [**V2ScrapYieldSearchPost**](docs/ScrapYieldDataApi.md#v2scrapyieldsearchpost) | **POST** /v2/scrap_yield/search | 
*ScrapYieldDataApi* | [**V2ScrapYieldSetPost**](docs/ScrapYieldDataApi.md#v2scrapyieldsetpost) | **POST** /v2/scrap_yield/set | 
*TargetsApi* | [**V2TargetSearchPost**](docs/TargetsApi.md#v2targetsearchpost) | **POST** /v2/target/search | 
*TargetsApi* | [**V2TargetSetPost**](docs/TargetsApi.md#v2targetsetpost) | **POST** /v2/target/set | 


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.BatchMetadata](docs/BatchMetadata.md)
 - [Model.CustomMetadata](docs/CustomMetadata.md)
 - [Model.Factory](docs/Factory.md)
 - [Model.GenericError](docs/GenericError.md)
 - [Model.Interval](docs/Interval.md)
 - [Model.IntervalBulkCreate](docs/IntervalBulkCreate.md)
 - [Model.IntervalBulkDelete](docs/IntervalBulkDelete.md)
 - [Model.IntervalBulkUpdate](docs/IntervalBulkUpdate.md)
 - [Model.IntervalMetadata](docs/IntervalMetadata.md)
 - [Model.IntervalType](docs/IntervalType.md)
 - [Model.Line](docs/Line.md)
 - [Model.Match](docs/Match.md)
 - [Model.MetricGroup](docs/MetricGroup.md)
 - [Model.OQLQuery](docs/OQLQuery.md)
 - [Model.Product](docs/Product.md)
 - [Model.ProductAttribute](docs/ProductAttribute.md)
 - [Model.ProductMapping](docs/ProductMapping.md)
 - [Model.QualitySchema](docs/QualitySchema.md)
 - [Model.QualityTest](docs/QualityTest.md)
 - [Model.RunMetadata](docs/RunMetadata.md)
 - [Model.ScrapYieldData](docs/ScrapYieldData.md)
 - [Model.ScrapYieldSchema](docs/ScrapYieldSchema.md)
 - [Model.StateCategory](docs/StateCategory.md)
 - [Model.StateMetadata](docs/StateMetadata.md)
 - [Model.StateReason](docs/StateReason.md)
 - [Model.Target](docs/Target.md)
 - [Model.Unit](docs/Unit.md)
 - [Model.V2IntervalsDeletePost200Response](docs/V2IntervalsDeletePost200Response.md)
 - [Model.V2IntervalsUpdatePost200Response](docs/V2IntervalsUpdatePost200Response.md)
 - [Model.V2IntervalsUpdatePost200ResponseFailedIntervalsInner](docs/V2IntervalsUpdatePost200ResponseFailedIntervalsInner.md)
 - [Model.V2LineSearchPost400Response](docs/V2LineSearchPost400Response.md)
 - [Model.V2LineSearchPost409Response](docs/V2LineSearchPost409Response.md)
 - [Model.V2LineSearchPost500Response](docs/V2LineSearchPost500Response.md)
 - [Model.V2QualityTestsDeletePostRequest](docs/V2QualityTestsDeletePostRequest.md)
 - [Model.V2ScrapYieldSearchPostRequest](docs/V2ScrapYieldSearchPostRequest.md)
 - [Model.V2ScrapYieldSetPostRequest](docs/V2ScrapYieldSetPostRequest.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization


Authentication schemes defined for the API:
<a id="APIKeyAuth"></a>
### APIKeyAuth

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

