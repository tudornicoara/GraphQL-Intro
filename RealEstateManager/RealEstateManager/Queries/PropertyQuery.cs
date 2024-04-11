using GraphQL.Types;
using RealEstateManager.Repositories.Contracts;
using RealEstateManager.Types;

namespace RealEstateManager.Queries;

public class PropertyQuery : ObjectGraphType
{
    public PropertyQuery(IPropertyRepository propertyRepository)
    {
        Field<ListGraphType<PropertyType>>(
            "properties",
            resolve: context => propertyRepository.GetAll());
    }
}