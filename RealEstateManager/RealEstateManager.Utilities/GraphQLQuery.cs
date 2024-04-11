﻿using Newtonsoft.Json.Linq;

namespace RealEstateManager.Utilities;

public class GraphQLQuery
{
    public string? OperationName { get; set; }
    public string? Query { get; set; }
    // public JObject Variables { get; set; }
    public string? Variables { get; set; }
}