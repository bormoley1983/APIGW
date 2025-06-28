namespace APIGW.Interfaces
{
	public interface IRepository<T>
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
	}
}