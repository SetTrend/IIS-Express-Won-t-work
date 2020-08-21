using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EF_DB.Repositories.Base;

using Repository.Entities.Lookups;
using Repository.Repositories.Lookups;

namespace EF_DB.Repositories.Lookups
{
	public class GenderAccess : RepositoryBase, IGenderAccess
	{
		public ICollection<Gender> Get()
		{
			using (Context db = new Context()) return db.Genders.ToArray();
		}

		public Gender Get(byte id)
		{
			using (Context db = new Context()) return db.Genders.Find(id);
		}

		public Task<Gender> AddOrUpdateAsync(Gender item) => throw new System.NotImplementedException();
		public Task RemoveAsync(byte key) => throw new System.NotImplementedException();
	}
}
