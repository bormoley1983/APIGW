using APIGW.Interfaces;
using APIGW.Models.WareHouse;

public class MSSQLWarehouseRepository : IRepository<WarehouseItem>
{
    // MSSQL-specific logic
    public Task<IEnumerable<WarehouseItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WarehouseItem> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}