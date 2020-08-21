using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using EF_DB.Repositories.Base;

using Repository.Entities;
using Repository.Repositories;

namespace EF_DB.Repositories
{
	public class UserAccess : RepositoryBase, IUserAccess
	{
		public ICollection<User> Get()
		{
			using (Context db = new Context()) return db.Users.ToArray();
		}

		public ICollection<User> Get(string familyName)
		{
			using (Context db = new Context()) return db.Users.Where(u => u.FamilyName == familyName).ToArray();
		}

		public ICollection<User> Get(string firstName, string familyName)
		{
			using (Context db = new Context()) return db.Users.Where(u => u.FirstName == firstName && u.FamilyName == familyName).ToArray();
		}

		public User Get(Guid id)
		{
			using (Context db = new Context()) return db.Users.Find(id);
		}

		public async Task<User> AddOrUpdateAsync(User item)
		{
			using (Context db = new Context())
			{
				if (item.Id == Guid.Empty) db.Users.Add(item);
				else
				{
					db.Users.Attach(item);
					db.Entry(item).State = EntityState.Modified;
				}

				await db.SaveChangesAsync();

				return item;
			}
		}

		public async Task RemoveAsync(Guid key)
		{
			using (Context db = new Context())
			{
				db.Users.Remove(db.Users.Find(key));

				await db.SaveChangesAsync();
			}
		}
	}
}
