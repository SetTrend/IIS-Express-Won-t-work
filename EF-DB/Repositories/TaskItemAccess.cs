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
	public class TaskItemAccess : RepositoryBase, ITaskItemAccess
	{
		public ICollection<TaskItem> Get()
		{
			using (Context db = new Context()) return db.Tasks.ToArray();
		}

		public ICollection<TaskItem> Get(Guid assigneeId)
		{
			using (Context db = new Context()) return db.Tasks.Where(t => t.AssigneeId == assigneeId).ToArray();
		}

		public TaskItem Get(int id)
		{
			using (Context db = new Context()) return db.Tasks.Find(id);
		}

		public async Task<TaskItem> AddOrUpdateAsync(TaskItem item)
		{
			using (Context db = new Context())
			{
				if (item.Id == 0) db.Tasks.Add(item);
				else
				{
					db.Tasks.Attach(item);
					db.Entry(item).State = EntityState.Modified;
				}

				await db.SaveChangesAsync();

				return item;
			}
		}

		public async Task RemoveAsync(int key)
		{
			using (Context db = new Context())
			{
				db.Tasks.Remove(db.Tasks.Find(key));

				await db.SaveChangesAsync();
			}
		}
	}
}
