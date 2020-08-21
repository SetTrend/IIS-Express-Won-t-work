using System.Collections.Generic;

using Repository.Entities.Lookups;
using Repository.Repositories.Base;

namespace Repository.Repositories.Lookups
{
	public interface IGenderAccess : IRepositoryBase<Gender, byte>
	{
		ICollection<Gender> Get();
		Gender Get(byte id);
	}
}
