# Oden.Model.DashboardExecuteRange
Time window applied to every module. Either supply an absolute window (`start` and `end`) OR a relative window (`anchor` and `offset`, optionally with `timezone`), not both. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Start** | **DateTime** |  | [optional] 
**End** | **DateTime** |  | [optional] 
**Anchor** | **string** | Anchor expression for a relative range, e.g. &#x60;now&#x60;. | [optional] 
**Offset** | **string** | Offset expression for a relative range, e.g. &#x60;-7D&#x60;. | [optional] 
**Timezone** | **string** | IANA timezone identifier (defaults to UTC). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

