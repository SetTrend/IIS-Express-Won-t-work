using System.Threading.Tasks;

namespace Repository.Repositories.Base
{
	public interface IRepositoryBase<T, K>
	{
		Task<T> AddOrUpdateAsync(T item);
		Task RemoveAsync(K key);
	}
}
