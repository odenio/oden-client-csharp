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
- **Maintenance Work Order**: A maintenance work order can be used to track work orders maintained in MaintainX and associate them with an Oden line. 

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
- Generator version: 7.23.0
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
            var apiInstance = new DashboardsApi(httpClient, config, httpClientHandler);
            var dashboardExecuteRequest = new DashboardExecuteRequest(); // DashboardExecuteRequest | 

            try
            {
                // Execute a dashboard
                List<DashboardExecuteResult> result = apiInstance.ExecuteDashboard(dashboardExecuteRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DashboardsApi.ExecuteDashboard: " + e.Message );
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
*DashboardsApi* | [**ExecuteDashboard**](docs/DashboardsApi.md#executedashboard) | **POST** /v2/dashboard/execute | Execute a dashboard
*IntervalsApi* | [**BulkDeleteIntervals**](docs/IntervalsApi.md#bulkdeleteintervals) | **POST** /v2/intervals/delete | Delete intervals in a time range
*IntervalsApi* | [**BulkSetIntervals**](docs/IntervalsApi.md#bulksetintervals) | **POST** /v2/intervals/set | Create a set of intervals
*IntervalsApi* | [**BulkUpdateIntervals**](docs/IntervalsApi.md#bulkupdateintervals) | **POST** /v2/intervals/update | Update a set of intervals
*IntervalsApi* | [**DeleteInterval**](docs/IntervalsApi.md#deleteinterval) | **POST** /v2/interval/delete | Delete an interval
*IntervalsApi* | [**DeleteIntervalType**](docs/IntervalsApi.md#deleteintervaltype) | **POST** /v2/interval_type/delete | Delete a custom interval type
*IntervalsApi* | [**SearchIntervalTypes**](docs/IntervalsApi.md#searchintervaltypes) | **POST** /v2/interval_type/search | Search interval types
*IntervalsApi* | [**SearchIntervals**](docs/IntervalsApi.md#searchintervals) | **POST** /v2/interval/search | Search intervals on a line
*IntervalsApi* | [**SetInterval**](docs/IntervalsApi.md#setinterval) | **POST** /v2/interval/set | Create or update an interval
*IntervalsApi* | [**SetIntervalType**](docs/IntervalsApi.md#setintervaltype) | **POST** /v2/interval_type/set | Create or update a custom interval type
*IntervalsApi* | [**UpdateInterval**](docs/IntervalsApi.md#updateinterval) | **POST** /v2/interval/update | Update an interval
*MachineGroupsApi* | [**SearchFactories**](docs/MachineGroupsApi.md#searchfactories) | **POST** /v2/factory/search | Search factories
*MachineGroupsApi* | [**SearchLines**](docs/MachineGroupsApi.md#searchlines) | **POST** /v2/line/search | Search production lines
*MaintenanceWorkOrdersApi* | [**DeleteMaintenanceWorkOrder**](docs/MaintenanceWorkOrdersApi.md#deletemaintenanceworkorder) | **POST** /v2/maintenance_work_order/delete | Delete a maintenance work order
*MaintenanceWorkOrdersApi* | [**SearchMaintenanceWorkOrders**](docs/MaintenanceWorkOrdersApi.md#searchmaintenanceworkorders) | **POST** /v2/maintenance_work_order/search | Search maintenance work orders
*MaintenanceWorkOrdersApi* | [**SetMaintenanceWorkOrder**](docs/MaintenanceWorkOrdersApi.md#setmaintenanceworkorder) | **POST** /v2/maintenance_work_order/set | Create or update a maintenance work order
*MetricGroupsApi* | [**SearchMetricGroups**](docs/MetricGroupsApi.md#searchmetricgroups) | **POST** /v2/metric_group/search | Search metric groups
*OQLApi* | [**RunOqlQuery**](docs/OQLApi.md#runoqlquery) | **POST** /v2/oql/query | Run an OQL query
*ProductAttributesApi* | [**SearchProductAttributes**](docs/ProductAttributesApi.md#searchproductattributes) | **POST** /v2/product_attribute/search | Search product attributes
*ProductAttributesApi* | [**SetProductAttribute**](docs/ProductAttributesApi.md#setproductattribute) | **POST** /v2/product_attribute/set | Create or update a product attribute
*ProductMappingsApi* | [**SearchProductMappings**](docs/ProductMappingsApi.md#searchproductmappings) | **POST** /v2/product_mapping/search | Search product-to-line mappings
*ProductMappingsApi* | [**SetProductMapping**](docs/ProductMappingsApi.md#setproductmapping) | **POST** /v2/product_mapping/set | Map a product to a line
*ProductsApi* | [**DeleteProduct**](docs/ProductsApi.md#deleteproduct) | **POST** /v2/product/delete | Delete a product
*ProductsApi* | [**SearchProducts**](docs/ProductsApi.md#searchproducts) | **POST** /v2/product/search | Search products
*ProductsApi* | [**SetProduct**](docs/ProductsApi.md#setproduct) | **POST** /v2/product/set | Create or update a product
*QualityTestApi* | [**BulkDeleteQualityTests**](docs/QualityTestApi.md#bulkdeletequalitytests) | **POST** /v2/quality_tests/delete | Delete multiple quality tests
*QualityTestApi* | [**DeleteQualityTest**](docs/QualityTestApi.md#deletequalitytest) | **POST** /v2/quality_test/delete | Delete a quality test
*QualityTestApi* | [**SearchQualitySchemas**](docs/QualityTestApi.md#searchqualityschemas) | **POST** /v2/quality_schema/search | Search quality schemas for a factory
*QualityTestApi* | [**SearchQualityTests**](docs/QualityTestApi.md#searchqualitytests) | **POST** /v2/quality_test/search | Search quality tests
*QualityTestApi* | [**SetQualityTest**](docs/QualityTestApi.md#setqualitytest) | **POST** /v2/quality_test/set | Create or update a quality test result
*ScrapYieldDataApi* | [**DeleteScrapYield**](docs/ScrapYieldDataApi.md#deletescrapyield) | **POST** /v2/scrap_yield/delete | Delete a scrap/yield record
*ScrapYieldDataApi* | [**SearchScrapYield**](docs/ScrapYieldDataApi.md#searchscrapyield) | **POST** /v2/scrap_yield/search | Search scrap/yield records
*ScrapYieldDataApi* | [**SetScrapYield**](docs/ScrapYieldDataApi.md#setscrapyield) | **POST** /v2/scrap_yield/set | Create or update a scrap/yield record
*TargetsApi* | [**SearchTargets**](docs/TargetsApi.md#searchtargets) | **POST** /v2/target/search | Search metric targets
*TargetsApi* | [**SetTarget**](docs/TargetsApi.md#settarget) | **POST** /v2/target/set | Create or update a metric target


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.BatchMetadata](docs/BatchMetadata.md)
 - [Model.BulkDeleteIntervals200Response](docs/BulkDeleteIntervals200Response.md)
 - [Model.BulkDeleteQualityTestsRequest](docs/BulkDeleteQualityTestsRequest.md)
 - [Model.BulkUpdateIntervals200Response](docs/BulkUpdateIntervals200Response.md)
 - [Model.BulkUpdateIntervals200ResponseFailedIntervalsInner](docs/BulkUpdateIntervals200ResponseFailedIntervalsInner.md)
 - [Model.CustomMetadata](docs/CustomMetadata.md)
 - [Model.DashboardColumnSpec](docs/DashboardColumnSpec.md)
 - [Model.DashboardExecuteFilters](docs/DashboardExecuteFilters.md)
 - [Model.DashboardExecuteFiltersCustomIntervalsInner](docs/DashboardExecuteFiltersCustomIntervalsInner.md)
 - [Model.DashboardExecuteFiltersLinesInner](docs/DashboardExecuteFiltersLinesInner.md)
 - [Model.DashboardExecuteFiltersStates](docs/DashboardExecuteFiltersStates.md)
 - [Model.DashboardExecuteFiltersStatesStateCategoryAndReasonsInner](docs/DashboardExecuteFiltersStatesStateCategoryAndReasonsInner.md)
 - [Model.DashboardExecuteRange](docs/DashboardExecuteRange.md)
 - [Model.DashboardExecuteRequest](docs/DashboardExecuteRequest.md)
 - [Model.DashboardExecuteRequestDashboard](docs/DashboardExecuteRequestDashboard.md)
 - [Model.DashboardExecuteResult](docs/DashboardExecuteResult.md)
 - [Model.DashboardExecuteResultRange](docs/DashboardExecuteResultRange.md)
 - [Model.Factory](docs/Factory.md)
 - [Model.GenericError](docs/GenericError.md)
 - [Model.Interval](docs/Interval.md)
 - [Model.IntervalBulkCreate](docs/IntervalBulkCreate.md)
 - [Model.IntervalBulkDelete](docs/IntervalBulkDelete.md)
 - [Model.IntervalBulkUpdate](docs/IntervalBulkUpdate.md)
 - [Model.IntervalMetadata](docs/IntervalMetadata.md)
 - [Model.IntervalType](docs/IntervalType.md)
 - [Model.IntervalTypeSet](docs/IntervalTypeSet.md)
 - [Model.Line](docs/Line.md)
 - [Model.MaintenanceWorkOrder](docs/MaintenanceWorkOrder.md)
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
 - [Model.SearchLines400Response](docs/SearchLines400Response.md)
 - [Model.SearchLines409Response](docs/SearchLines409Response.md)
 - [Model.SearchLines500Response](docs/SearchLines500Response.md)
 - [Model.SearchMaintenanceWorkOrdersRequest](docs/SearchMaintenanceWorkOrdersRequest.md)
 - [Model.SearchScrapYieldRequest](docs/SearchScrapYieldRequest.md)
 - [Model.SetScrapYieldRequest](docs/SetScrapYieldRequest.md)
 - [Model.StateCategory](docs/StateCategory.md)
 - [Model.StateMetadata](docs/StateMetadata.md)
 - [Model.StateReason](docs/StateReason.md)
 - [Model.Target](docs/Target.md)
 - [Model.Unit](docs/Unit.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization


Authentication schemes defined for the API:
<a id="APIKeyAuth"></a>
### APIKeyAuth

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

