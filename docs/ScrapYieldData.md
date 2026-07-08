# Oden.Model.ScrapYieldData
An object representing scrap and yield data for a line for a particular run or batch interval. Data can be sent unstructured in the `raw_data` field as long as we have a scrap/yield schema for the factory. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RawData** | **string** |  | [optional] 
**Id** | **Guid** |  | [optional] 
**Schema** | [**ScrapYieldSchema**](ScrapYieldSchema.md) |  | [optional] 
**Timestamp** | **DateTime?** |  | [optional] 
**Match** | **Match** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

