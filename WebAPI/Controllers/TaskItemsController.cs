using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Repository.Entities;
using Repository.Repositories;

namespace WebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TaskItemsController : ControllerBase
	{
		private readonly ITaskItemAccess _repository;



		internal TaskItemsController(ITaskItemAccess repository) => _repository = repository;



		[HttpGet]
		public ICollection<TaskItem> Get() => _repository.Get();

		[HttpGet("{assigneeId}")]
		public ICollection<TaskItem> Get(Guid assigneeId) => _repository.Get(assigneeId);

		[HttpGet("{id}")]
		public TaskItem Get(int id) => _repository.Get(id);

		[HttpPut]
		public Task<TaskItem> AddOrUpdateAsync(TaskItem taskItem) => _repository.AddOrUpdateAsync(taskItem);

		[HttpDelete]
		public Task RemoveAsync(int id) => _repository.RemoveAsync(id);
	}
}
