using APIGW.Interfaces;
using APIGW.Models.EshopManager;

public class MySQLEshopRepository : IRepository<EshopItem>
{
    // MySQL-specific logic
    public Task<IEnumerable<EshopItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EshopItem> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}