using RealEstateManager.Data;
using RealEstateManager.Database.Models;
using RealEstateManager.Repositories.Contracts;

namespace RealEstateManager.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly RealEstateContext _dbContext;

    public PropertyRepository(RealEstateContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Property> GetAll()
    {
        return _dbContext.Properties;
    }
}