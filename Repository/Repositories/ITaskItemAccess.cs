using System;
using System.Collections.Generic;

using Repository.Entities;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
	public interface ITaskItemAccess : IRepositoryBase<TaskItem, int>
	{
		ICollection<TaskItem> Get();
		ICollection<TaskItem> Get(Guid assigneeId);
		TaskItem Get(int id);
	}
}
