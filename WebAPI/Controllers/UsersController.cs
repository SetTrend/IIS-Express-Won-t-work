using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Repository.Entities;
using Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserAccess _repository;



		/* internal */
		public UsersController(IUserAccess repository) => _repository = repository;



		[HttpGet]
		public ICollection<User> Get() => _repository.Get();

		[HttpGet("{familyName}")]
		public ICollection<User> Get(string familyName) => _repository.Get(familyName);

		[HttpGet("{firstName}/{familyName}")]
		public ICollection<User> Get(string firstName, string familyName) => _repository.Get(firstName, familyName);

		[HttpGet("{id}")]
		public User Get(Guid id) => _repository.Get(id);

		[HttpPut]
		public Task<User> AddOrUpdateAsync(User user) => _repository.AddOrUpdateAsync(user);

		[HttpDelete]
		public Task RemoveAsync(Guid id) => _repository.RemoveAsync(id);
	}
}
