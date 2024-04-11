namespace RealEstateManager.Schema;
using GraphQL;

public class RealEstateSchema : GraphQL.Types.Schema
{
    public RealEstateSchema(IDependencyResolver resolver)
        : base(resolver)
    {
        
    }
}