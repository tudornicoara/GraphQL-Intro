﻿using GraphQL.Types;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Types;

public class PropertyType : ObjectGraphType<Property>
{
    public PropertyType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Value);
        Field(x => x.City);
        Field(x => x.Family);
        Field(x => x.Street);
    }
}