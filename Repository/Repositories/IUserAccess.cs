using System;
using System.Collections.Generic;

using Repository.Entities;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
	public interface IUserAccess : IRepositoryBase<User, Guid>
	{
		ICollection<User> Get();
		ICollection<User> Get(string familyName);
		ICollection<User> Get(string firstName, string familyName);
		User Get(Guid id);
	}
}
