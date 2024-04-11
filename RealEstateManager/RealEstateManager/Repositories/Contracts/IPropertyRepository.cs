using RealEstateManager.Database.Models;

namespace RealEstateManager.Repositories.Contracts;

public interface IPropertyRepository
{
    IEnumerable<Property> GetAll();
}