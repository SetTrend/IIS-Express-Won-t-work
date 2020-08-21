using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Repository.Entities.Lookups;
using Repository.Repositories.Lookups;

namespace WebAPI.Controllers.Lookups
{
	[Route("lookups/[controller]")]
	[ApiController]
	public class GendersController : ControllerBase
	{
		private readonly IGenderAccess _repository;



		/* internal */
		public GendersController(IGenderAccess repository) => _repository = repository;



		[HttpGet]
		public ICollection<Gender> Get() => _repository.Get();

		[HttpGet("{id}")]
		public Gender Get(byte id) => _repository.Get(id);
	}
}
