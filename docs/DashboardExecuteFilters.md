# Oden.Model.DashboardExecuteFilters
Optional filter overrides applied to every module. Every field is optional; omitting one means \"no override on that dimension\". 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Lines** | [**List&lt;DashboardExecuteFiltersLinesInner&gt;**](DashboardExecuteFiltersLinesInner.md) | Lines to restrict to. Each entry must supply &#x60;id&#x60;, &#x60;name&#x60;, or both; entries that supply neither are rejected. Other Line fields (factory, secondary_name, match) are not used here and are intentionally omitted so generated clients don&#39;t suggest them as inputs.  | [optional] 
**Shifts** | **List&lt;int&gt;** |  | [optional] 
**ProductIds** | **List&lt;Guid&gt;** |  | [optional] 
**ProductAttributeValueIds** | **List&lt;Guid&gt;** |  | [optional] 
**ScrapCategories** | **List&lt;Guid&gt;** |  | [optional] 
**States** | [**DashboardExecuteFiltersStates**](DashboardExecuteFiltersStates.md) |  | [optional] 
**CustomIntervals** | [**List&lt;DashboardExecuteFiltersCustomIntervalsInner&gt;**](DashboardExecuteFiltersCustomIntervalsInner.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

