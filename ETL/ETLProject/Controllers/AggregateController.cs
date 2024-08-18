﻿using ETLProject.Transform;
using ETLProject.Transform.Aggregation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETLProject.Controllers;

public class AggregateController : Controller
{
    [HttpPost]
    public IActionResult Aggregation([FromBody] List<Tuple<string, string>> sources, [FromBody] AggregationDto dto)
    {
        var converters = DataConversionManager.CreateConvertersFromSources(sources);
        
        var allTables = DataConversionManager.AddConvertedTablesToList(converters , sources);

        
        
        var resultTable = new Aggregation(dto).Aggregate(ConvertStringToObject.GetDataTable(allTables , dto.TableName));
        
        return Ok(JsonConvert.SerializeObject(resultTable));
    }
}