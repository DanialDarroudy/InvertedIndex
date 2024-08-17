﻿using System.Data;

namespace ETLProject.Transform.Aggregation;

public interface IAggregateStrategy
{
    public decimal DoSpecificAggregate(List<DataRow> rowsInGroup , DataColumn aggregated);
}